using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PortalCompras.Startup))]
namespace PortalCompras
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
