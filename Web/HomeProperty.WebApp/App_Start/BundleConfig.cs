using System.Web.Optimization;

namespace HomeProperty.WebApp {
    public class BundleConfig {

        public static void RegisterBundles(BundleCollection bundles) {
            // jQuery 
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            // jQuery validate
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            // Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-dialog.min.js",
                      "~/Scripts/bootstrap-hover-dropdown.min.js",
                      "~/Scripts/respond.js"));
            // Datatable
            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                   "~/Scripts/jquery.dataTables.js"));
            // CSS files
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/layout.css",
                     "~/Content/bootstrap-dialog.min.css",
                     "~/Content/jquery.dataTables.css",
                     "~/Content/jquery.dataTables_themeroller.css",
                     "~/Content/components-rounded.css",
                     "~/Content/font-awesome-4.3.0/css/font-awesome.css",
                     "~/Content/Simple-Line-Icons-Webfont/simple-line-icons.css",
                     "~/Content/site.css"));

            // Language 
            bundles.Add(new ScriptBundle("~/bundles/language").Include(
                     "~/Scripts/app.language.js"));

            // Javascript for layout page
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                  "~/Scripts/app.js"));
            // jQuery Template
            bundles.Add(new ScriptBundle("~/bundles/jquerytemplate").Include(
                   "~/Scripts/jquery.tmpl.js"));
            // Knockout JS
            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                   "~/Scripts/knockout-3.2.0.debug.js"));
            // Loan applicatoin 
            bundles.Add(new ScriptBundle("~/bundles/Loan.Apply").Include(
                     "~/Scripts/Loan/Loan.Apply.js"));

            // Scripts/Home/Home.Index.js
            bundles.Add(new ScriptBundle("~/bundles/Home.Index").Include(
                    "~/Scripts/Home/Home.Index.js"));

            // Scripts/Dealer/Dealer.Index.js
            bundles.Add(new ScriptBundle("~/bundles/Dealer.Index").Include(
                    "~/Scripts/Dealer/Dealer.Index.js"));

            // autocompleted
            bundles.Add(new ScriptBundle("~/bundles/Jquery.Ui").Include(
                    "~/Scripts/jquery-ui.js"));

            // Scripts/Finance/Finance.Index.js
            bundles.Add(new ScriptBundle("~/bundles/Finance.Index").Include(
                    "~/Scripts/Finance/Finance.Index.js"));

            // Scripts/Membershp/Membership.Index.js 
            bundles.Add(new ScriptBundle("~/bundles/Membership.Index").Include(
                   "~/Scripts/Membership/Membership.Index.js"));

            // Scripts/Message/Message.Index.js 
            bundles.Add(new ScriptBundle("~/bundles/Message.Index").Include(
                   "~/Scripts/Message/Message.Index.js"));

            // Scripts/Message/Message.Add.js 
            bundles.Add(new ScriptBundle("~/bundles/Membership.Add").Include(
                   "~/Scripts/Membership/Membership.Add.js"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            // BundleTable.EnableOptimizations = true;
        }
    }
}
