using FluentValidation;

namespace HomeProperty.View.ContactValidator {

    public class EmailTypeViewValidator : AbstractValidator<EmailTypeView> {
        public EmailTypeViewValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Email type Name is required.");
            RuleFor(x => x.Name).Length(1, 50).WithMessage("Email type Name cannot be over 50 characters.");
        }
    }
}