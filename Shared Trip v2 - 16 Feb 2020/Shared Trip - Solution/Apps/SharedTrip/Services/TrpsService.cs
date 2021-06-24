namespace SharedTrip.Services
{
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class TrpsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TrpsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(AddTripViewModel model)
        {
            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = DateTime.Parse(model.DepartureTime),
                Seats = model.Seats,
                Description = model.Description,
                ImagePath = model.CarImage
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
                ImagePath = x.ImagePath,
                DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                Description = x.Description,
                Seats = x.Seats
            }).ToList();

        }
    }
}
