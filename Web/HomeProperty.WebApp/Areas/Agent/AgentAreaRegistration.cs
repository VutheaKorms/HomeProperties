using HomeProperty.WebApp.Areas.Agent.Infranstructure;
using System.Web.Mvc;
using System.Web.Optimization;

namespace HomeProperty.WebApp.Areas.Agent {

    public class AgentAreaRegistration : AreaRegistration {

        public override string AreaName {
            get {
                return "Agent";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "Agent_default",
                "Agent/{controller}/{action}/{id}",
                new { controller = "Agent", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "HomeProperty.WebApp.Areas.Agent.Controllers" }
            );

            AgentBundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}