namespace SharedTrip.Services
{
    using SharedTrip.Data;
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Globalization;

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
    }
}
