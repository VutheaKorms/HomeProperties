using HomeProperty.WebApp.Controllers;
using System.Web.Mvc;

namespace HomeProperty.WebApp.Areas.About.Controllers {

    public class AboutController : BaseController {

        public ActionResult Index() {
            return View();
        }
    }
}