using System.Net.Http;

namespace HomeProperty.Service.Enrichers {
    public interface IResponseEnricher {
        bool CanEnrich(HttpResponseMessage response);
        HttpResponseMessage Enrich(HttpResponseMessage response);
    }
}
