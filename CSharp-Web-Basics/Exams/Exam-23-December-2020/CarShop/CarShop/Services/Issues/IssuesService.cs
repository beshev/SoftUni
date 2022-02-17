using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels.Issues;

namespace CarShop.Services.Issues
{
    public class IssuesService : IIssuesService
    {
        private readonly IRepository repo;

        public IssuesService(IRepository repo)
        {
            this.repo = repo;
        }

        public void Add(IssueInputModel model)
        {
            var issue = new Issue
            {
                Description = model.Description,
                CarId = model.CarId,
            };

            this.repo.Add(issue);
            this.repo.SaveChanges();
        }

        public void Delete(string issueId)
        {
            var issue = this.repo
                .All<Issue>()
                .FirstOrDefault(x => x.Id == issueId);

            this.repo.Delete(issue);

            this.repo.SaveChanges();
        }

        public void Fix(string issueId)
        {
            var issue = this.repo
                  .All<Issue>()
                  .FirstOrDefault(x => x.Id == issueId);

            issue.IsFixed = true;

            this.repo.SaveChanges();
        }
    }
}
