namespace HomeProperty.WebApp.Models {
    /// <summary>
    /// Holds response status and error messages from services for the client.
    /// </summary>
    public class ResponseMessage {
        /// <summary>
        /// The status code: 1 => success, 0 => failure
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// The error messages separated by |
        /// </summary>
        public string ErrorMessages { get; set; }
    }
}