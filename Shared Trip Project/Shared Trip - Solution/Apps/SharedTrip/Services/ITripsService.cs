namespace SharedTrip.Services
{
    using SharedTrip.ViewModels.Trips;
    using System.Collections.Generic;

    public interface ITripsService
    {
        void Create(AddTripInputModel trip);
        IEnumerable<TripViewModel> GetAll();
    }
}
