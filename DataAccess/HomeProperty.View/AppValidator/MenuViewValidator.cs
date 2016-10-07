using FluentValidation;

namespace HomeProperty.View.AppValidator {
    public class MenuViewValidator : AbstractValidator<MenuView> {
        public MenuViewValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Menu Name is required.");
            RuleFor(x => x.Name).Length(1, 50).WithMessage("Menu Name cannot be over 50 characters.");
        }
    }
}
