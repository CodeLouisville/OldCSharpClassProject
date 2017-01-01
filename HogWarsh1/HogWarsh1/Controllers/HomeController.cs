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
                vm.HousesWithCounts.Add(new HomeIndexViewModel.HouseWithCountViewModel
                {
                    House = house,
                    NumberOfStudents = students.Count()
                });
            }
            vm.StudentsWithoutHouses = InMemoryDatabase.GetStudentsWithoutAHouse().Count;

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
                HousesWithCounts = new List<HouseWithCountViewModel>();
            }
            public List<HouseWithCountViewModel> HousesWithCounts { get; set; } 

            public class HouseWithCountViewModel
            {
                public House House { get; set; }
                public int NumberOfStudents { get; set; }
            }

            public int StudentsWithoutHouses { get; set; }


        }
    }
}