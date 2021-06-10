namespace SharedTrip.Services
{
    using SharedTrip.Data;
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;
        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(AddTripInputModel trip)
        {
            var dbTrip = new Trip
            {
                DepartureTime = DateTime.ParseExact(trip.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Description = trip.Description,
                EndPoint = trip.EndPoint,
                ImagePath = trip.ImagePath,
                Seats = (byte)trip.Seats,
                StartPoint = trip.StartPoint
            };

            this.db.Trips.Add(dbTrip);
            this.db.SaveChanges();
        }

        public IEnumerable<TripViewModel> GetAll()
        {
            var trips = this.db.Trips.Select(x => new TripViewModel
            {
                DepartureTime = x.DepartureTime,
                EndPoint = x.EndPoint,
                StartPoint = x.StartPoint,
                Id = x.Id,
                Seats = x.Seats,
                UsedSeats = x.UserTrips.Count()

            }).ToList();

            return trips;
        }

        public TripDetailsViewModel GetDetails(string id)
        {
            var trip = this.db.Trips.Where(x => x.Id == id)
                .Select(x => new TripDetailsViewModel
                {
                    DepartureTime = x.DepartureTime,
                    Description = x.Description,
                    EndPoint = x.EndPoint,
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    Seats = x.Seats,
                    StartPoint = x.StartPoint,
                    UsedSeats = x.UserTrips.Count()
                })
                .FirstOrDefault();

            return trip;
        }
    }
}
