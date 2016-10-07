using HomeProperty.WebApp.Areas.Contact.Infranstructure;
using System.Web.Mvc;
using System.Web.Optimization;

namespace HomeProperty.WebApp.Areas.Contact {

    public class ContctaAreaRegistration : AreaRegistration {

        public override string AreaName {
            get {
                return "Contact";
            }
        }


        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "Contact_default",
                "Contact/{controller}/{action}/{id}",
                new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "HomeProperty.WebApp.Areas.Contact.Controllers" }
            );

            ContactBundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}