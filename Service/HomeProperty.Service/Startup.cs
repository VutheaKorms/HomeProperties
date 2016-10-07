using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HomeProperty.Service.Startup))]

namespace HomeProperty.Service {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
