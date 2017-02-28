using HogWarsh.Models;
using HogWarsh.Repositories;
using System.Web.Mvc;

namespace HogWarsh.Controllers
{
    public class StudentController : Controller
    {
        private StudentRepository studentRepository;
        private HouseRepository houseRepository;

        [HttpGet]
        public ActionResult Enroll()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ActuallyEnroll(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View("Enroll");
            }

            studentRepository = new StudentRepository();
            studentRepository.Create(student);
            return RedirectToAction("Students");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            studentRepository = new StudentRepository();
            var student = studentRepository.GetById(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {  
            studentRepository = new StudentRepository();
            studentRepository.Update(student);
            return RedirectToAction("Students");
        }

        [HttpGet]
        public ActionResult Students()
        {
            studentRepository = new StudentRepository();
            var students = studentRepository.GetAll();

            return View(students);
        }

        [HttpGet]
        public ActionResult HouselessStudents()
        {
            studentRepository = new StudentRepository();
            return View(studentRepository.GetStudentsWithoutHouses());
        }

        [HttpGet]
        public ActionResult AssignHouse(int studentId)
        {
            houseRepository = new HouseRepository();
            studentRepository = new StudentRepository();

            var houses = houseRepository.GetAll();
            var student = studentRepository.GetById(studentId);

            var houseCount = houses.Count;

            var random = new System.Random();
            var houseNumber = random.Next(houseCount);

            var chosenHouse = houses[houseNumber];
            student.House = chosenHouse;

            studentRepository.Update(student);

            return RedirectToAction("Students");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            studentRepository = new StudentRepository();
            var student = studentRepository.GetById(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            studentRepository = new StudentRepository();
            studentRepository.Delete(student.Id);
            return RedirectToAction("Students");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            studentRepository = new StudentRepository();

            return View(studentRepository.GetById(id));
        }
    }
}