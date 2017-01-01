using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HogWarsh1.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Enroll()
        {
            var vm = new Models.Student(); 
            return View(vm);
        }
    }
}