using HomeProperty.WebApp.Controllers;
using System.Web.Mvc;

namespace HomeProperty.WebApp.Areas.Buy.Controllers {
    public class BuyController : BaseController {
        // GET: Buy/Buy
        public ActionResult Index() {
            return View();
        }
    }
}