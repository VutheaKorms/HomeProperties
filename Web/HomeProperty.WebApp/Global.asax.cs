using HomeProperty.WebApp.Areas.Admin.Mappers;
using HomeProperty.WebApp.Infrastructure;
using System;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HomeProperty.WebApp {
    public class MvcApplication : System.Web.HttpApplication {
        /// <summary>
        /// The event handler fires when the application starts
        /// </summary>
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            DependencyConfigure.Initialize();

            //FluentValidationConfig.Configure();
            AutoMapperConfig.Configure();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Test get token from service
            ApplicationService.GetServiceToken();
        }

        /// <summary>
        /// The evnt handler that fires when the user making requests
        /// </summary>
        /// <param name="source">The http application</param>
        /// <param name="e">The event argument</param>
        protected void Application_BeginRequest(Object source, EventArgs e) {
            var application = source as HttpApplication;
            if (application == null)
                throw new ArgumentNullException("Http application is null.");
            var context = application.Context;
            var currentCulture = string.Empty;

            // Get current culture from cookie 
            var cookie = Request.Cookies["_culture"];
            if (cookie != null)
                currentCulture = cookie.Value;

            // Attempts to get culture from browser 
            if (string.IsNullOrEmpty(currentCulture)) {
                if (context.Request.UserLanguages != null && Request.UserLanguages.Length > 0)
                    currentCulture = Request.UserLanguages[0];
            }
            if (string.IsNullOrEmpty(currentCulture))
                throw new ArgumentNullException("Current culture is null.");
            // Set current culture
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(currentCulture);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }

        private object GetControllerFromContext(HttpContext context) {
            object controller = null;
            HttpContextBase currentContext = new HttpContextWrapper(context);
            UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            RouteData routeData = urlHelper.RouteCollection.GetRouteData(currentContext);
            if (routeData != null)
                controller = routeData.Values["controller"];
            return controller;
        }
    }
}
