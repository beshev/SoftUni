using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Issues;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CarShop.Services
{
    public class IssueService : IIssuesService
    {
        private readonly ApplicationDbContext db;

        public IssueService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddIssueToCar(string carId, string description)
        {
            var car = GetCarById(carId);

            car.Issues.Add(new Issue
            {
                Description = description,
                CarId = carId,
                IsFixed = false,
            });

            db.SaveChanges();
        }

        public void DeleteIssue(string carId, string issueId)
        {
            var car = GetCarById(carId);

            var issue = car.Issues.FirstOrDefault(x => x.Id == issueId);

            car.Issues.Remove(issue);
            db.SaveChanges();
        }

        public void FixIssue(string carId, string issueId)
        {
            var car = GetCarById(carId);

            car.Issues.FirstOrDefault(x => x.Id == issueId).IsFixed = true;
            db.SaveChanges();
        }

        public CarWithIssueViewModel GetCarIssues(string carId)
        {
            var car = this.GetCarById(carId);

            return new CarWithIssueViewModel
            {
                CarModel = car.Model,
                CarId = car.Id,
                Issues = car.Issues.Select(c => new IssueViewModel
                {
                    CarId = c.CarId,
                    IssueId = c.Id,
                    Description = c.Description,
                    IsFixted = c.IsFixed ? "Yes!" : "Not yet",
                })
                 .ToArray()
            };
        }

        private Car GetCarById(string carId)
        {
            return db.Cars.Include(x => x.Issues)
                .FirstOrDefault(x => x.Id == carId);
        }
    }
}
