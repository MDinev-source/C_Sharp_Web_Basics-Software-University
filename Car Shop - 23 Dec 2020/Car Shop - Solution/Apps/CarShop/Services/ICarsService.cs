namespace CarShop.Services
{
    using CarShop.ViewModels.Cars;
    using System.Collections.Generic;
    public interface ICarsService
    {
        IEnumerable<AllCarsInputModel> All();
        void Create(CreateCarInputModel input);
    }
}
