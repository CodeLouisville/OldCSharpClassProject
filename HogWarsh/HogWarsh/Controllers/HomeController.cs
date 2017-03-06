using HogWarsh.Models;
using HogWarsh.Repositories;
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
            var vm = new HomeIndexViewModel();

            var houseRepository = new HouseRepository();
            var houses = houseRepository.GetAll();

            var studentRepository = new StudentRepository();
            var students = studentRepository.GetAll();

            vm.Houses = houses.Select(h => new HomeIndexViewModel.HouseViewModel
            {
                Id = h.Id,
                Color = "green",
                Name = h.Name,
                Students = new List<Student>()
            }).ToList();

            foreach (var student in students)
            {
                if (student.House == null) continue; 
                var house = vm.Houses.FirstOrDefault(h => h.Id == student.House.Id);
                if (house == null) continue; 
                house.Students.Add(student); 
            }

            var sortedByStudentCount = vm.Houses.OrderByDescending(h => h.Students.Count);
            var biggestHouse = sortedByStudentCount.FirstOrDefault();
            if (biggestHouse != null) biggestHouse.Color = "red";

            vm.Houses = vm.Houses.OrderBy(h => h.Name).ToList();

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