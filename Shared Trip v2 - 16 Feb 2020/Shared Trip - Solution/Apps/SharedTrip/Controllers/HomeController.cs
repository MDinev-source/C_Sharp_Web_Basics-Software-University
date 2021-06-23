namespace SharedTrip.App.Controllers
{
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            return this.View();
        }

        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            return this.View("Index");
        }
    }
}