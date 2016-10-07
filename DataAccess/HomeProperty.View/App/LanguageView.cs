using FluentValidation.Attributes;
using HomeProperty.View.AppValidator;
using System;

namespace HomeProperty.View {
    [Validator(typeof(LanguageViewValidator))]
    public class LanguageView : BaseView {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Locale { get; set; }
    }
}
