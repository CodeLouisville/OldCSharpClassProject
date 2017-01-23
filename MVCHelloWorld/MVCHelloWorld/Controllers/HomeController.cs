using MVCHelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHelloWorld.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var person = new Person()
            {
                FirstName = "bob",
                LastName = "uncle"
            };
            return View(person);
        }

        public ActionResult SayHello(Person person)
        {
            person.FirstName = person.FirstName.ToUpperInvariant();
            person.LastName = person.LastName.ToUpperInvariant();
            return View(person);
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