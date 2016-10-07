using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AutoMarketPlace.WebApp.Models {

    public class MenusViewModel : ViewModelBase{

        public MenusViewModel() {
            Languages = new List<SelectListItem>();
            MenuItems = new List<MenuItemsViewModel>();
        }

        #region Main Menu
        public string Name { get; set; }

        public Guid? LanguageId { get; set; }
        public virtual IList<SelectListItem> Languages { get; set; }
        public virtual IList<MenuItemsViewModel> MenuItems { get; set; }

        #endregion

        #region Nested Class

        public class MenuItemsViewModel : ViewModelBase {

            public MenuItemsViewModel() {

                Menus = new List<SelectListItem>();
                Languages = new List<SelectListItem>();
                MenuChildItems = new List<MenuChildItemsViewModel>();

            }

            public string Name { get; set; }
            public string Url { get; set; }
            public string IconUrl { get; set; }

            public Guid MenuId { get; set; }
            public virtual IList<SelectListItem> Menus { get; set; }

            public virtual IList<MenuChildItemsViewModel> MenuChildItems { get; set; }
            
            public Guid? LanguageId { get; set; }
            public virtual IList<SelectListItem> Languages { get; set; }

        }

        public class MenuChildItemsViewModel : ViewModelBase {
            public string Name { get; set; }
            public string Url { get; set; }
            public string IconUrl { get; set; }
            public Guid MenuItemId { get; set; }
            public Guid? LanguageId { get; set; }
        }

        #endregion

    }
}