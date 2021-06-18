namespace SharedTrip.Controllers
{
    using SharedTrip.Services;
    using SharedTrip.ViewModels.Trips;
    using SIS.HTTP;
    using SIS.MvcFramework;
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripViewModels trip)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(trip.StartPoint) || string.IsNullOrWhiteSpace(trip.EndPoint))
            {
                return this.Redirect("/Trips/All");
            }

            if (trip.Seats < 2 || trip.Seats > 6)
            {
                return this.Redirect("/Trips/All");
            }

            if (trip.Description.Length > 80)
            {
                return this.Redirect("/Trips/All");
            }

            this.tripsService.Add(trip.StartPoint, trip.EndPoint, trip.DepartureTime, trip.Seats, trip.Description, trip.ImagePath);
            return this.Redirect("/Trips/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/User/Login");
            }

            return this.View(this.tripsService.GetAll(), "All");
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trip = this.tripsService.GetTrip(tripId);
            return this.View(trip, "Details");
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.Request.SessionData["UserId"];
            var isAdded = this.tripsService.AddUserToTrip(tripId, userId);

            if (isAdded)
            {
                return this.Redirect("/Trips/All");
            }

            return this.Redirect($"/Trips/Details?tripId={tripId}");
        }
    }
}
