namespace CarShop.Services
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.ViewModels.Cars;
    using System.Collections.Generic;
    using System.Linq;

    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext db;

        public CarsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<AllCarsInputModel> All()
        {
            var cars = this.db.Cars
                .Select(x => new AllCarsInputModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    Year = x.Year,
                    PictureUrl = x.PictureUrl,
                    PlateNumber = x.PlateNumber,
                    RemainingIssues = x.Issues.Where(x => !x.IsFixed).Count(),
                    FixedIssues = x.Issues.Where(x => x.IsFixed).Count()
                }).ToList();

            return cars;
        }

        public void Create(CreateCarInputModel input)
        {
            var car = new Car
            {
                Model=input.Model,
                Year=input.Year,
                PictureUrl=input.Image,
                PlateNumber=input.PlateNumber,
                OwnerId=input.OwnerId
            };

            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }
    }
}
