namespace HomeProperty.View.Flexible {
    /// <summary>
    /// Sample request: ?page=5&size=10&sort=[FirstName:asc,LastName:desc,Age:asc]
    /// </summary>
    public class FlexibleView {

        /// <summary>
        /// The requested/current page number
        /// The default page: [1,2,3,4,5]
        /// </summary>
        public string Page { get; set; }
        /// <summary>
        /// The page size 
        /// The default page size is 20
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// Total pages
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// Is this the last page?
        /// </summary>
        public bool IsLastPage { get; set; }
        /// <summary>
        /// Is this the first page?
        /// </summary>
        public bool IsFirstPage { get; set; }
        /// <summary>
        /// The sort string in this format:
        /// ?sort=[FirstName: asc, LastName: desc]
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// The client filter expression
        /// ?filter=Country eq Cambodia and Zone neq Europe or people.contains(khmer)
        /// ?filter=all.contains(cambodia)
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// Total number of records 
        /// </summary>
        public int TotalRecords { get; set; }

        public override string ToString() {
            return string.Format("Page={0}&Size={1}", Page, Size);
        }
    }
}
