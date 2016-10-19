using HomeProperty.WebApp.Models;
using System;
using System.Web.Mvc;


namespace HomeProperty.WebApp.Controllers {
    public class HomeController : BaseController {

        private IContactServiceModel _contactServiceModel = ServiceModelFactory.ContactServiceModel;

        public ActionResult Index() {
            // For testing only 
            //var demographicServiceModel = new DemographicServiceModel();
            return View();
        }

        public ActionResult Search() {
            return View("Search");
        }

        public ActionResult Result() {
            return View("Result");
        }

        public ActionResult VehicleDetails() {
            return View("VehicleDetails");
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        /// <summary>
        /// Sets the selected culture
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        public ActionResult SetCulture(string culture, string currentUrl) {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            System.Web.HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else {
                cookie = new System.Web.HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            // Store current culture in cookie 
            Response.Cookies.Add(cookie);
            return Redirect(currentUrl);
        }
        /// <summary>
        /// The main navigation menu
        /// </summary>
        /// <returns>The json main navigation menu</returns>
        [HttpGet]
        public ActionResult MainNavigationMenu() {
            return Json(ApplicationService.MainNavigationBarMenu, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetEmailTypes()
        {
            return Content(_contactServiceModel.GetEmailTypes());
        }


        [HttpGet]
        public ActionResult GetPackages()
        {
            return Content(_contactServiceModel.GetPackages());
        }
        /// <summary>
        /// The credit score ranges
        /// </summary>
        /// <returns>The json credit score ranges</returns>
        //[HttpGet]
        //public ActionResult CreditScoreRanges() {
        //    return Json(ApplicationService.CreditScoreRanges, JsonRequestBehavior.AllowGet);
        //}
        /// <summary>
        /// The loan purposes
        /// </summary>
        /// <returns>The JSON loan purposes</returns>
        //[HttpGet]
        //public ActionResult LoanPurposes() {
        //    return Json(ApplicationService.LoanPurposes, JsonRequestBehavior.AllowGet);
        //}
    }
}