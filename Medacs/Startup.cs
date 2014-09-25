using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Medacs.Startup))]
namespace Medacs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
