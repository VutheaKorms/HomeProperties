using HomeProperty.View;
using HomeProperty.View.App;
using System;
using System.Collections.Generic;

namespace HomeProperty.WebApp.Models {
    public interface IContactServiceModel {

        #region Email Types 
        string GetEmailTypes();
        string GetEmailType(Guid id);
        IEnumerable<EmailTypeView> GetEmailTypeInstances();
        EmailTypeView GetEmailTypeInstance(Guid id);
        Guid AddEmailType(EmailTypeView emailTypeView);
        int UpdateEmailType(EmailTypeView emailTypeView);
        int DeleteEmailType(EmailTypeView emailTypeView);
        #endregion Email Types

        #region Package
        string GetPackages();
        Guid AddPackage(PackageView packageView);
        #endregion

    }
}
