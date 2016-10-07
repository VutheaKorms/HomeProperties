using HomeProperty.View;
using HomeProperty.View.QueryParameter;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeProperty.Repository {

    public interface IAppRepository {

        #region Menus
        Task<List<MenuView>> GetMenusAsync();
        Task<MenuView> GetMenuAsync(Guid id);
        Task<Guid> GetMenuIdAsync(string menuName);
        Task<Guid> AddMenuAsync(MenuView menu);
        Task<int> UpdateMenuAsync(MenuView menu);
        Task<int> DeleteMenuAsync(MenuView menu);
        Task<int> DeleteMenusAsync(List<MenuView> menu);
        #endregion Menus

        #region MenuItems

        Task<MenuItemView> GetMenuItemAsync(Guid id, string culture = HomeProperty.Settings.Constant.Constant.EnglishUsCulture);

        Task<List<MenuItemView>> GetMenuItemsByMenuNameAsync(string menuName,
        string culture = HomeProperty.Settings.Constant.Constant.EnglishUsCulture);

        Task<Guid> AddMenuItemAsync(MenuItemView menuItemView);

        Task<List<MenuItemView>> GetMenuItemsAsync(string culture);

        Task<List<MenuItemView>> GetMenuItemsAsync(
           string culture = HomeProperty.Settings.Constant.Constant.EnglishUsCulture,
           MenuItemQueryParameter parameter = null);

        #endregion MenuItems


    }
}
