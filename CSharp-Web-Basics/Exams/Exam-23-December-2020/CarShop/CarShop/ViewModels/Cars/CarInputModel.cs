using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels.Cars
{
    public class CarInputModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Model { get; set; }
        
        [Required]
        [RegularExpression(@"[A-Z]{2}\d{4}[A-Z]{2}")]
        public string PlateNumber { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
