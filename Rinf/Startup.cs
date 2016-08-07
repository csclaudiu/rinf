using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rinf.Startup))]
namespace Rinf
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
