namespace HomeProperty.View.Hypermedia.Links {
    public class Last : Link {

        public const string Relation = "Last";

        public Last(string href, string title = null)
        : base(Relation, href, title) {

        }
    }
}
