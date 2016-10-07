using HomeProperty.View;
using HomeProperty.WebApp.Models;
using System;
using System.Web.Mvc;

namespace HomeProperty.WebApp.Controllers {
    public class ContactController : BaseController {

        /// <summary>
        /// The contact service model.
        /// </summary>
        private IContactServiceModel _contactServiceModel = ServiceModelFactory.ContactServiceModel;

        #region Email Types
        /// <summary>
        /// Gets Email Types.
        /// </summary>
        /// <returns>The collection of Email Types as Json string.</returns>
        [HttpGet]
        public ActionResult GetEmailTypes() {
            return Content(_contactServiceModel.GetEmailTypes());
        }

        /// <summary>
        /// Gets an Email Type by Id.
        /// </summary>
        /// <param name="id">The Email Type Id.</param>
        /// <returns>The Email Type as Json string.</returns>
        [HttpGet]
        public ActionResult GetEmailType(Guid id) {
            return Content(_contactServiceModel.GetEmailType(id));
        }

        /// <summary>
        /// Adds a new Email Type.
        /// </summary>
        /// <param name="emailTypeView">The Email Type DTO.</param>
        /// <returns>The Email Type Id.</returns>
        [HttpPost]
        public ActionResult AddEmailType(EmailTypeView emailTypeView) {
            var id = _contactServiceModel.AddEmailType(emailTypeView);
            return Content(id.ToString());
        }

        /// <summary>
        /// Updates an Email Type.
        /// </summary>
        /// <param name="emailTypeView">The Email Type DTO.</param>
        /// <returns>The number of affected rows.</returns>
        [HttpPut]
        public ActionResult UpdateEmailType(EmailTypeView emailTypeView) {
            var affectedRowsCount = _contactServiceModel.UpdateEmailType(emailTypeView);
            return Content(affectedRowsCount.ToString());
        }

        /// <summary>
        /// Deletes an Email Type.
        /// </summary>
        /// <param name="emailTypeView">The Email Type DTO.</param>
        /// <returns>The number of affected rows.</returns>
        [HttpDelete]
        public ActionResult DeleteEmailType(EmailTypeView emailTypeView) {
            var affectedRowsCount = _contactServiceModel.DeleteEmailType(emailTypeView);
            return Content(affectedRowsCount.ToString());
        }

        #endregion Email Types
    }
}