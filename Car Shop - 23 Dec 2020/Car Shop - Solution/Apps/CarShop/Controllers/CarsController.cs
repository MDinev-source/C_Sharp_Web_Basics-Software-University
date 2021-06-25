namespace CarShop.Controllers
{
    using CarShop.Services;
    using CarShop.ViewModels.Cars;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System;
    using System.Text.RegularExpressions;

    public class CarsController:Controller
    {
        private readonly ICarsService carsService;
        private readonly IUsersService usersService;

        public CarsController(ICarsService carsService, IUsersService usersService)
        {
            this.carsService = carsService;
            this.usersService = usersService;
        }

       public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            var cars = carsService.All();

            return this.View(cars);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            if (this.usersService.IsUserMechanic(this.GetUserId()))
            {
                return this.Error("Mechanics can't add car.");
            }


            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CreateCarInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }
      
            if (input.Model.Length < 5 || input.Model.Length > 20 || string.IsNullOrEmpty(input.Model))
            {
                return this.Error("Invalid model. The model should be between 5 and 20 characters.");
            }

            if (string.IsNullOrWhiteSpace(input.Image))
            {
                return this.Error("The image is required!");
            }

            if (!Uri.TryCreate(input.Image, UriKind.Absolute, out _))
            {
                return this.Error("Image url should be valid.");
            }

            if (!Regex.IsMatch(input.PlateNumber, @"^[A-Z]{2}[0-9]{4}[A-Z]{2}"))
            {
                return this.Error("Invalid plate number.");
            }

            input.OwnerId = this.GetUserId();

            carsService.Create(input);

            return this.Redirect("/Cars/All");
        }
    }
}
