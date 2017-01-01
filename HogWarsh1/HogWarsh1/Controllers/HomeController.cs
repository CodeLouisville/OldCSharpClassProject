using HogWarsh1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HogWarsh1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vm = new HomeIndexViewModel(); 
            var allHouses = InMemoryDatabase.GetAllHouses(); 
            foreach (var house in allHouses)
            {
                var students = InMemoryDatabase.GetStudentsForHouse(house.Name);
                vm.Houses.Add(new HomeIndexViewModel.HouseWithCountViewModel
                {
                    House = house,
                    NumberOfStudents = students.Count()
                });
            }

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

        public class HomeIndexViewModel
        {
            public HomeIndexViewModel()
            {
                Houses = new List<HouseWithCountViewModel>();
            }
            public List<HouseWithCountViewModel> Houses { get; set; } 

            public class HouseWithCountViewModel
            {
                public House House { get; set; }
                public int NumberOfStudents { get; set; }
            }

        }
    }
}