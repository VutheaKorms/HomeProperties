using HomeProperty.WebApp.Controllers;
using System.Web.Mvc;

namespace HomeProperty.WebApp.Areas.Sell.Controllers {
    public class SellController : BaseController {
        // GET: Sell/Sell
        public ActionResult Index() {
            return View();
        }
    }
}