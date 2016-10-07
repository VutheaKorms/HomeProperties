using HomeProperty.View.Hypermedia;
using HomeProperty.View.Hypermedia.Links;
using System.Net.Http;
using System.Web.Http.Routing;

namespace HomeProperty.Service.Enrichers {

    public abstract class ObjectContentResponseEnricher : IResponseEnricher {

        public abstract bool CanEnrich(HttpResponseMessage response);
        public abstract HttpResponseMessage Enrich(HttpResponseMessage response);

        protected void BuildNavigationLink(ResourceWrapper wrapper, string controller, UrlHelper urlHelper) {

            int nextPage, nextSize, previousPage, previousSize, lastPage, lastSize;

            nextPage = nextSize = wrapper.Size > wrapper.TotalRecords ? wrapper.TotalRecords : wrapper.Size;

            previousPage = (wrapper.Page - wrapper.Size) <= 0 ? 1 : (wrapper.Page - wrapper.Size);
            previousSize = wrapper.Size;

            lastPage = (wrapper.TotalRecords - wrapper.Size) <= 0 ? 1 : (wrapper.TotalRecords - wrapper.Size);
            lastSize = wrapper.Size;

            var firstLink = urlHelper.Link("DefaultApi", new { controller = controller, page = 1, size = wrapper.Size, sort = wrapper.Sort, filter = wrapper.Filter });
            var nextLink = urlHelper.Link("DefaultApi", new { controller = "controller", page = nextPage, size = nextSize, sort = wrapper.Sort, filter = wrapper.Filter });
            var previousLink = urlHelper.Link("DefaultApi", new { controller = controller, page = previousPage, size = previousSize, sort = wrapper.Sort, filter = wrapper.Filter });
            var lastLink = urlHelper.Link("DefaultApi", new { controller = controller, page = lastPage, size = lastSize, sort = wrapper.Sort, filter = wrapper.Filter });

            wrapper.AddLink(new First(firstLink, string.Format("First {0} Link", controller)));
            wrapper.AddLink(new Next(nextLink, string.Format("Next {0} Link", controller)));
            wrapper.AddLink(new Previous(previousLink, string.Format("Previous {0} Link", controller)));
            wrapper.AddLink(new Last(lastLink, string.Format("Last {0} Link", controller)));
        }
    }
}