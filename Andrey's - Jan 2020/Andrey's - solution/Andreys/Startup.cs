namespace Andreys.App
{
    using System.Collections.Generic;

    using Data;

    using SUS.MvcFramework;
    using SUS.HTTP;
    using Andreys.Services;

    public class Startup : IMvcApplication
    {
 
        public void Configure(List<Route> routeTable)
        {
            using (var db = new AndreysDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProductsService, ProductsService>();
        }
    }
}
