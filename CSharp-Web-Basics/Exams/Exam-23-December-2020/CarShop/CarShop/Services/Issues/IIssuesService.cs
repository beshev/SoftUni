using CarShop.ViewModels.Issues;

namespace CarShop.Services.Issues
{
    public interface IIssuesService
    {
        public void Add(IssueInputModel model);

        public void Fix(string issueId);

        public void Delete(string issuesId);
    }
}
