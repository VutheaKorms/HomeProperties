using FluentValidation;

namespace HomeProperty.View.AppValidator {
    public class ApplicationViewValidator : AbstractValidator<ApplicationView> {
        public ApplicationViewValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Application Name is required.");
            RuleFor(x => x.Name).Length(1, 50).WithMessage("Application Name can not put over 50 characters.");
        }
    }
}
