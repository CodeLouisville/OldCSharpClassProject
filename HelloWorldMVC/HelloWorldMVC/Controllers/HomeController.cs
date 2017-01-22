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
            var studentModel = new Student(); 
            return View(studentModel);
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