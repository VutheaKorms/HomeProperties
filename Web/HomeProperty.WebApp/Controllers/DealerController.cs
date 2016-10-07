using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoMarketPlace.WebApp.Controllers
{
    public class DealerController : Controller
    {
        // GET: Dealer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Result() 
        {
            return View("Result");
        }

        [HttpGet]
        public ActionResult Makes() {
            return Json(ApplicationService.Makes, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult States() {
            return Json(ApplicationService.States, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult YearRanges() {
            return Json(ApplicationService.YearRanges, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Autocompleted(string term) {
            var items = new[] { "Kompong Cham", "Phnom Penh",
                    "Kompong Thom", "Kompong Chhnang", "Siem Reap",
                    "Kompot", "Kompong Spue", "Svay Reang" , "Takeo" ,"Orddur Meanchey" ,"Posat" ,"Ratanakiri" };

            var filteredItems = items.Where(
                item => item.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0
                );
            return Json(filteredItems, JsonRequestBehavior.AllowGet);
        }


    }
}