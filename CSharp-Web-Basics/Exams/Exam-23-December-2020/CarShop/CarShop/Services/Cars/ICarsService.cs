using CarShop.ViewModels.Cars;

namespace CarShop.Services.Cars
{
    public interface ICarsService
    {
        public IEnumerable<CarViewModel> GetAll(string userId = null);

        public CarIssuesViewModel GetCarWithIssues(string carId);

        public void Add(CarInputModel model, string userId);
    }
}
