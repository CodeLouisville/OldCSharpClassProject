using Contacto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace Contacto.Controllers
{
    public class HomeController : Controller
    {
        static ContactRepository _contactRepository = new ContactRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreateContact()
        {
            return View("AddContact");
        }

        public ActionResult AddContact(Contact contact)
        {
            _contactRepository.AddContact(contact);
            return View("SingleContact",contact);
        }


        public ActionResult ViewContacts()
        {
            return View("ContactList", _contactRepository.Contacts);
        }

        public ActionResult EditContact(int id)
        {
            return View("EditContact", _contactRepository.GetContact(id));
        }

        public ActionResult ChangeContact(Contact contact)
        {
            _contactRepository.EditContact(contact);
            return View("ContactList", _contactRepository.Contacts);
        }
    }

    public class ContactRepository
    {

        public void AddContact(Contact contact)
        {
            using (var connection = CreateConnection())
            {
                connection.Execute("INSERT INTO CONTACTS (LASTNAME, FIRSTNAME) VALUES (@lastname, @firstname)", new { lastname = contact.LastName, firstname = contact.FirstName });
            }
        }

        public List<Contact> Contacts
        {
            get
            {
                using (var connection = CreateConnection())
                {
                    return connection.Query<Contact>("SELECT * FROM CONTACTS").ToList();
                }
            }
        }

        public Contact GetContact(int id)
        {
            using (var connection = CreateConnection())
            {
                return connection.QuerySingle<Contact>("SELECT * FROM CONTACTS WHERE ID = @contactid", new { contactid = id });
            }
        }

        public void EditContact(Contact contact)
        {
            using (var connection = CreateConnection())
            {
                connection.Execute("UPDATE CONTACTS SET LASTNAME = @lastname, FIRSTNAME = @firstname where ID = @id", new { lastname = contact.LastName, firstname = contact.FirstName, id = contact.ID });
            }
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Contacto;Trusted_Connection=True");
        }
    }
}