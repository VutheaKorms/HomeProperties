using FluentValidation.Attributes;
using HomeProperty.View.AppValidator;
using System;
using System.Collections.Generic;

namespace HomeProperty.View {
    [Validator(typeof(MenuItemViewValidator))]
    public class MenuItemView : BaseView {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string IconUrl { get; set; }
        public IList<MenuChildItemView> MenuChildItems { get; set; }
        public Guid MenuId { get; set; }
        public string MenuName { get; set; }
        public Guid? LanguageId { get; set; }
        public string LanguageName { get; set; }
    }
}
