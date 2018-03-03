using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab4WebApplication.Startup))]
namespace Lab4WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
