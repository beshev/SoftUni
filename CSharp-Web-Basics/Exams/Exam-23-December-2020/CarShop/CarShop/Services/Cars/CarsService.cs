using BasicWebServer.Server.Attributes;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels.Cars;
using CarShop.ViewModels.Issues;

namespace CarShop.Services.Cars
{
    public class CarsService : ICarsService
    {
        private readonly IRepository repo;

        public CarsService(IRepository repo)
        {
            this.repo = repo;
        }

        public void Add(CarInputModel model, string userId)
        {
            var car = new Car
            {
                Model = model.Model,
                PlateNumber = model.PlateNumber,
                PictureUrl = model.ImageUrl,
                Year = model.Year,
                OwnerId = userId
            };

            this.repo.Add(car);
            this.repo.SaveChanges();
        }

        public IEnumerable<CarViewModel> GetAll(string userId = null)
        {
            var query = this.repo
                .All<Car>();

            if (string.IsNullOrWhiteSpace(userId) == false)
            {
                // Is Client
                query = query
                    .Where(x => x.OwnerId == userId);
            }
            else
            {
                // Is Mechanic
                query = query
                    .Where(x => x.Issues.Any(i => i.IsFixed == false));
            }

            return query
                .Select(x => new CarViewModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    PlateNumber = x.PlateNumber,
                    PictureUrl = x.PictureUrl,
                    RemainingIssues = x.Issues.Count(x => x.IsFixed == false),
                    FixedIssues = x.Issues.Count(x => x.IsFixed),
                })
                .AsEnumerable();
        }

        public CarIssuesViewModel GetCarWithIssues(string carId)
            => this.repo
            .All<Car>()
            .Where(x => x.Id == carId)
            .Select(x => new CarIssuesViewModel
            {
                CarId = x.Id,
                Model = x.Model,
                Year = x.Year,
                Issues = x.Issues
                .Select(i => new IssueViewModel
                {
                    Id = i.Id,
                    Description = i.Description,
                    IsFixed = i.IsFixed ? "Yes" : "Not yet",
                })
                .AsEnumerable()
            })
            .FirstOrDefault();
    }
}
