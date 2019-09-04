using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppMVCRecap.Models;

namespace WebAppMVCRecap.Controllers
{
    public class CarsController : Controller
    {

        readonly ICarsRepository _carsRepository;

        public CarsController(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public IActionResult Index()
        {
            return View(_carsRepository.AllCars());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Brand,Name")] Car car)
        {
            if (ModelState.IsValid)
            {
                _carsRepository.Create(car.Brand , car.Name);
                return RedirectToAction("Index");
            }
            return View(car);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }

            Car car = _carsRepository.FindById((int)id);

            if (car == null)
            {
                return NotFound();
            }

            return PartialView("_ConfirmDeleteCar", car);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id, int itemId)
        {
            if (id == itemId)
            {
                if (_carsRepository.Delete(id))
                {
                    return Content("");
                }

                return NotFound();
            }

            return BadRequest();
        }
    }
}