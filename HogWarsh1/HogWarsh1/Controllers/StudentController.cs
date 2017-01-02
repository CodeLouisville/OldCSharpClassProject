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
            StudentSortingViewModel vm = GetSortingViewModel();

            return View(vm);
        }

        private static StudentSortingViewModel GetSortingViewModel()
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

            return vm;
        }

        public ActionResult DoTheSort()
        {
            var vm = GetSortingViewModel();
            var rand = new Random();
            var housesToChooseFrom = vm.HousesWithStudents.Keys.ToList();  
            foreach (var student in vm.StudentsToSort)
            {
                var houseIndex = rand.Next(0, housesToChooseFrom.Count);
                var house = housesToChooseFrom[houseIndex];
                student.House = house;
                InMemoryDatabase.SaveStudent(student);
            }
            return RedirectToAction("Sort");
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