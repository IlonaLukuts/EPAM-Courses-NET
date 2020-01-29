using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SellingsWeb.Startup))]
namespace SellingsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
