

using System.ComponentModel.DataAnnotations;

namespace TurboASP.Models
{
    public class Car
    {
        static int id = 0;

        public int Views { get; set; } = 0;
        public int? Id { get; set; } = id++;

        [Required(ErrorMessage = "The brand is required to enter")]

        public string? Brand { get; set; }

        [Required(ErrorMessage = "The model is required to enter")]
        public string? Model { get; set; }

        [Required(ErrorMessage = "The price is required to enter")]
        [RegularExpression(@"^(?:[1-9]\d{4,8}|1000000000)$",ErrorMessage = "The price should be between 10000 and 1000000000")]
        public decimal? Price { get; set; }

        public int? Mileage { get; set; }

        [Required(ErrorMessage = "The engine capacity is required to enter")]
        public decimal? EngineCapacity { get; set; }

        [RegularExpression(@"^(198[0-9]|199[0-9]|200[0-9]|201[0-9]|202[0-6])$",ErrorMessage = "The year should be between 1980 and 2026")]
        public int? Year { get; set; }

        public string Date { get; set; } = DateTime.Today.ToString("dd/MM/yyyy");

        public Car()
        {
            this.Id = id++;
        }

    }
}
