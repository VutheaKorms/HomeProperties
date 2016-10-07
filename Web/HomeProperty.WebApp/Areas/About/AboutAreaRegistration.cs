using HomeProperty.WebApp.Areas.About.Infranstructure;
using System.Web.Mvc;
using System.Web.Optimization;

namespace HomeProperty.WebApp.Areas.About {

    public class AboutAreaRegistration : AreaRegistration {

        public override string AreaName {
            get {
                return "About";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "About_default",
                "About/{controller}/{action}/{id}",
                new { controller = "About", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "HomeProperty.WebApp.Areas.About.Controllers" }
            );

            AboutBundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}