namespace TurboASP.Models
{
    public class Car
    {
        static int id = 0;

        public int Id { get; set; } = id++;

        public string Brand { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int Mileage { get; set; }

        public decimal EngineCapacity { get; set; }

        public string Year { get; set; }

        public string Date { get; set; } = DateTime.Today.ToString("dd/MM/yyyy");

        public Car()
        {
            this.Id = id++;
        }

    }
}
