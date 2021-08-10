namespace CarShop.ViewModels.Issues
{
    public class CarWithIssueViewModel
    {

        public string CarModel { get; set; }

        public string CarId { get; set; }

        public IssueViewModel[] Issues { get; set; }
    }
}
