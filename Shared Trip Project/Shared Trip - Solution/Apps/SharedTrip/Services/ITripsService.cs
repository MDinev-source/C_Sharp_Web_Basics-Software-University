namespace SharedTrip.Services
{
    using SharedTrip.ViewModels.Trips;
    public interface ITripsService
    {
        void Create(AddTripInputModel trip);
    }
}
