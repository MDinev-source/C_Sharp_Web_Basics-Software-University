namespace SharedTrip.Services
{
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.ViewModels.Trips;
    using System.Collections.Generic;
    using System.Linq;
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(AddTripViewModel model)
        {
            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = model.DepartureTime,
                Seats = model.Seats,
                Description = model.Description,
                ImagePath = model.ImagePath
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public ICollection<AllTripsViewModel> All()
        {
            return this.db.Trips.Select(x => new AllTripsViewModel
            {
                Id = x.Id,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                Description = x.Description,
                Seats = x.Seats
            }).ToList();

        }

        public TripDetailsViewModel TripDetails(string id)
        {
            return this.db.Trips
                .Where(t => t.Id == id)
                .Select(x => new TripDetailsViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    ImagePath = x.ImagePath,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Description = x.Description,
                    Seats = x.Seats
                }).FirstOrDefault();
        }

        public bool AddUserToTrip(string tripId, string userId)
        {
            var targetTrip = this.db.Trips.FirstOrDefault(x => x.Id == tripId);
            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId
            };

            if (!this.db.UserTrips.Any(x => x.TripId == userTrip.TripId && x.UserId == userTrip.UserId) && targetTrip.Seats > 0)
            {
                targetTrip.Seats -= 1;
                targetTrip.UserTrips.Add(userTrip);
                db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
