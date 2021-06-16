namespace Musaca.App
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Data;
    using Services;
    using Services.Contracts;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
         
        }

        public void Configure(IList<Route> routeTable)
        {
            var data = new MusacaDbContext();
            data.Database.Migrate();
        }
    }
}
