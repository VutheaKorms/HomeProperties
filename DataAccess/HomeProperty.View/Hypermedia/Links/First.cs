namespace HomeProperty.View.Hypermedia.Links {
    public class First : Link {

        public const string Relation = "First";

        public First(string href, string title = null)
        : base(Relation, href, title) {

        }
    }
}
