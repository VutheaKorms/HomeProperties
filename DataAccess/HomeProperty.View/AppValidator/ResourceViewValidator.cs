using FluentValidation;

namespace HomeProperty.View.AppValidator {
    public class ResourceViewValidator : AbstractValidator<ResourceView> {
        public ResourceViewValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Resource Name is required.");
            RuleFor(x => x.Culture).NotEmpty().WithMessage("Resource Culture is required.");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Resource Value is required.");
            RuleFor(x => x.Culture).Length(1, 10).WithMessage("Resource Culture can not put over 10 characters.");
            RuleFor(x => x.Name).Length(1, 100).WithMessage("Resource Name can not put over 100 characters.");
            RuleFor(x => x.Value).Length(1, 4000).WithMessage("Resource Value can not put over 4000 characters.");
        }
    }
}
