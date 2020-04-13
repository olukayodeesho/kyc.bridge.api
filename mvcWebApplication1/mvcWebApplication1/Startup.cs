using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcWebApplication1.Startup))]
namespace mvcWebApplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
