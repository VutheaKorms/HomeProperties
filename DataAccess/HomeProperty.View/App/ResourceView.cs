using FluentValidation.Attributes;
using HomeProperty.View.AppValidator;
using System;

namespace HomeProperty.View {
    [Validator(typeof(ResourceViewValidator))]
    public class ResourceView : BaseView {
        public Guid Id { get; set; }
        public string Culture { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public Guid? ApplicationId { get; set; }
        public ApplicationView Application { get; set; }
    }
}
