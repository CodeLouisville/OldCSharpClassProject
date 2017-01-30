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
                FirstName = "",
                LastName = ""
            };
            return View(person);
        }

        public ActionResult SayHello(Person person)
        {
            person.FirstName = person.FirstName.ToUpperInvariant();
            person.LastName = person.LastName.ToUpperInvariant();
            return View(person);
        }

        public ActionResult ShowMeAList()
        {
            List<Person> list = new List<Person>()
            {
                new Person() { FirstName="Luke", LastName="Skywalker" },
                new Models.Person() { FirstName="Leia", LastName="Organa" },
                new Person() { FirstName="Chewbacca", LastName=null }
            };
            return View("ShowMeAList", list);
        }

    }
}