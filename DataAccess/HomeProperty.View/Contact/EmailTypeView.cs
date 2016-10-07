using FluentValidation.Attributes;
using HomeProperty.View.ContactValidator;
using System;
using System.Collections.Generic;

namespace HomeProperty.View {
    [Validator(typeof(EmailTypeViewValidator))]
    public class EmailTypeView : BaseView {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<EmailView> Emails { get; set; }
        public Guid? LanguageId { get; set; }
    }
}
