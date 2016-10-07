using FluentValidation;

namespace HomeProperty.View.AppValidator {
    public class MenuItemViewValidator : AbstractValidator<MenuItemView> {
        public MenuItemViewValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Menu Item Name is required.");
            RuleFor(x => x.Name).Length(1, 50).WithMessage("Menu Item Name cannot be over 50 characters.");
            RuleFor(x => x.Url).Length(1, 400).WithMessage("Menu Item Url cannot be over 400 characters.");
            RuleFor(x => x.IconUrl).Length(1, 400).WithMessage("Menu Item Icon Url cannot be over 400 characters.");
        }
    }
}
