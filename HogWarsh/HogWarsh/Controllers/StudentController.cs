using HogWarsh.Models;
using System.Web.Mvc;

namespace HogWarsh.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Enroll()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ActuallyEnroll(Student student)
        {
            return View();
        }

    }
}