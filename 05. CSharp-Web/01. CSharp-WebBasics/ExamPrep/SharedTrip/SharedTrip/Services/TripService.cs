using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using SharedTrip.Models.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly IRepository repo;

        public TripService(IRepository _repo)
        {
            repo = _repo;
        }

        public void AddTrip(AddTripViewModel model)
        {
            Trip trip = new Trip()
            {
                Description = model.Description,
                EndPoint = model.EndPoint,
                StartPoint = model.StartPoint,
                ImagePath = model.ImagePath,
                Seats = model.Seats
            };

            DateTime date;
            DateTime.TryParseExact(
                model.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date);

            trip.DepartureTime = date;

            repo.Add(trip);
            repo.SaveChanges();
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            var user = repo.All<User>()
                .FirstOrDefault(u => u.Id == userId);

            var trip = repo.All<Trip>()
                .FirstOrDefault(t => t.Id == tripId);

            if (user == null || trip == null)
            {
                throw new ArgumentException("USer or trip not found!");
            }

            user.UserTrips.Add(new UserTrip()
            {
                TripId = tripId,
                UserId = userId,
                Trip = trip,
                User = user
            });

            repo.SaveChanges();
        }

        public IEnumerable<TripListViewModel> GetAllTrips()
        {
            return repo.All<Trip>()
                .Select(t => new TripListViewModel()
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats
                });
        }

        public TripDetailsViewModel GetTripDetails(string tripId)
        {
            return repo.All<Trip>()
                .Where(t => t.Id == tripId)
                .Select(x => new TripDetailsViewModel
                {
                    Id = x.Id,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Description = x.Description,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    ImagePath = x.ImagePath,
                    Seats = x.Seats
                }).FirstOrDefault();
        }

        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(AddTripViewModel model)
        {
            bool isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();
            DateTime date;

            if (string.IsNullOrWhiteSpace(model.StartPoint) ||
                string.IsNullOrWhiteSpace(model.EndPoint))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Start or end point are required!"));
            }

            if (!DateTime.TryParseExact(
                model.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Departure time required!"));
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Seats must be in range 2-6!"));
            }

            if (model.Description.Length > 80 ||
                string.IsNullOrWhiteSpace(model.Description))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Description is required and max length is 80!"));
            }

            return (isValid, errors);
        }
    }
}