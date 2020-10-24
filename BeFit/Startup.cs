using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeFit.Startup))]
namespace BeFit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
