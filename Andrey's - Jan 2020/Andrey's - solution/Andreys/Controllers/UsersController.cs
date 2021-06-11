namespace Andreys.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            return this.View();
        }
    }
}
