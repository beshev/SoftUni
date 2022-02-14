using SharedTrip.ViewModels.Trips;
using System.Collections.Generic;

namespace SharedTrip.Services.TripsService
{
    public interface ITripsService
    {
        public void Add(TripInputModel model);

        public TripViewModel GetByid(string id);

        public IEnumerable<TripViewModel> All();

        public bool HasFreeSeats(string tripId);

        public void AddUserToTrip(string tripId, string userId);

        public bool IsAlreadyInTrip(string tripId, string userId);
    }
}
