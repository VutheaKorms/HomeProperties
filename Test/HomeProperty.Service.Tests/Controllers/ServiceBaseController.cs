using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace HomeProperty.Service.Tests.Controllers {

    public class ServiceBaseController {
        protected void SetUpController(ApiController controller,
            string serviceEndPoint,
            string requestedUri,
            string controllerName,
            HttpMethod method) {
            controller.Request = new HttpRequestMessage {
                RequestUri = new Uri(string.Format("{0}{1}", serviceEndPoint, requestedUri)),
                Method = method
            };

            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary { { "controller", controllerName } });
        }
    }
}
