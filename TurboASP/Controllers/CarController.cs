using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TurboASP.Repository;
using TurboASP.Models;

namespace TurboASP.Controllers
{
    public class CarController : Controller
    {
        public CarRepository Cars { get; set; } = new CarRepository();


        
        static int notFound = 0;
        public IActionResult Index() => View(CarRepository.Cars);

        public IActionResult Listing(int id)
        {
            Car? car = Cars.GetCar(id);

            if (car == null)
            {
                notFound = id;
                return RedirectToAction("NotFound");
            }
            return View(car);
        }

        [HttpGet]
        public IActionResult Add() => View();

        [HttpPost]

        public IActionResult Add(Car car)
        {
            if(!ModelState.IsValid)
            {
                return View(car);
            }
            Cars.AddCar(car);
            return RedirectToAction("Index");
        }

        public IActionResult Filter()
        {
            return View();
        }
    }
}
