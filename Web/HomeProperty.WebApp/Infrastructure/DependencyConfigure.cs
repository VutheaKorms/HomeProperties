using Autofac;
using System.Web.Mvc;

namespace HomeProperty.WebApp.Infrastructure {
    public class DependencyConfigure {

        public static void Initialize() {
            var builder = new ContainerBuilder();
            DependencyResolver.SetResolver(
                new Dependency(RegisterServices(builder))
                );
        }

        private static IContainer RegisterServices(ContainerBuilder builder) {

            //builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly).PropertiesAutowired();
            //builder.RegisterType<AppServiceModel>().As<IAppServiceModel>().InstancePerLifetimeScope();
            //builder.RegisterType<VehicleServiceModel>().As<IVehicleServiceModel>().InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}