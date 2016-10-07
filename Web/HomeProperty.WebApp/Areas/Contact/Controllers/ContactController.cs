using HomeProperty.WebApp.Controllers;
using System.Web.Mvc;

namespace HomeProperty.WebApp.Areas.Contact.Controllers {

    public class ContactController : BaseController {

        public ActionResult Index() {
            return View();
        }
    }
}