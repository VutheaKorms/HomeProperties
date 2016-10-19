using FluentValidation;
using HomeProperty.View.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeProperty.View.AppValidator
{
    public class PckageViewValidator : AbstractValidator<PackageView>
    {
        public PckageViewValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Package Name is required.");
            RuleFor(x => x.Name).Length(1, 50).WithMessage("Package Name cannot be over 50 characters.");
        }
    }
}
