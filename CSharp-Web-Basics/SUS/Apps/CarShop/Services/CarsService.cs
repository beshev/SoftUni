using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Cars;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.Services
{
    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext db;

        public CarsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string AddCar(string model, int year, string imageUrl, string plateNumber, string userId)
        {
            var car = new Car()
            {
                Model = model,
                Year = year,
                PictureUrl = imageUrl,
                PlateNumber = plateNumber,
                OwnerId = userId,
            };

            db.Cars.Add(car);
            db.SaveChanges();

            return car.Id;
        }

        public IEnumerable<CarViewModel> GetUserCars(string userId)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Id == userId);

            if (user.IsMechanic)
            {
                return db.Cars.Where(x => x.Issues.Any(i => i.IsFixed == false)).Select(x => new CarViewModel
                {
                    CarId = x.Id,
                    Model = x.Model,
                    PlateNumber = x.PlateNumber,
                    ImageUrl = x.PictureUrl,
                    RemainingIssues = x.Issues.Count(x => x.IsFixed == false),
                    FixedIssues = x.Issues.Count(x => x.IsFixed == true)
                })
                .ToList();
            }
            else
            {
                return db.Cars.Where(x => x.OwnerId == userId).Select(x => new CarViewModel
                {
                    CarId = x.Id,
                    Model = x.Model,
                    PlateNumber = x.PlateNumber,
                    ImageUrl = x.PictureUrl,
                    RemainingIssues = x.Issues.Count(x => x.IsFixed == false),
                    FixedIssues = x.Issues.Count(x => x.IsFixed == true)
                })
                .ToList();
            }
        }

        public bool IsPlateNumberAvailable(string plateNumber)
        {
            return !db.Cars.Any(x => x.PlateNumber == plateNumber);
        }
    }
}
