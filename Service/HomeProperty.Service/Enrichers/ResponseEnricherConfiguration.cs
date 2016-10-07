using System.Web.Http;

namespace HomeProperty.Service.Enrichers {

    public class ResponseEnricherConfiguration {
        public static void Configure(HttpConfiguration config) {
            config.AddResponseEnrichers(new StyleResponseEnricher());
        }
    }

}