using SharedTrip.Models;
using SharedTrip.Repository;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services.TripsService
{
    public class TripsService : ITripsService
    {
        private readonly IRepository repository;

        public TripsService(IRepository repository)
        {
            this.repository = repository;
        }

        public void Add(TripInputModel model)
        {
            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                Description = model.Description,
                DepartureTime = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                ImagePath = model.ImagePath,
                Seats = model.Seats,
            };

            this.repository.AddAsync(trip);
            this.repository.SaveChangesAsync();
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            var trip = this.repository
                .All<Trip>()
                .FirstOrDefault(x => x.Id == tripId);

            trip.Seats -= 1;

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId,
            };

            this.repository.AddAsync(userTrip);
            this.repository.SaveChangesAsync();
        }

        public IEnumerable<TripViewModel> All()
            => this.repository.All<Trip>()
            .Select(x => new TripViewModel
            {
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                Description = x.Description,
                Id = x.Id,
                Seats = x.Seats,
                ImagePath = x.ImagePath,
            })
            .AsEnumerable();

        public TripViewModel GetByid(string id)
            => this.repository
            .All<Trip>()
            .Where(x => x.Id == id)
            .Select(x => new TripViewModel
            {
                Seats = x.Seats,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                Id = x.Id,
                DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                Description = x.Description,
                ImagePath = x.ImagePath,
            })
            .FirstOrDefault();

        public bool HasFreeSeats(string tripId)
            => this.repository
            .All<Trip>()
            .Where(x => x.Id == tripId)
            .Any(x => x.Seats > 0);

        public bool IsAlreadyInTrip(string tripId, string userId)
            => this.repository
            .All<UserTrip>()
            .Any(x => x.TripId == tripId && x.UserId == userId);
    }
}
