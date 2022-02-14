namespace SharedTrip.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SharedTrip.Services.TripsService;
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Globalization;

    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(
            Request request,
            ITripsService tripsService)
            : base(request)
        {
            this.tripsService = tripsService;
        }

        [Authorize]
        public Response All()
        {
            var viewModel = this.tripsService.All();

            return this.View(viewModel);
        }

        [Authorize]
        public Response Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public Response Add(TripInputModel model)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(model.StartPoint)
                || string.IsNullOrWhiteSpace(model.EndPoint)
                || string.IsNullOrWhiteSpace(model.DepartureTime)
                || string.IsNullOrWhiteSpace(model.Description))
            {
                isValid = false;
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                isValid = false;
            }

            if (model.Description.Length > 80)
            {
                isValid = false;
            }

            var isValidDate = DateTime.TryParseExact(
                    model.DepartureTime,
                    "dd.MM.yyyy HH:mm",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out _);

            if (isValidDate == false)
            {
                isValid = false;
            }

            if (isValid == false)
            {
                return this.View();
            }

            this.tripsService.Add(model);

            return this.Redirect("All");
        }

        [Authorize]
        public Response Details(string tripId)
        {
            var viewModel = this.tripsService.GetByid(tripId);

            return this.View(viewModel);
        }

        [Authorize]
        public Response AddUserToTrip(string tripId)
        {
            var userId = this.User.Id;

            if (
                this.tripsService.IsAlreadyInTrip(tripId, userId)
                || this.tripsService.HasFreeSeats(tripId) == false)
            {
                return this.Redirect($"Details?tripId={tripId}");
            }

            this.tripsService.AddUserToTrip(tripId, userId);

            return this.Redirect("All");
        }
    }
}
