namespace TurboASP.Models
{
    public class SearchKeys
    {
        public string? Brand { get; set; }

        public string? Model { get; set; }

        public decimal? MinPrice { get; set; } 

        public decimal? MaxPrice { get; set; } 

        public int? MaxMileage { get; set; } 

        public int? MinMileage { get; set; }

        public int? MinYear { get; set; } 

        public int? MaxYear { get; set; } 

        public decimal? EngineCapacity { get; set; } 
    }
}
