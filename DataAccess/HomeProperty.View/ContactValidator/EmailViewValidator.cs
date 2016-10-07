using FluentValidation;

namespace HomeProperty.View.ContactValidator {

    public class EmailViewValidator : AbstractValidator<EmailView> {
        public EmailViewValidator() {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Email Address is required.");
            RuleFor(x => x.Address).Length(1, 50).WithMessage("Email Address cannot be over 50 characters.");
        }
    }
}