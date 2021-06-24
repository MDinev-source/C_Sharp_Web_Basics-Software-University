namespace SharedTrip.Services
{
    using SharedTrip.ViewModels.Trips;
    using System.Collections.Generic;

    public interface ITripsService
    {
        ICollection<AllTripsViewModel> All();
        public void Add(AddTripViewModel model);
    }
}
