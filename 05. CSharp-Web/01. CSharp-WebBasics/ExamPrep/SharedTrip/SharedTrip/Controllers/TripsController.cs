using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.Models;
using SharedTrip.Models.Trips;
using System;
using System.Collections.Generic;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService tripService;

        public TripsController(
            Request request,
            ITripService _tripService)
            : base(request)
        {
            tripService = _tripService;
        }

        [Authorize]
        public Response Add()
            => View();

        [HttpPost]
        [Authorize]
        public Response Add(AddTripViewModel model)
        {
            var (isValid, errors) = tripService.ValidateModel(model);

            if (!isValid)
            {
                return View(errors, "/Error");
            }

            try
            {
                tripService.AddTrip(model);
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected Error") }, "/Error");
            }

            return Redirect("/Trips/All");
        }

        [Authorize]
        public Response All()
        {
            IEnumerable<TripListViewModel> trips = tripService.GetAllTrips();

            return View(trips);
        }

        [Authorize]
        public Response Details(string tripId)
        {
            TripDetailsViewModel tripDetailsViewModel = tripService.GetTripDetails(tripId);

            return View(tripDetailsViewModel);
        }

        public Response AddUserToTrip(string tripId)
        {
            try
            {
                tripService.AddUserToTrip(tripId, User.Id);
            }
            catch (ArgumentException aex)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel(aex.Message) }, "/Error");
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected Error") }, "/Error");
            }

            return Redirect("/Trips/All");
        }
    }
}
