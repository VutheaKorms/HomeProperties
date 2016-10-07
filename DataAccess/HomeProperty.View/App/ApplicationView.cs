using FluentValidation.Attributes;
using HomeProperty.View.AppValidator;
using System;

namespace HomeProperty.View {
    [Validator(typeof(ApplicationViewValidator))]
    public class ApplicationView : BaseView {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
