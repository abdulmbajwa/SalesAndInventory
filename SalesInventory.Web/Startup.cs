using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalesInventory.Web.Startup))]
namespace SalesInventory.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
