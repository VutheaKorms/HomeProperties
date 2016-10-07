using HomeProperty.WebApp.Areas.Sell.Infranstructure;
using System.Web.Mvc;
using System.Web.Optimization;

namespace HomeProperty.WebApp.Areas.Sell {
    public class SellAreaRegistration : AreaRegistration {

        public override string AreaName {
            get {
                return "Sell";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "Sell_default",
                "Sell/{controller}/{action}/{id}",
                new { controller = "Sell", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "HomeProperty.WebApp.Areas.Sell.Controllers" }
            );

            SellBundleConfig.RegisterBundles(BundleTable.Bundles);
        }

    }
}