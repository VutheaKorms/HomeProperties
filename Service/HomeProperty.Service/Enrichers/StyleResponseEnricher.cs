using System;
using System.Net.Http;

namespace HomeProperty.Service.Enrichers {

    public class StyleResponseEnricher : ObjectContentResponseEnricher {

        //public override bool CanEnrich(HttpResponseMessage response) {
        //    bool canEnrich = false;
        //    var content = response.Content as ObjectContent;

        //    if (content != null && (content.ObjectType == typeof(ResourceWrapper))) {
        //        ResourceWrapper wrapper;
        //        if (response.TryGetContentValue<ResourceWrapper>(out wrapper)) {
        //            if (wrapper.RecordType == typeof(StyleView)) {
        //                canEnrich = true;
        //            }
        //        }
        //    }

        //    return canEnrich;
        //}

        //public override HttpResponseMessage Enrich(HttpResponseMessage response) {

        //    ResourceWrapper wrapper;

        //    var urlHelper = response.RequestMessage.GetUrlHelper();

        //    if (response.TryGetContentValue<ResourceWrapper>(out wrapper)) {
        //        IEnumerable<StyleView> styles = wrapper.Records as IEnumerable<StyleView>;
        //        if (styles != null || styles.Count() > 0) {
        //            string controller = "Styles";
        //            AddSelfAndEdit(styles, controller, urlHelper);
        //            BuildNavigationLink(wrapper, controller, urlHelper);
        //        }

        //        return response;
        //    }

        //    return response;
        //}

        //private void AddSelfAndEdit(IEnumerable<StyleView> styles, string controller, UrlHelper url) {
        //    foreach (StyleView style in styles) {
        //        var selfUrl = url.Link("DefaultApi", new { controller = controller, filter = string.Format("Id eq guid'{0}'", style.Id) });
        //        var editUrl = url.Link("DefaultApi", new { controller = controller });
        //        style.AddLink(new Self(selfUrl, "Self Link"));
        //        style.AddLink(new Edit(editUrl, "Edit Link using Put method"));
        //    }
        //}
        public override bool CanEnrich(HttpResponseMessage response) {
            throw new NotImplementedException();
        }

        public override HttpResponseMessage Enrich(HttpResponseMessage response) {
            throw new NotImplementedException();
        }
    }

}