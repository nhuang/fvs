using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FestivalScheduler.Startup))]
namespace FestivalScheduler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
