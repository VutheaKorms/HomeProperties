namespace HomeProperty.View.Hypermedia.Links {
    public class Edit : Link {

        public const string Relation = "Edit";

        public Edit(string href, string title = null)
        : base(Relation, href, title) {

        }
    }
}
