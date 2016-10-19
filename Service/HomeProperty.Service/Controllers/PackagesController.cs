using HomeProperty.Repository;
using HomeProperty.View.App;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HomeProperty.Service.Controllers
{
    [Authorize]
    public class PackagesController : ApiController
    {
        private Guid defaultGuid;
        private IAppRepository _appRepository;

        public IAppRepository AppRepository
        {
            get { return _appRepository ?? new AppRepository(); }
            set { _appRepository = value; }
        }

        public PackagesController()
        {
            _appRepository = new AppRepository();
            defaultGuid = new Guid("00000000-0000-0000-0000-000000000000");
        }

        // GET api/packages
        public async Task<List<PackageView>> Get()
        {
            return await AppRepository.GetPackagesAsync();
        }

        // POST api/packages
        public async Task<IHttpActionResult> Post(PackageView packageView)
        {
            var guid = await AppRepository.AddPackageAsync(packageView);
            if (guid == null || guid.ToString() == defaultGuid.ToString())
                return (IHttpActionResult)BadRequest("Could not add the package.");
            return Ok(guid);
        }

    }
}