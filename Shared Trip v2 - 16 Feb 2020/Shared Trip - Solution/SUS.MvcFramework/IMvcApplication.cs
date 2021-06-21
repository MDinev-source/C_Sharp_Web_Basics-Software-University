using SUS.HTTP;
using System.Collections.Generic;

namespace SUS.MvcFramework
{
    public interface IMvcApplication
    {
        void Configure(List<Route> routeTable);
        void ConfigureServices(IServiceCollection serviceCollection);

    }
}
