using CarShop.Data.Models;
using CarShop.ViewModels.Cars;
using System.Collections.Generic;

namespace CarShop.Services
{
    public interface ICarsService
    {
        IEnumerable<CarViewModel> GetUserCars(string userId);

        public string AddCar(string model, int year, string imageUrl, string plateNumber,string userId);

        public bool IsPlateNumberAvailable(string plateNumber);
    }
}
