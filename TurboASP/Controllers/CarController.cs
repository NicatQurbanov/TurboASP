using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TurboASP.Repository;
using TurboASP.Models;

namespace TurboASP.Controllers
{
    public class CarController : Controller
    {
        public CarRepository Cars { get; set; } = new CarRepository();

        public List<Car> CarsList { get; set; } = CarRepository.Cars;

        public static SearchKeys? Key { get; set; }

        public static List<Car>? filteredCars { get; set; }
        
        static int notFound = 0;
        public IActionResult Index() => View(CarsList);

        public IActionResult Listing(int id)
        {
            Car? car = Cars.GetCar(id);

            if (car == null)
            {
                notFound = id;
                return RedirectToAction("NotFound");
            }
            car.Views++;
            return View(car);
        }

        [HttpGet]
        public IActionResult Add() => View();

        [HttpPost]

        public IActionResult Add(Car car)
        {
            if(car.ImageFile != null)
            {
                var filePath = Path.Combine("wwwroot/lib/Images", car.ImageFile.FileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                car.ImageFile.CopyToAsync(stream);
            }
            if(!ModelState.IsValid)
                return View(car);
            Cars.AddCar(car);
            CarsList.Reverse();
            return RedirectToAction("AddSuccess", car);
        }

        public IActionResult AddSuccess(Car car) => View(car);

        [HttpGet]
        public IActionResult Filter() => View();

        [HttpPost]

        public IActionResult Filter(SearchKeys keys)
        {
            Key = keys;
            if(Key.MaxYear == null)
                Key.MaxYear = DateTime.Now.Year;
            if (Key.MinYear == null)
                Key.MinYear = 1920;
            if (Key.MaxPrice == null) 
                Key.MaxPrice = int.MaxValue;
            if (Key.MinPrice == null)
                Key.MinPrice = 0;
            if (Key.MaxMileage == null)
                Key.MaxMileage = int.MaxValue;
            if (Key.MinMileage == null)
                Key.MinMileage = 0;
            
            filteredCars = CarsList.FindAll(c => (c.Year > Key.MinYear) 
                                              && (c.Year < Key.MaxYear)
                                              && (c.Price > Key.MinPrice)
                                              && (c.Price < Key.MaxPrice)
                                              && (c.Mileage < Key.MaxMileage)
                                              && (c.Mileage > Key.MinMileage));

            if (Key.Model != null)
                filteredCars = filteredCars.FindAll(c => c.Model == Key.Model);
            if (Key.EngineCapacity != null)
                filteredCars = filteredCars.FindAll(c => c.EngineCapacity == Key.EngineCapacity);
            if (Key.Brand != null)
                filteredCars = filteredCars.FindAll(c => c.Brand == Key.Brand);

            if (filteredCars.Count == 0)
                return RedirectToAction("NotFound");

            return RedirectToAction("Search");
        }

        public IActionResult NotFound() => View(Key);
        public IActionResult Search() => View(filteredCars);
    }
}
