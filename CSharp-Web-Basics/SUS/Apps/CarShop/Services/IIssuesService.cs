using CarShop.ViewModels.Issues;

namespace CarShop.Services
{
    public interface IIssuesService
    {
        CarWithIssueViewModel GetCarIssues(string carId);

        void AddIssueToCar(string carId,string description);

        void FixIssue(string carId,string issueI);

        void DeleteIssue(string carId, string issueI);
    }
}
