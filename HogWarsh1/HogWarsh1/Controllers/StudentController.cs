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
                Species = InMemoryDatabase.GetAllSpecies()
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Enroll(StudentEnrollViewModel studentvm)
        {
            studentvm.Student.House = null; // initially not sorted
            InMemoryDatabase.SaveStudent(studentvm.Student);

            // when demoing this, show the generated HTML from the previous commit vs this commit, how the input fields
            // change as you change view models

            return RedirectToAction("Index", "Home", new { });
        }

        public ActionResult Sort()
        {
            var vm = new StudentSortingViewModel()
            {
                StudentsToSort = InMemoryDatabase.GetStudentsWithoutAHouse()
            };
            foreach (var house in InMemoryDatabase.GetAllHouses())
            {
                var students = InMemoryDatabase.GetStudentsForHouse(house.Name);
                vm.HousesWithStudents[house.Name] = students; 
            }

            return View(vm);
        }

        public ActionResult DoTheSort()
        {
            throw new NotImplementedException();
        }

        public class StudentEnrollViewModel
        {
            // could move this out to Models.

            public Student Student { get; set; }
            public List<Species> Species { get; set; }
        }

        public class StudentSortingViewModel
        {
            public List<Student> StudentsToSort { get; set; }
            public Dictionary<string, List<Student>> HousesWithStudents { get; set; }
            public StudentSortingViewModel()
            {
                StudentsToSort = new List<Student>();
                HousesWithStudents = new Dictionary<string, List<Student>>();
            }
        }

    }
}