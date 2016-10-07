using FluentValidation.Attributes;
using HomeProperty.View.ContactValidator;
using System;

namespace HomeProperty.View {
    [Validator(typeof(EmailViewValidator))]
    public class EmailView : BaseView {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public Guid EmailTypeId { get; set; }
        public EmailTypeView EmailType { get; set; }
        public bool? IsPrimary { get; set; }
    }
}
