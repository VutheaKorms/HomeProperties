using HomeProperty.Repository;
using HomeProperty.View;
using HomeProperty.View.QueryParameter;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HomeProperty.Service.Controllers {
    [Authorize]
    [RoutePrefix("api/Menus")]
    public class MenusController : ApiController {
        private IAppRepository _appData;

        public IAppRepository AppData {
            get { return _appData ?? new AppRepository(); }
            set { _appData = value; }
        }

        public MenusController() {
            _appData = new AppRepository();
        }

        // GET api/menus
        public async Task<IEnumerable<MenuView>> Get([FromUri] MenuQueryParameter param = null) {
            return await AppData.GetMenusAsync();
        }

        // GET api/menus/id
        public async Task<MenuView> Get(Guid id) {
            return await AppData.GetMenuAsync(id);
        }

        // POST api/menus
        public async Task<Guid> Post(MenuView menu) {
            return await AppData.AddMenuAsync(menu);
        }

        // PUT api/menus
        public async Task<IHttpActionResult> Put(MenuView menu) {
            var result = await AppData.UpdateMenuAsync(menu);
            return result == 0 ? (IHttpActionResult)BadRequest("Could not update the menu") : Ok(result);
        }

        // DELETE api/menus 
        public async Task<IHttpActionResult> Delete(MenuView menu) {
            var result = await AppData.DeleteMenuAsync(menu);
            return result == 0 ? (IHttpActionResult)BadRequest("Could not delete the menu") : Ok(result);
        }

        //custom delete menu
        [HttpPost, Route("Delete")]
        public async Task<IHttpActionResult> DeleteMenus(List<MenuView> menus) {
            var affectedRows = await AppData.DeleteMenusAsync(menus);
            return affectedRows == 0 ? (IHttpActionResult)BadRequest("Could not delete the driveType.") : Ok(affectedRows);
        }

        // GET: api/menus/{name}
        [Route("{Name}")]
        public async Task<Guid> GetMenuIdByName(string name) {
            return await AppData.GetMenuIdAsync(name);
        }
    }
}