using HelloWorldMVC.Models;
using HelloWorldMVC.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new ListOfPersonsViewModel()
            {
                Persons = new List<Person>
                {
                    new Models.Person() { FirstName="Luke", LastName="Skywalker" },
                    new Models.Person() { FirstName="Anakin", LastName="Skywalker" },
                    new Models.Person() { FirstName="Obi-Wan", LastName="Kenobi" },
                    new Models.Person() { FirstName="Han", LastName="Solo" },
                    new Models.Person() { FirstName="Leia", LastName="Organa" },
                    new Models.Person() { FirstName="Chewbacca", LastName="Wookie" },
                    new Models.Person() { FirstName="Governor", LastName="Tarkin" },
                }
            };

            return View("Index", model);
        }

        public ActionResult SayHello(Person person)
        {
            person.FirstName = person.FirstName.ToUpperInvariant();
            return View("SayHello",person);
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
    }
}