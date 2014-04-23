using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrackYourBudget.Startup))]
namespace TrackYourBudget
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
