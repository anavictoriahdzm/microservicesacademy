using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppShoesMVC2.Startup))]
namespace AppShoesMVC2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
