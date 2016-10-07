using HomeProperty.Repository;
using HomeProperty.View;
using HomeProperty.View.QueryParameter;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HomeProperty.Service.Controllers {
    [Authorize]
    [RoutePrefix("api/MenuItems")]
    public class MenuItemsController : ApiController {
        private IAppRepository _appRepository;

        public IAppRepository AppReposiotry {
            get { return _appRepository ?? new AppRepository(); }
            set { _appRepository = value; }
        }

        public MenuItemsController() {
            _appRepository = new AppRepository();
        }

        // GET api/menuItems
        public async Task<IEnumerable<MenuItemView>> Get([FromUri] MenuItemQueryParameter param) {
            return await AppReposiotry.GetMenuItemsAsync(param.languageId, param);
        }

        // GET api/menuItems/id
        public async Task<MenuItemView> Get(Guid id, string culture = HomeProperty.Settings.Constant.Constant.EnglishUsCulture) {
            return await AppReposiotry.GetMenuItemAsync(id, culture);
        }

        // GET Api/MenuItem/Menus/{MenuName} 
        [Route("Menus/{MenuName}")]
        public async Task<IEnumerable<MenuItemView>> Get(string menuName,
            string culture = HomeProperty.Settings.Constant.Constant.EnglishUsCulture) {
            return await AppReposiotry.GetMenuItemsByMenuNameAsync(menuName, culture);
        }

        // POST api/menuItems
        public async Task<Guid> Post(MenuItemView menuItem) {
            return await AppReposiotry.AddMenuItemAsync(menuItem);
        }

        //// PUT api/menuItems
        //public async Task<IHttpActionResult> Put(MenuItemView menuItem) {
        //    int result = await AppReposiotry.UpdateMenuItemAsync(menuItem);
        //    return result == 0 ? (IHttpActionResult)BadRequest("Could not update the menu item")
        //        : Ok(result);
        //}

        //// DELETE api/menuItems 
        //public async Task<IHttpActionResult> Delete(MenuItemView menuItem) {
        //    int result = await AppReposiotry.DeleteMenuItemAsync(menuItem);
        //    return result == 0 ? (IHttpActionResult)BadRequest("Could not delete the menu item")
        //        : Ok(result);
        //}

        //[HttpPost, Route("Delete")]
        //public async Task<IHttpActionResult> DeleteMenuItems(List<MenuItemView> menus) {
        //    var result = await AppReposiotry.DeleteMenuItemsAsync(menus);
        //    return (result == 0) ? (IHttpActionResult)BadRequest("Could not delete the menu")
        //        : Ok(result);
        //}
    }
}