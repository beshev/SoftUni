using CarShop.ViewModels.Issues;

namespace CarShop.ViewModels.Cars
{
    public class CarIssuesViewModel
    {
        public string CarId { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public bool IsAuthenticated { get; set; }

        public IEnumerable<IssueViewModel> Issues { get; set; }
    }
}
