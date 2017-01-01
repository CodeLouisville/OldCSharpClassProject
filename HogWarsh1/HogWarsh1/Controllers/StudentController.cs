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
            var vm = new Models.Student() { Name = "a" };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Enroll(Models.Student studentvm)
        {
            studentvm.Name = "This modification is ignored due to how EditorFor works";
            return View(studentvm);
        }

    }
}