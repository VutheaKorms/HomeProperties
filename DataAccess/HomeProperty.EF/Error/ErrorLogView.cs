using HomeProperty.EF;
using HomeProperty.EF.App;
using System;

namespace HomeProperty.Error {
    public class ErrorLogView : BaseEntity {
        public ErrorLogView() {
            Application = new Application();
        }
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime? OccuredDate { get; set; }
        public string ErrorInfo { get; set; }
        public string StackTrace { get; set; }
        public string FileName { get; set; }
        public int? LineNumber { get; set; }
        public Application Application { get; set; }
        public Guid? ApplicationId { get; set; }
        public bool IsResolved { get; set; }
    }
}
