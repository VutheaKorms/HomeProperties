using HomeProperty.Repository;
using System;
using System.Web.Http;

namespace HomeProperty.Service.Controllers {

    [Authorize]
    public class ResourcesController : ApiController {
        private Guid defaultGuid;

        private IAppRepository _appData;

        public IAppRepository AppData {
            get { return _appData ?? new AppRepository(); }
            set { _appData = value; }
        }

        public ResourcesController() {
            _appData = new AppRepository();
            defaultGuid = new Guid("00000000-0000-0000-0000-000000000000");
        }

        //// GET api/Resources
        //public async Task<List<ResourceView>> Get() {
        //    return await AppData.GetResourcesAsync();
        //}

        //// GET api/Resources/Id
        //public async Task<ResourceView> Get(Guid id) {
        //    return await AppData.GetResourceAsync(id);
        //}

        //// GET api/Resources
        //public async Task<ResourceView> Get(string culture, string name) {
        //    return await AppData.GetResourceAsync(culture, name);
        //}

        //// POST api/Resources
        //public async Task<IHttpActionResult> Post(ResourceView resource) {
        //    var guid = await AppData.AddResourceAsync(resource);
        //    if (guid.ToString() == defaultGuid.ToString())
        //        return (IHttpActionResult)BadRequest("Could not add the resource.");
        //    return Ok(guid);
        //}

        //// PUT api/Resources
        //public async Task<IHttpActionResult> Put(ResourceView resource) {
        //    var affectedRows = await AppData.UpdateResourceAsync(resource);
        //    return affectedRows == 0 ? (IHttpActionResult)BadRequest("could not update the resource.") : Ok(affectedRows);
        //}

        //// DELETE api/Resources
        //public async Task<IHttpActionResult> Delete(ResourceView resource) {
        //    var affectedRows = await AppData.DeleteResourceAsync(resource);
        //    return affectedRows == 0 ? (IHttpActionResult)BadRequest("Could not delete the resource.") : Ok(affectedRows);
        //}
    }
}