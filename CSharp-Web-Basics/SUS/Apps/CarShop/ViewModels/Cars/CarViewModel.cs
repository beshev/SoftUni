namespace CarShop.ViewModels.Cars
{
    public class CarViewModel
    {
        public string CarId { get; set; }

        public string Model { get; set; }

        public string PlateNumber { get; set; }

        public string ImageUrl { get; set; }

        public int RemainingIssues { get; set; }

        public int FixedIssues { get; set; }
    }
}
