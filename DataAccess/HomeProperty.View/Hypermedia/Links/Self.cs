namespace HomeProperty.View.Hypermedia.Links {
    public class Self : Link {

        public const string Relation = "Self";

        public Self(string href, string title = null)
        : base(Relation, href, title) {

        }

    }
}
