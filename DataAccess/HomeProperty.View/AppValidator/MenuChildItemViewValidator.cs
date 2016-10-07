using FluentValidation;

namespace HomeProperty.View.AppValidator {
    public class MenuChildItemViewValidator : AbstractValidator<MenuChildItemView> {
        public MenuChildItemViewValidator() {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Menu child item Name is required.");
            RuleFor(x => x.Name).Length(1, 50)
                .WithMessage("Menu child item Name cannot be over 50 characters.");
            RuleFor(x => x.Url).Length(1, 400)
                .WithMessage("Menu child item Url cannot be over 400 characters.");
            RuleFor(x => x.IconUrl).Length(1, 400)
                .WithMessage("Menu child item Icon Url cannot be over 400 characters.");
        }
    }
}
