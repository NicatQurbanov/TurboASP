using System.Reflection;
using TurboASP.Models;


namespace TurboASP.Repository
{
    public class CarRepository
    {
        public static List<Car> Cars { get; set; } = new List<Car>()
        {
            new Car(){Brand = "BMW", Model = "i1900", EngineCapacity = 3.5m, Year = 2018, Price = 25000, Mileage = 90000},
            new Car(){Brand = "Mercedes-Benz", Model = "i2100", EngineCapacity = 2.7m, Year = 2019, Price = 27000, Mileage = 65000},
            new Car(){Brand = "Toyota", Model = "i3000", EngineCapacity = 5m, Year = 2017, Price = 18500, Mileage = 120000},
            new Car(){Brand = "Mercedes-Benz", Model = "i1900", EngineCapacity = 3.5m, Year = 2020, Price = 16000, Mileage = 45000},
            new Car(){Brand = "BMW", Model = "i2100", EngineCapacity = 2.7m, Year = 2019, Price = 21000, Mileage = 70000},
            new Car(){Brand = "Toyota", Model = "i1900", EngineCapacity = 5m, Year = 2018, Price = 34000, Mileage = 80000},
        };

        public void AddCar(Car car) => Cars.Add(car);

        public Car? GetCar(int id ) => Cars.FirstOrDefault(c => c.Id == id);
    }
}
