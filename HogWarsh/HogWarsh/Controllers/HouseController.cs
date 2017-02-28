using HogWarsh.Models;
using HogWarsh.Repositories;
using System.Web.Mvc;

namespace HogWarsh.Controllers
{
    public class HouseController : Controller
    {
        private HouseRepository repository;

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(House house)
        {
            if (!ModelState.IsValid)
            {
                return View("Enroll");
            }

            repository = new HouseRepository();
            repository.Create(house);
            return RedirectToAction("Houses");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            repository = new HouseRepository();
            var house = repository.GetById(id);
            return View(house);
        }

        [HttpPost]
        public ActionResult Edit(House house)
        {
            repository = new HouseRepository();
            repository.Update(house);
            return RedirectToAction("Houses");
        }

        [HttpGet]
        public ActionResult Houses()
        {
            repository = new HouseRepository();
            var houses = repository.GetAll();

            return View(houses);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            repository = new HouseRepository();
            var house = repository.GetById(id);
            return View(house);
        }

        [HttpPost]
        public ActionResult Delete(House house)
        {
            repository = new HouseRepository();
            repository.Delete(house.Id);
            return RedirectToAction("Houses");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            repository = new HouseRepository();

            return View(repository.GetById(id));
        }
    }
}