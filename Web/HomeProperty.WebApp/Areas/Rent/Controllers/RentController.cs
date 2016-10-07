using HomeProperty.WebApp.Controllers;
using System.Web.Mvc;

namespace HomeProperty.WebApp.Areas.Rent.Controllers {
    public class RentController : BaseController {
        // GET: Rent/Rent
        public ActionResult Index() {
            return View();
        }
    }
}