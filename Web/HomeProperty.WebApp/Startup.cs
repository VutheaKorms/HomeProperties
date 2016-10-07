using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeProperty.WebApp.Startup))]
namespace HomeProperty.WebApp {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
