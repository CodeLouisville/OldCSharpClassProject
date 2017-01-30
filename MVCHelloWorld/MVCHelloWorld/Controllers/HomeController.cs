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
        static List<Person> list = new List<Person>()
            {
                new Person() { FirstName="Luke", LastName="Skywalker" },
                new Models.Person() { FirstName="Leia", LastName="Organa" },
                new Person() { FirstName="Chewbacca", LastName=null }
            };

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
            list.Add(person);
            person.FirstName = person.FirstName.ToUpperInvariant();
            person.LastName = person.LastName.ToUpperInvariant();
            return View("ShowMeAList",list);
        }

        public ActionResult ShowMeAList()
        {
            return View("ShowMeAList", list);
        }

    }
}