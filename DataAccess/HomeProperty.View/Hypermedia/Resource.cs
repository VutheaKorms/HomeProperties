using HomeProperty.View.Hypermedia.Links;
using System.Collections.Generic;
using System.Linq;


namespace HomeProperty.View.Hypermedia {

    public class Resource {

        private readonly List<Link> links = new List<Link>();

        public IEnumerable<Link> Links { get { return links; } }

        public bool ShouldSerializeLinks() {
            return this.Links.Count() > 0;
        }

        public void AddLink(Link link) {
            links.Add(link);
        }

        public void AddLinks(params Link[] links) {
            foreach (Link link in links) {
                AddLink(link);
            }
        }
    }

}
