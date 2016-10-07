using System.Web.Mvc;

namespace HomeProperty.WebApp.Controllers {
    public class MessageController : Controller {
        // GET: Message
        public ActionResult Index() {
            return View();
        }
    }
}