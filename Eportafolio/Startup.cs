using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eportafolio.Startup))]
namespace Eportafolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
