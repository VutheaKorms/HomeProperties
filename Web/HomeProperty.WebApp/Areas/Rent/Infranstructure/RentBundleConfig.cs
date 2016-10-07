using System.Web.Optimization;

namespace HomeProperty.WebApp.Areas.Rent.Infranstructure {

    public class RentBundleConfig {

        public static void RegisterBundles(BundleCollection bundles) {
            // Style bundles 
            AddStyleBundles(bundles);
            // Script bundles 
            AddScriptBundles(bundles);
            // Angular script bundles 
            AddAngularScriptBundles(bundles);
            // Code removed for clarity.
        }

        private static void AddAngularScriptBundles(BundleCollection bundles) {
            // AngularJS
            bundles.Add(new ScriptBundle("~/bundles/buy/angularJs").Include(
                "~/Scripts/App/angular/angular.js",
                "~/Scripts/app/ui-router/angular-ui-router.js",
                "~/Scripts/App/angular/angular-route.js",
                "~/Scripts/app/plugins/oclazyload/dist/ocLazyLoad.min.js",
                "~/Scripts/App/angular/angular-range-slider.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/App/angular/angular-loading-bar.js",
                "~/Scripts/App/bootstrap/ui-bootstrap-tpls-1.2.4.js",
                "~/Scripts/App/angular/angular-checklist-model.js",
                "~/Scripts/App/angular/ng-infinite-scroll.js",
                "~/Scripts/App/angular/angular-checklist-model.js",
                "~/Scripts/App/angular/angular-multi-select.js"
                ));
        }

        /// <summary>
        /// Adds script bundles 
        /// </summary>
        /// <param name="bundles">The bundle collection</param>
        private static void AddScriptBundles(BundleCollection bundles) {
            // Buy.js
            bundles.Add(new ScriptBundle("~/bundles/buy/buyScript").Include(
                      "~/Areas/Buy/Scripts/BuyModule.js"));

            // Bootstrap Js
            bundles.Add(new ScriptBundle("~/bundles/buy/bootstrap").Include(
              "~/Scripts/bootstrap.js"));

            // Buy Module 
            bundles.Add(new Bundle("~/bundles/buy/buyModule").Include(
             "~/Areas/Buy/Scripts/App.js"));

            // Buy Configuration 
            bundles.Add(new Bundle("~/bundles/buy/buyConf").Include(
             "~/Areas/Buy/Scripts/Config.js"));

            // Buy Service 
            bundles.Add(new Bundle("~/bundles/buy/buyServices").Include(
             "~/Areas/Buy/Scripts/Services/BrowseDataService.js",
             "~/Areas/Buy/Scripts/Services/DetailDataService.js",
             "~/Areas/Buy/Scripts/Services/MenuDataService.js"));

            // Buy Controller 
            bundles.Add(new Bundle("~/bundles/buy/buyControllers").Include(
             "~/Areas/Buy/Scripts/Controllers/MenuController.js",
             "~/Areas/Buy/Scripts/Controllers/BrowseController.js",
             "~/Areas/Buy/Scripts/Controllers/DetailController.js"));

            // Buy Filter 
            bundles.Add(new Bundle("~/bundles/buy/buyFilter").Include(
             "~/Areas/Buy/Scripts/Filters/BuyFilter.js"));

            // Buy car detail slider 
            bundles.Add(new Bundle("~/bundles/buy/buyCarDetail").Include(
             "~/Areas/Buy/Scripts/CarDetail.js"));

            // Buy car detail slider 
            bundles.Add(new Bundle("~/bundles/buy/jssor").Include(
             "~/Scripts/App/jssor/jssor.slider.mini.js"));
        }

        /// <summary>
        /// Adds style bundles 
        /// </summary>
        /// <param name="bundles">The bundle collection.</param>
        private static void AddStyleBundles(BundleCollection bundles) {
            // Buy index styles 
            bundles.Add(new StyleBundle("~/Content/buy/indexStyle").Include(
                     "~/Content/Plugins/angular-multi-select/multi-select.css",
                     "~/Content/bootstrap-listgridview.css",
                     "~/Areas/Buy/Content/buy-index.css",
                     "~/Areas/Buy/Content/style-grid-views.css"
                ));

            // Angular range slider styles 
            bundles.Add(new StyleBundle("~/Content/buy/angularRangeSlider").Include(
                     "~/Content/Plugins/angular-range-slider/angul-range-slider.css"
                ));

            // Buy car detail styles 
            bundles.Add(new StyleBundle("~/Content/buy/carDetail").Include(
                     "~/Areas/Buy/Content/car-detail.css"
                ));
        }
    }
}