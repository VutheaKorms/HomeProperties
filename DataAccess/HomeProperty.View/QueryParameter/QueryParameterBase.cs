namespace HomeProperty.View.QueryParameter {

    public class QueryParameterBase {

        private string culture;
        private string applicationType;
        /// <summary>
        /// The requested/current page number
        /// The default page: 10
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// The page size 
        /// The default page size is 20
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// The sort string in this format:
        /// ?sort=FirstName asc, LastName: desc
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// The client filter expression
        /// ?filter=Country eq Cambodia and Zone neq Europe or people.contains(khmer)
        /// </summary>
        public string Filter { get; set; }

        public string ApplicationType {
            get {

                object Constant = null;
                if (string.IsNullOrEmpty(applicationType))
                    //return Constant.WebApplication;
                    return HomeProperty.Settings.Constant.Constant.WebApplication;


                return applicationType;
            }

            set {
                applicationType = value;
            }
        }

        public string Culture {

            get {

                if (string.IsNullOrEmpty(culture))
                    return Settings.Constant.Constant.EnglishUsCulture;

                return culture;
            }

            set {
                culture = value;
            }
        }
    }

}
