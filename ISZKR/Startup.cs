using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ISZKR.Startup))]
namespace ISZKR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
