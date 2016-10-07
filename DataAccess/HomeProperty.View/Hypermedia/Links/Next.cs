namespace HomeProperty.View.Hypermedia.Links {
    public class Next : Link {

        public const string Relation = "Next";

        public Next(string href, string title = null)
        : base(Relation, href, title) {

        }
    }
}
