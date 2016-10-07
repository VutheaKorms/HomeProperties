using HomeProperty.WebApp.Controllers;
using System.Web.Mvc;

namespace HomeProperty.WebApp.Areas.Agent.Controllers {
    public class AgentController : BaseController {

        public ActionResult Index() {
            return View();
        }
    }
}