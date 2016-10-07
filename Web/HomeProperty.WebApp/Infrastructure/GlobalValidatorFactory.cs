using Autofac;
using FluentValidation;
using FluentValidation.Attributes;
using System;

namespace HomeProperty.WebApp.Infrastructure {

    public class GlobalValidatorFactory : AttributedValidatorFactory {

        protected readonly IContainer _container;

        public GlobalValidatorFactory(IContainer container) {
            this._container = container;
        }

        public override IValidator GetValidator(Type type) {
            if (type != null) {
                var attribute = (ValidatorAttribute)Attribute.GetCustomAttribute(type, typeof(ValidatorAttribute));
                if ((attribute != null) && (attribute.ValidatorType != null)) {
                    IValidator validator = _container.ResolveOptionalKeyed<IValidator>(attribute.ValidatorType);
                    return validator;
                }
            }
            return null;

        }
    }
}