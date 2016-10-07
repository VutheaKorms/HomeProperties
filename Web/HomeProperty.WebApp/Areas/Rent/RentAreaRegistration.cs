using HomeProperty.WebApp.Areas.Rent.Infranstructure;
using System.Web.Mvc;
using System.Web.Optimization;

namespace HomeProperty.WebApp.Areas.Rent {

    public class RentAreaRegistration : AreaRegistration {

        public override string AreaName {
            get {
                return "Rent";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "Rent_default",
                "Rent/{controller}/{action}/{id}",
                new { controller = "Rent", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "HomeProperty.WebApp.Areas.Rent.Controllers" }
            );

            RentBundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}