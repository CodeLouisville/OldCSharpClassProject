using HogWarsh.Models;
using HogWarsh.Repositories;
using System.Web.Mvc;

namespace HogWarsh.Controllers
{
    public class StudentController : Controller
    {
        private StudentRepository repository;

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

            repository = new StudentRepository();
            repository.Create(student);
            return RedirectToAction("Students");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            repository = new StudentRepository();
            var student = repository.GetById(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            repository = new StudentRepository();
            repository.Update(student);
            return RedirectToAction("Students");
        }

        [HttpGet]
        public ActionResult Students()
        {
            repository = new StudentRepository();
            var students = repository.GetAll();

            return View(students);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            repository = new StudentRepository();
            var student = repository.GetById(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            repository = new StudentRepository();
            repository.Delete(student.Id);
            return RedirectToAction("Students");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            repository = new StudentRepository();

            return View(repository.GetById(id));
        }
    }
}