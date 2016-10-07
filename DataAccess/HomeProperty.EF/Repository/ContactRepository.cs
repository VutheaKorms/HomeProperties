using AutoMapper;
using HomeProperty.Contacts;
using HomeProperty.DbContexts;
using HomeProperty.Repository;
using HomeProperty.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeProperty.EF.Repository {
    public class ContactRepository : RepositoryBase, IContactRepository {
        #region Setting up
        public IList<string> ErrorMessages { get; private set; }
        public Guid DefaultGuid = new Guid("00000000-0000-0000-0000-000000000000");

        public ContactRepository() {

            ErrorMessages = new List<string>();
        }
        #endregion Setting up

        #region EmailTypes

        public Task<List<EmailTypeView>> GetEmailTypesAsync() {
            try {
                return Task.Factory.StartNew(() => {
                    using (var context = new MainDbContext()) {
                        return context.EmailTypes
                            .Where(x => x.IsActive)
                            .Select(x => new EmailTypeView {
                                Id = x.Id,
                                Name = x.Name,
                                LanguageId = x.LanguageId,
                                Description = x.Description,
                                ModifiedBy = x.ModifiedBy,
                                ModifiedDate = x.ModifiedDate,
                                Emails = x.Emails.Select(e => new EmailView {
                                    Id = e.Id,
                                    Address = e.Address,
                                    Description = e.Description,
                                    IsPrimary = e.IsPrimary,
                                    ModifiedBy = e.ModifiedBy,
                                    ModifiedDate = e.ModifiedDate,
                                    IsActive = e.IsActive
                                }).ToList(),
                                IsActive = x.IsActive,
                            }).OrderBy(x => x.Id).ToList();
                    }
                });
            } catch (Exception ex) {
                AddErrorLog(ex, this.ToString());
            }
            return null;
        }

        public Task<EmailTypeView> GetEmailTypeAsync(Guid id, string culture = HomeProperty.Settings.Constant.Constant.EnglishUsCulture) {
            try {
                return Task.Factory.StartNew(() => {
                    using (var context = new MainDbContext()) {
                        context.Configuration.LazyLoadingEnabled = true;
                        context.Configuration.ProxyCreationEnabled = true;
                        var currentLanguage = GetCurrentLanguage(culture);
                        if (currentLanguage == null)
                            throw new ArgumentException
                            (string.Format("Invalid locale culture: {0}.", culture));
                        var emailTypes = context.EmailTypes.FirstOrDefault(x => x.IsActive && x.Id == id
                            && x.LanguageId == currentLanguage.Id);
                        return emailTypes != null ? new EmailTypeView {
                            Id = emailTypes.Id,
                            Name = emailTypes.Name,
                            Description = emailTypes.Description,
                            ModifiedBy = emailTypes.ModifiedBy,
                            ModifiedDate = emailTypes.ModifiedDate,
                            IsActive = emailTypes.IsActive,
                            LanguageId = emailTypes.LanguageId,
                            Emails = emailTypes.Emails.Select(e => new EmailView {
                                Id = e.Id,
                                Address = e.Address,
                                EmailTypeId = e.EmailTypeId,
                                IsPrimary = e.IsPrimary,
                                Description = e.Description,
                                ModifiedBy = e.ModifiedBy,
                                ModifiedDate = e.ModifiedDate,
                                IsActive = e.IsActive
                            }).Where(e => e.IsActive).ToList()
                        } : null;
                    }
                });
            } catch (Exception ex) {
                AddErrorLog(ex, this.ToString());
            }
            return null;
        }

        public Task<Guid> AddEmailTypeAsync(EmailTypeView emailTypeView) {
            Mapper.CreateMap<EmailTypeView, EmailType>();
            var emailType = Mapper.Map<EmailType>(emailTypeView);
            try {
                return Task.Factory.StartNew(() => {
                    using (var context = new MainDbContext()) {
                        var e = context.EmailTypes.FirstOrDefault(x => x.Name == emailType.Name && x.IsActive);
                        if (e != null)
                            throw new ArgumentException
                            (string.Format("Email type name: {0} already exists.",
                                emailType.Name));
                        context.EmailTypes.Add(emailType);
                        context.SaveChanges();
                        return emailType.Id;
                    }
                });
            } catch (Exception ex) {
                AddErrorLog(ex, this.ToString());
            }
            return null;
        }

        #endregion EmailTypes

    }
}
