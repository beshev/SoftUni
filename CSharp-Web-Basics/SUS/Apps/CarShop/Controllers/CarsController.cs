using CarShop.Services;
using CarShop.ViewModels.Cars;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Text.RegularExpressions;

namespace CarShop.Controllers
{
    class CarsController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IUsersService userService;

        public CarsController(ICarsService carsService, IUsersService userService)
        {
            this.carsService = carsService;
            this.userService = userService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("Log in to continue.");
            }

            var userId = this.GetUserId();

            var userCars = carsService.GetUserCars(userId);

            return this.View(userCars);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("Log in to continue.");
            }

            if (userService.IsUserMechanic(this.GetUserId()))
            {
                return this.Error("Only the clients can add cars..");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(string model, int year, string image, string plateNumber)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("Log in to continue.");
            }

            if (string.IsNullOrWhiteSpace(model) || model.Length < 5 || model.Length > 20)
            {
                return this.Error("The model should be between 5 and 20 characters long.");
            }

            if (!carsService.IsPlateNumberAvailable(plateNumber))
            {
                return this.Error("The platenumber already taken.");
            }

            if (year <= 0)
            {
                return this.Error("The year should be greater than 0.");
            }

            if (!Uri.TryCreate(image, UriKind.Absolute, out _))
            {
                return this.Error("Image url should be valid.");
            }

            if (!Regex.IsMatch(plateNumber, @"^[A-Z]{2}\d{4}[A-Z]{2}$"))
            {
                return this.Error("The plate number should be 2 Capital letters, followed by 4 digits, followed by 2 Capital English letters.");
            }

            var userId = this.GetUserId();
            var carId = carsService.AddCar(model, year, image, plateNumber, userId);

            return this.Redirect("/Cars/All");
        }
    }
}
