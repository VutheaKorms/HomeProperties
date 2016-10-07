using FluentValidation.Attributes;
using HomeProperty.View.ErrorValidator;
using System;

namespace HomeProperty.View {
    [Validator(typeof(ErrorLogViewValidator))]
    public class ErrorLogView : BaseView {
        public ErrorLogView() {
            Application = new ApplicationView();
        }
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime? OccuredDate { get; set; }
        public string ErrorInfo { get; set; }
        public string StackTrace { get; set; }
        public string FileName { get; set; }
        public int? LineNumber { get; set; }
        public ApplicationView Application { get; set; }
        public Guid? ApplicationId { get; set; }
        public bool IsResolved { get; set; }
    }
}
