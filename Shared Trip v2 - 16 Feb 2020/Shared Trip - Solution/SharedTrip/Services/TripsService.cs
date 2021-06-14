namespace SharedTrip.Services
{
    using SharedTrip.Models;
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Add(string startPoint, string endPoint, DateTime departureTime, int seats, string description, string imagePath)
        {
            var trip = new Trip
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                DepartureTime = departureTime,
                Seats = seats,
                Description = description,
                ImagePath = imagePath
            };

            this.db.Trips.Add(trip);
            db.SaveChanges();
        }

        public bool AddUserToTrip(string tripId, string userId)
        {
            var targetTrip = this.db.Trips.FirstOrDefault(x => x.Id == tripId);

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId
            };

            if (!this.db.UserTrips.Any(x => x.TripId == userTrip.TripId && x.UserId == userTrip.UserId)
                && targetTrip.Seats > 0)
            {
                targetTrip.Seats -= 1;
                targetTrip.UserTrips.Add(userTrip);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<AllTripsViewModel> GetAll()
        {
            return this.db.Trips.Select(x => new AllTripsViewModel
            {
                DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                EndPoint = x.EndPoint,
                Seats = x.Seats,
                StartPoint = x.StartPoint,
                Id = x.Id
            })
                .ToArray();
        }

        public GetTripViewModel GetTrip(string id)
        {
            return this.db.Trips.Where(x => x.Id == id).Select(t => new GetTripViewModel
            {
                Id = t.Id,
                DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                Description = t.Description,
                EndPoint = t.EndPoint,
                ImagePath = t.ImagePath,
                Seats = t.Seats,
                StartPoint = t.StartPoint
            })
         .FirstOrDefault();
        }
    }
}
