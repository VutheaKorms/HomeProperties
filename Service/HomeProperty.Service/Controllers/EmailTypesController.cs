using HomeProperty.EF.Repository;
using HomeProperty.View;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HomeProperty.Service.Controllers {
    [Authorize]
    public class EmailTypesController : ApiController {
        private Guid defaultGuid;

        private IContactRepository _contactRepository;

        public IContactRepository ContactRepository {
            get { return _contactRepository ?? new ContactRepository(); }
            set { _contactRepository = value; }
        }

        public EmailTypesController() {
            _contactRepository = new ContactRepository();
            defaultGuid = new Guid("00000000-0000-0000-0000-000000000000");
        }

        // GET api/emailTypes
        public async Task<List<EmailTypeView>> Get() {
            return await ContactRepository.GetEmailTypesAsync();
        }

        // GET api/emailTypes/id
        public async Task<EmailTypeView> Get(Guid id) {
            return await ContactRepository.GetEmailTypeAsync(id);
        }

        // POST api/emailTypes
        public async Task<IHttpActionResult> Post(EmailTypeView emailTypeView) {
            var guid = await ContactRepository.AddEmailTypeAsync(emailTypeView);
            if (guid == null || guid.ToString() == defaultGuid.ToString())
                return (IHttpActionResult)BadRequest("Could not add the email type.");
            return Ok(guid);
        }

        //// PUT api/emailTypes
        //public async Task<IHttpActionResult> Put(EmailTypeView emailTypeView) {
        //    var affectedRows = await ContactRepository.UpdateEmailTypeAsync(emailTypeView);
        //    return affectedRows == 0 ? (IHttpActionResult)BadRequest("Could not update the email type.") : Ok(affectedRows);
        //}

        //// DELETE api/emailTypes
        //public async Task<IHttpActionResult> Delete(EmailTypeView emailTypeView) {
        //    var affectedRows = await ContactRepository.DeleteEmailTypeAsync(emailTypeView);
        //    return affectedRows == 0 ? (IHttpActionResult)BadRequest("Could not delete the email type.") : Ok(affectedRows);
        //}
    }
}