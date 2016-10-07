using FluentValidation.Attributes;
using HomeProperty.View.AppValidator;
using System;

namespace HomeProperty.View {
    [Validator(typeof(MenuChildItemViewValidator))]
    public class MenuChildItemView : BaseView {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string IconUrl { get; set; }
        public Guid MenuItemId { get; set; }
        public MenuItemView MenuItem { get; set; }
        public Guid? LanguageId { get; set; }

        //Name to display
        public Guid MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuItemName { get; set; }
        public string LanguageName { get; set; }
    }
}
