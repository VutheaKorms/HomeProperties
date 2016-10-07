using FluentValidation.Attributes;
using HomeProperty.View.AppValidator;
using System;
using System.Collections.Generic;

namespace HomeProperty.View {
    [Validator(typeof(MenuViewValidator))]
    public class MenuView : BaseView {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<MenuItemView> MenuItems { get; set; }
    }
}
