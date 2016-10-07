using FluentValidation;

namespace HomeProperty.View.ErrorValidator {
    public class ErrorLogViewValidator : AbstractValidator<ErrorLogView> {
        public ErrorLogViewValidator() {
            RuleFor(x => x.Message).NotEmpty().WithMessage("Error log Message is required.");
            RuleFor(x => x.Message).Length(1, 1000).WithMessage("Error log Message can not put over 1000 characters.");
            RuleFor(x => x.FileName).Length(1, 255).WithMessage("Error log File Name can not put over 255 characters.");
            RuleFor(x => x.ErrorInfo).Length(1, 255).WithMessage("Error log Error Info can not put over 255 characters.");
        }
    }
}
