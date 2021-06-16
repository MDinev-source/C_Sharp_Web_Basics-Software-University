﻿namespace SharedTrip.Controllers
{
    using SharedTrip.Services;
    using SharedTrip.ViewModels.Users;
    using SIS.HTTP;
    using SIS.MvcFramework;
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            var userId = this.usersService.GetUserId(input.Username, input.Password);

            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/Trips/All");
            }


            return this.Redirect("/Users/Login");
        }


        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (input.Username.Length < 5 && input.Username.Length > 20)
            {
                return Redirect("/Users/Register");
            }

            if (input.Password.Length < 6 && input.Password.Length > 20)
            {
                return Redirect("/Users/Register");
            }

            if (string.IsNullOrWhiteSpace(input.Email))
            {
                return Redirect("/Users/Register");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return Redirect("/Users/Register");
            }

            if (this.usersService.UsernameExists(input.Username))
            {
                return Redirect("/Users/Register");
            }

            if (this.usersService.EmailExists(input.Email))
            {
                return Redirect("/Users/Register");
            }

            this.usersService.Register(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();

            return this.Redirect("/");
        }
    }
}