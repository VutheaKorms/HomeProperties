using HomeProperty.WebApp.Areas.Buy.Infranstructure;
using System.Web.Mvc;
using System.Web.Optimization;

namespace HomeProperty.WebApp.Areas.Buy {

    public class BuyAreaRegistration : AreaRegistration {

        public override string AreaName {
            get {
                return "Buy";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "Buy_default",
                "Buy/{controller}/{action}/{id}",
                new { controller = "Buy", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "HomeProperty.WebApp.Areas.Buy.Controllers" }
            );

            BuyBundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}