using HelloWorldMVC.Models;
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

            var personModel = new Person();

            return View("Index",personModel);
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