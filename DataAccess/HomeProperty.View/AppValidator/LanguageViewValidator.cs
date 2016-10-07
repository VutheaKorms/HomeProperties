using FluentValidation;

namespace HomeProperty.View.AppValidator {
    public class LanguageViewValidator : AbstractValidator<LanguageView> {
        public LanguageViewValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Language Name is required.");
            RuleFor(x => x.Name).Length(1, 50).WithMessage("Language Name can not put over 50 characters.");
            RuleFor(x => x.Locale).Length(1, 15).WithMessage("Language Locale can not put over 15 characters.");
        }
    }
}
