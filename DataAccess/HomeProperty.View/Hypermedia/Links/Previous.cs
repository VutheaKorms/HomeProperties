namespace HomeProperty.View.Hypermedia.Links {
    public class Previous : Link {

        public const string Relation = "Previous";

        public Previous(string href, string title = null)
        : base(Relation, href, title) {

        }
    }
}
