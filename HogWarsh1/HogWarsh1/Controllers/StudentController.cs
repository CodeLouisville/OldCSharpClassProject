using HogWarsh1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HogWarsh1.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Enroll()
        {
            var vm = new StudentEnrollViewModel() {
                Student = new Student(),
                Houses = InMemoryDatabase.GetAllHouses()
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Enroll(StudentEnrollViewModel studentvm)
        {
            // TODO: put in database and send user somewhere
            
            // when demoing this, show the generated HTML from the previous commit vs this commit, how the input fields
            // change as you change view models

            return View(studentvm);
        }

        public class StudentEnrollViewModel
        {
            // could move this out to Models.

            public Student Student { get; set; }
            public List<House> Houses { get; set; }
        }

    }
}