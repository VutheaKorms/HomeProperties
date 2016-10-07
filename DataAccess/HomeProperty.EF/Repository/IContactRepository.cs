using HomeProperty.View;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeProperty.EF.Repository {
    public interface IContactRepository {

        #region EmailTypes
        Task<List<EmailTypeView>> GetEmailTypesAsync();
        Task<EmailTypeView> GetEmailTypeAsync(Guid id, string culture = HomeProperty.Settings.Constant.Constant.EnglishUsCulture);
        Task<Guid> AddEmailTypeAsync(EmailTypeView emailTypeView);
        #endregion EmailTypes

    }
}
