using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewTracking.Startup))]
namespace NewTracking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
