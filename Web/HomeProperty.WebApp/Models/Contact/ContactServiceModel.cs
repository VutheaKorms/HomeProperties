using HomeProperty.View;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace HomeProperty.WebApp.Models {
    public class ContactServiceModel : ServiceModelBase, IContactServiceModel {

        #region Routes 

        private const string _emailTypesRoute = "Api/EmailTypes";

        #endregion Routes

        #region Email Types
        /// <summary>
        /// Get all Email Types. 
        /// </summary>
        /// <returns>The collection of Email Types as JSON string.</returns>
        public string GetEmailTypes() {
            return MakeServiceRequestCall(_emailTypesRoute);
        }

        /// <summary>
        /// Gets a single Email Type by Id.
        /// </summary>
        /// <param name="id">The Email Type Id</param>
        /// <returns>The Email Type as JSON string.</returns>
        public string GetEmailType(Guid id) {
            return MakeServiceRequestCall(string.Format("{0}/{1}", _emailTypesRoute, id));
        }

        /// <summary>
        /// Gets all instances of Email Types.
        /// </summary>
        /// <returns>The collection of Email Types as IEnumerable instances.</returns>
        public IEnumerable<EmailTypeView> GetEmailTypeInstances() {
            var json = MakeRequestCall(_emailTypesRoute);
            return new JavaScriptSerializer().Deserialize<IEnumerable<EmailTypeView>>(json);
        }

        /// <summary>
        /// Gets an instance of Email Type View.
        /// </summary>
        /// <returns>The Email Type View instance.</returns>
        public EmailTypeView GetEmailTypeInstance(Guid id) {
            var json = MakeServiceRequestCall(string.Format("{0}/{1}", _emailTypesRoute, id));
            return new JavaScriptSerializer().Deserialize<EmailTypeView>(json);
        }

        /// <summary>
        /// Adds an Email Type.
        /// </summary>
        /// <param name="emailTypeView">The instance of Email Type View.</param>
        /// <returns>The Email Type Id as Guid.</returns>
        public Guid AddEmailType(EmailTypeView emailTypeView) {
            var json = new JavaScriptSerializer().Serialize(emailTypeView);
            if (string.IsNullOrEmpty(json))
                throw new ArgumentNullException("The Json string of Email Type View is null.");

            var emailTypeId = MakeRequestCall(_emailTypesRoute, json, Enum.ApiServiceType.Post);
            return new Guid(emailTypeId.ToString());
        }

        /// <summary>
        /// Updates an email type. 
        /// </summary>
        /// <param name="emailTypeView">The instance of email type instance.</param>
        /// <returns>The affected rows count as Integer.</returns>
        public int UpdateEmailType(EmailTypeView emailTypeView) {
            var json = new JavaScriptSerializer().Serialize(emailTypeView);
            if (string.IsNullOrEmpty(json))
                throw new ArgumentNullException("The Json string of Email Type View is null.");

            var affectedRowsCount = MakeRequestCall(_emailTypesRoute, json, Enum.ApiServiceType.Put);
            return !string.IsNullOrEmpty(affectedRowsCount) ?
                Int32.Parse(affectedRowsCount) : 0;
        }

        /// <summary>
        /// Deletes an email type.
        /// </summary>
        /// <param name="emailTypeView">The email type instance.</param>
        /// <returns>The affected rows count as Integer.</returns>
        public int DeleteEmailType(EmailTypeView emailTypeView) {
            var json = new JavaScriptSerializer().Serialize(emailTypeView);
            if (string.IsNullOrEmpty(json))
                throw new ArgumentNullException("The Json string of Email Type View is null.");

            var affectedRowsCount = MakeRequestCall(_emailTypesRoute, json, Enum.ApiServiceType.Delete);
            return !string.IsNullOrEmpty(affectedRowsCount) ?
               Int32.Parse(affectedRowsCount) : 0;
        }

        #endregion Email Types

    }
}