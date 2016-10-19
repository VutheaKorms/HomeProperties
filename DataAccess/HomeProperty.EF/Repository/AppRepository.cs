using AutoMapper;
using HomeProperty.App;
using HomeProperty.DbContexts;
using HomeProperty.EF.App;
using HomeProperty.Settings.Util;
using HomeProperty.View;
using HomeProperty.View.App;
using HomeProperty.View.QueryParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeProperty.Repository {
    public class AppRepository : RepositoryBase, IAppRepository {
        #region Setting up
        public IList<string> ErrorMessages { get; private set; }
        public Guid DefaultGuid = new Guid("00000000-0000-0000-0000-000000000000");

        public AppRepository() {
            ErrorMessages = new List<string>();
        }
        #endregion Setting up

        #region Menus

        public Task<Guid> GetMenuIdAsync(string menuName) {
            try {
                return Task.Factory.StartNew(() => {
                    using (var context = new MainDbContext()) {
                        var menu = context.Menus
                            .FirstOrDefault(x => x.IsActive && string.Compare(x.Name, menuName, true) == 0);
                        return menu != null ? menu.Id : Guid.Empty;
                    }
                });
            } catch (Exception ex) {
                AddErrorLog(ex, this.ToString());
            }
            return null;
        }

        public Task<MenuView> GetMenuAsync(Guid id) {
            try {
                return Task.Factory.StartNew(() => {
                    using (var context = new MainDbContext()) {
                        var menu = context.Menus
                            .FirstOrDefault(x => x.IsActive && x.Id == id);
                        return menu != null ? new MenuView {
                            Id = menu.Id,
                            Name = menu.Name,
                            Description = menu.Description,
                            MenuItems = menu.MenuItems.Select(y => new MenuItemView {
                                Id = y.Id,
                                Name = y.Name,
                                Description = y.Description,
                                IconUrl = y.IconUrl,
                                IsActive = y.IsActive,
                                LanguageId = y.LanguageId,
                                Url = y.Url,
                                MenuId = y.MenuId,
                                ModifiedBy = y.ModifiedBy,
                                ModifiedDate = y.ModifiedDate,
                                MenuChildItems = y.MenuChildItems.Select(z => new MenuChildItemView {
                                    Id = z.Id,
                                    Description = z.Description,
                                    IconUrl = z.IconUrl,
                                    IsActive = z.IsActive,
                                    LanguageId = z.LanguageId,
                                    MenuItemId = z.MenuItemId,
                                    ModifiedBy = z.ModifiedBy,
                                    ModifiedDate = z.ModifiedDate,
                                    Name = z.Name,
                                    Url = z.Url
                                }).ToList()
                            }).ToList(),
                            ModifiedBy = menu.ModifiedBy,
                            ModifiedDate = menu.ModifiedDate,
                            IsActive = menu.IsActive
                        } : null;
                    }
                });
            } catch (Exception ex) {
                AddErrorLog(ex, this.ToString());
            }
            return null;
        }

        public Task<List<MenuView>> GetMenusAsync() {
            try {
                return Task.Factory.StartNew(() => {
                    using (var context = new MainDbContext()) {
                        return context.Menus
                            .Where(x => x.IsActive)
                            .Select(x => new MenuView {
                                Id = x.Id,
                                Name = x.Name,
                                Description = x.Description,
                                MenuItems = x.MenuItems.Where(mi => mi.IsActive).Select(y => new MenuItemView {
                                    Id = y.Id,
                                    Name = y.Name,
                                    Description = y.Description,
                                    IconUrl = y.IconUrl,
                                    IsActive = y.IsActive,
                                    LanguageId = y.LanguageId,
                                    Url = y.Url,
                                    MenuId = y.MenuId,
                                    ModifiedBy = y.ModifiedBy,
                                    ModifiedDate = y.ModifiedDate,
                                    MenuChildItems = y.MenuChildItems.Where(mci => mci.IsActive)
                                    .Select(z => new MenuChildItemView {
                                        Id = z.Id,
                                        Description = z.Description,
                                        IconUrl = z.IconUrl,
                                        IsActive = z.IsActive,
                                        LanguageId = z.LanguageId,
                                        MenuItemId = z.MenuItemId,
                                        ModifiedBy = z.ModifiedBy,
                                        ModifiedDate = z.ModifiedDate,
                                        Name = z.Name,
                                        Url = z.Url
                                    }).ToList()
                                }).ToList(),
                                ModifiedBy = x.ModifiedBy,
                                ModifiedDate = x.ModifiedDate,
                                IsActive = x.IsActive,
                            }).OrderBy(x => x.Id).ToList();
                    }
                });
            } catch (Exception ex) {
                AddErrorLog(ex, this.ToString());
            }
            return null;
        }


        public Task<Guid> AddMenuAsync(MenuView menuView) {
            Mapper.CreateMap<MenuView, Menu>();
            var menu = Mapper.Map<Menu>(menuView);
            try {
                return Task.Factory.StartNew(() => {
                    using (var context = new MainDbContext()) {
                        var currentMenu = context.Menus
                       .FirstOrDefault(x => x.Name == menu.Name && x.IsActive);
                        if (currentMenu != null)
                            throw new ArgumentException
                            (string.Format("Menu Name: {0} already exists.", menu.Id));
                        context.Menus.Add(menu);
                        context.SaveChanges();
                        return menu.Id;
                    }
                });
            } catch (Exception ex) {
                AddErrorLog(ex, this.ToString());
            }
            return null;
        }

        public Task<int> UpdateMenuAsync(MenuView menuView) {
            Mapper.CreateMap<MenuView, Menu>();
            var menu = Mapper.Map<Menu>(menuView);
            try {
                return Task.Factory.StartNew(() => {
                    using (var context = new MainDbContext()) {
                        var currentMenu = context.Menus
                        .FirstOrDefault(x => x.Id == menu.Id && x.IsActive);
                        if (currentMenu == null)
                            throw new ArgumentException
                            (string.Format("Menu Id: {0} cannot be found.", menu.Id));
                        currentMenu.Name = menu.Name;
                        currentMenu.Description = menu.Description;
                        currentMenu.ModifiedBy = menu.ModifiedBy;
                        currentMenu.ModifiedDate = DateTime.UtcNow;
                        currentMenu.ModifiedDate = DateTime.UtcNow;
                        return context.SaveChanges();
                    }
                });
            } catch (Exception ex) {
                AddErrorLog(ex, this.ToString());
            }
            return null;
        }

        public Task<int> DeleteMenuAsync(MenuView menuView) {
            Mapper.CreateMap<MenuView, Menu>();
            var menu = Mapper.Map<Menu>(menuView);
            try {
                return Task.Factory.StartNew(() => {
                    using (var context = new MainDbContext()) {
                        var currentMenu = context.Menus
                        .FirstOrDefault(x => x.Id == menu.Id && x.IsActive);
                        if (currentMenu == null)
                            throw new ArgumentException
                            (string.Format("Menu id: {0} cannot be found.", menu.Id));
                        currentMenu.IsActive = false;
                        currentMenu.ModifiedBy = menu.ModifiedBy;
                        currentMenu.ModifiedDate = DateTime.UtcNow;
                        return context.SaveChanges();
                    }
                });
            } catch (Exception ex) {
                AddErrorLog(ex, this.ToString());
            }
            return null;
        }

        public Task<int> DeleteMenusAsync(List<MenuView> menus) {
            try {
                return Task.Factory.StartNew(() => {
                    using (var context = new MainDbContext()) {
                        menus.ForEach(m => {
                            var menu = context.Menus.FirstOrDefault(tr => tr.Id == m.Id && tr.IsActive);
                            if (menu != null) {
                                menu.IsActive = false;
                                menu.ModifiedDate = DateTime.UtcNow;
                            }
                        });
                        if (context.ChangeTracker.HasChanges())
                            return context.SaveChanges();
                        return 0;
                    }
                });
            } catch (Exception ex) {
                AddErrorLog(ex, this.ToString());
            }
            return null;
        }

        #endregion Menus

        #region Menu Items

        public Task<MenuItemView> GetMenuItemAsync(Guid id, string culture = HomeProperty.Settings.Constant.Constant.EnglishUsCulture) {
            try {
                return Task.Factory.StartNew(() => {
                    using (var context = new MainDbContext()) {
                        var currentLanguage = GetCurrentLanguage(culture);
                        if (currentLanguage == null)
                            throw new ArgumentException
                            (string.Format("Invalid locale culture: {0}.", culture));
                        var x = context.MenuItems
                                .FirstOrDefault(mi => mi.Id == id && mi.IsActive
                                    && mi.LanguageId == currentLanguage.Id);

                        return x != null ? new MenuItemView {
                            Id = x.Id,
                            Name = x.Name,
                            Url = x.Url,
                            IconUrl = x.IconUrl,
                            MenuChildItems = x.MenuChildItems
                            .Select(y => new MenuChildItemView {
                                Id = y.Id,
                                Description = y.Description,
                                IconUrl = y.IconUrl,
                                IsActive = y.IsActive,
                                LanguageId = y.LanguageId,
                                MenuItemId = y.MenuItemId,
                                ModifiedBy = y.ModifiedBy,
                                ModifiedDate = y.ModifiedDate,
                                Name = y.Name,
                                Url = y.Url
                            })
                            .Where(y => y.IsActive && y.LanguageId == currentLanguage.Id).ToList(),
                            MenuId = x.MenuId,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedDate = x.ModifiedDate,
                            IsActive = x.IsActive,
                            Description = x.Description
                        } : null;
                    }
                });
            } catch (Exception ex) {
                AddErrorLog(ex, this.ToString());
            }
            return null;
        }

        public Task<List<MenuItemView>> GetMenuItemsByMenuNameAsync(
            string menuName,
            string culture = HomeProperty.Settings.Constant.Constant.EnglishUsCulture) {
            try {
                return Task.Factory.StartNew(() => {
                    var currentLanguage = GetCurrentLanguage(culture);
                    var menuId = GetMenuIdAsync(menuName);
                    using (var context = new MainDbContext()) {
                        return context.MenuItems
                            .Where(x => x.IsActive && x.LanguageId == currentLanguage.Id
                            && x.MenuId == menuId.Result)
                            .Select(x => new MenuItemView {
                                Id = x.Id,
                                Name = x.Name,
                                Url = x.Url,
                                IconUrl = x.IconUrl,
                                MenuChildItems = x.MenuChildItems
                       .Select(y => new MenuChildItemView {
                           Id = y.Id,
                           Name = y.Name,
                           Url = y.Url,
                           IconUrl = y.IconUrl,
                           IsActive = y.IsActive,
                           LanguageId = y.LanguageId,
                           MenuItemId = y.MenuItemId,
                           ModifiedBy = y.ModifiedBy,
                           ModifiedDate = y.ModifiedDate,
                           Description = y.Description
                       })
                       .Where(y => y.LanguageId == currentLanguage.Id).ToList(),
                                MenuId = x.MenuId,
                                ModifiedBy = x.ModifiedBy,
                                ModifiedDate = x.ModifiedDate,
                                IsActive = x.IsActive,
                                Description = x.Description
                            }
                             ).ToList();
                    }
                });
            } catch (Exception ex) {
                AddErrorLog(ex, this.ToString());
            }
            return null;
        }

        public Task<Guid> AddMenuItemAsync(MenuItemView menuItemView) {
            Mapper.CreateMap<MenuItemView, MenuItem>();
            var menuItem = Mapper.Map<MenuItem>(menuItemView);
            try {
                return Task.Factory.StartNew(() => {
                    using (var context = new MainDbContext()) {
                        var currentMenuItem = context.MenuItems
                        .FirstOrDefault(x => x.Name == menuItem.Name && x.IsActive);
                        if (currentMenuItem != null)
                            throw new ArgumentException
                            (string.Format("Menu Item Name: {0} already exists.", menuItem.Name));
                        context.MenuItems.Add(menuItem);
                        context.SaveChanges();
                        return menuItem.Id;
                    }
                });
            } catch (Exception ex) {
                AddErrorLog(ex, this.ToString());
            }
            return null;
        }

        public Task<List<MenuItemView>> GetMenuItemsAsync(string culture) {
            try {
                return Task.Factory.StartNew(() => {
                    var currentLanguage = GetCurrentLanguage(culture);
                    using (var context = new MainDbContext()) {
                        return (from x in context.MenuItems
                                join menu in context.Menus
                                on x.MenuId equals menu.Id
                                where x.IsActive && x.LanguageId == currentLanguage.Id
                                select new MenuItemView() {
                                    Id = x.Id,
                                    Name = x.Name,
                                    Url = x.Url,
                                    IconUrl = x.IconUrl,
                                    MenuName = menu.Name,
                                    MenuChildItems = x.MenuChildItems
                                .Select(y => new MenuChildItemView {
                                    Id = y.Id,
                                    Name = y.Name,
                                    Url = y.Url,
                                    IconUrl = y.IconUrl,
                                    IsActive = y.IsActive,
                                    LanguageId = y.LanguageId,
                                    MenuItemId = y.MenuItemId,
                                    ModifiedBy = y.ModifiedBy,
                                    ModifiedDate = y.ModifiedDate,
                                    Description = y.Description
                                })
                                .Where(y => y.LanguageId == currentLanguage.Id).ToList(),
                                    MenuId = x.MenuId,
                                    LanguageId = x.LanguageId,
                                    ModifiedBy = x.ModifiedBy,
                                    ModifiedDate = x.ModifiedDate,
                                    IsActive = x.IsActive,
                                    Description = x.Description
                                }).ToList();
                    }
                });
            } catch (Exception ex) {
                AddErrorLog(ex, this.ToString());
            }
            return null;
        }

        public Task<List<MenuItemView>> GetMenuItemsAsync(
            string culture = HomeProperty.Settings.Constant.Constant.EnglishUsCulture,
            MenuItemQueryParameter parameter = null) {
            try {
                return Task.Factory.StartNew(() => {
                    var currentLanguage = GetCurrentLanguage(culture);
                    using (var context = new MainDbContext()) {
                        var result = (from x in context.MenuItems
                                      join menu in context.Menus
                                      on x.MenuId equals menu.Id
                                      where x.IsActive
                                      select new MenuItemView() {
                                          Id = x.Id,
                                          Name = x.Name,
                                          Url = x.Url,
                                          IconUrl = x.IconUrl,
                                          MenuName = menu.Name,
                                          LanguageName = x.Language.Name,
                                          MenuChildItems = x.MenuChildItems
                                      .Select(y => new MenuChildItemView {
                                          Id = y.Id,
                                          Name = y.Name,
                                          Url = y.Url,
                                          IconUrl = y.IconUrl,
                                          IsActive = y.IsActive,
                                          LanguageId = y.LanguageId,
                                          MenuItemId = y.MenuItemId,
                                          ModifiedBy = y.ModifiedBy,
                                          ModifiedDate = y.ModifiedDate,
                                          Description = y.Description
                                      }).ToList(),
                                          MenuId = x.MenuId,
                                          LanguageId = x.LanguageId,
                                          ModifiedBy = x.ModifiedBy,
                                          ModifiedDate = x.ModifiedDate,
                                          IsActive = x.IsActive,
                                          Description = x.Description
                                      }).ToList<MenuItemView>();

                        if (!string.IsNullOrEmpty(parameter.languageId))
                            result = result.Where(m => m.LanguageId == new Guid(parameter.languageId)).ToList();

                        if (currentLanguage != null)
                            result = result.Where(m => m.LanguageId == currentLanguage.Id).ToList();

                        if (parameter.MenuId != Utility.DefaultGuid)
                            result = result.Where(m => m.MenuId == parameter.MenuId).ToList();

                        if (!string.IsNullOrEmpty(parameter.MenuName))
                            result = result.Where(m => string.Compare(m.MenuName, parameter.MenuName, true) == 0).ToList();

                        return result;
                    }
                });
            } catch (Exception ex) {
                AddErrorLog(ex, this.ToString());
            }
            return null;
        }

        #endregion MenuItems

        #region Package
        public Task<List<PackageView>> GetPackagesAsync()
        {
            try
            {
                return Task.Factory.StartNew(() => {
                    using (var context = new MainDbContext())
                    {
                        return context.Packages
                            .Where(x => x.IsActive)
                            .Select(x => new PackageView
                            {
                                Id = x.Id,
                                Name = x.Name,
                                LanguageId = x.LanguageId,
                                Description = x.Description,
                                ModifiedBy = x.ModifiedBy,
                                ModifiedDate = x.ModifiedDate,
                                Duration = x.Duration,
                                NumberPhoto = x.NumberPhoto,
                                NumberProperty = x.NumberProperty,
                                NumberVideo = x.NumberVideo,
                                Price = x.Price,
                                Type = x.Type,
                                IsActive = x.IsActive,
                            }).OrderBy(x => x.Id).ToList();
                    }
                });
            }
            catch (Exception ex)
            {
                AddErrorLog(ex, this.ToString());
            }
            return null;
        }

        public Task<Guid> AddPackageAsync(PackageView packageView)
        {
            Mapper.CreateMap<PackageView, Package>();
            var package = Mapper.Map<Package>(packageView);
            try
            {
                return Task.Factory.StartNew(() => {
                    using (var context = new MainDbContext())
                    {
                        var p = context.Packages.FirstOrDefault(x => x.Name == package.Name && x.IsActive);
                        if (p != null)
                            throw new ArgumentException
                            (string.Format("Package name: {0} already exists.",
                                package.Name));
                        context.Packages.Add(package);
                        context.SaveChanges();
                        return package.Id;
                    }
                });
            }
            catch (Exception ex)
            {
                AddErrorLog(ex, this.ToString());
            }
            return null;
        }

        #endregion


    }
}
