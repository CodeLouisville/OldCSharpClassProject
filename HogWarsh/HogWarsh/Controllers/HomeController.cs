using HogWarsh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HogWarsh.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vm = new HomeIndexViewModel()
            {
                Houses = new List<HomeIndexViewModel.HouseViewModel>()
                {
                    new HomeIndexViewModel.HouseViewModel()
                    {
                        Id=1, 
                        Name = "FOO House", 
                        Students = new List<Student>()
                        {
                            new Student()
                            {
                                Id=11, 
                                Name="Bob",
                                Species = Species.Canine.ToString()
                            }
                        }
                    }
                }
            };
            return View(vm);
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