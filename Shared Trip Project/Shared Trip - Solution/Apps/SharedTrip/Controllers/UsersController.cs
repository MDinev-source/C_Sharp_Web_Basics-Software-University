namespace SharedTrip.Controllers
{
    using SharedTrip.ViewModels.Users;
    using SUS.HTTP;
    using SUS.MvcFramework;
    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {

        }
        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register (RegisterInputModel input)
        {

        }
    }
}
