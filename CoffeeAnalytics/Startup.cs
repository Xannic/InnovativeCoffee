using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoffeeAnalytics.Startup))]
namespace CoffeeAnalytics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
