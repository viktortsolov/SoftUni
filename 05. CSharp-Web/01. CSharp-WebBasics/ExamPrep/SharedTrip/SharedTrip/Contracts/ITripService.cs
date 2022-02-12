using SharedTrip.Models;
using SharedTrip.Models.Trips;
using System.Collections.Generic;

namespace SharedTrip.Contracts
{
    public interface ITripService
    {
        (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(AddTripViewModel model);
        void AddTrip(AddTripViewModel model);
        IEnumerable<TripListViewModel> GetAllTrips();
        TripDetailsViewModel GetTripDetails(string tripId);
        void AddUserToTrip(string tripId, string userId);
    }
}
