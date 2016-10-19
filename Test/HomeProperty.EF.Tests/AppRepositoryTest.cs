using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeProperty.Tests {
    using Repository;
    using Settings.Constant;
    using System;
    using System.Threading.Tasks;
    using View.App;

    [TestClass]
    public class AppRepositoryTest {
        #region Setting Up
        private IAppRepository instance;

        public object TestData { get; private set; }

        [TestInitialize]
        public void SettingUp() {
            instance = new AppRepository();
        }
        #endregion Setting Up

        [TestMethod]
        public async Task TestPackagesAsync()
        {
            var results = await instance.GetPackagesAsync();
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
        }

        [TestMethod]
        public async Task TestAddPackageAsync()
        {
            var packageView = new PackageView
            {
                Name = "Free",
                LanguageId = HomeProperty.Fixtures.TestData.Language.Id,
                Description = "Free Package"
            };
            var packageId = await instance.AddPackageAsync(packageView);
            Assert.IsTrue(packageId != null);
            Assert.IsTrue(packageId.ToString() != HomeProperty.Fixtures.TestData.DefaultGuid.ToString());
        }


        //# region Application
        //[TestMethod]
        //public async Task TestAddApplicationAsync() {
        //    var application = new ApplicationView {
        //        Name = "Phone",
        //        Description = "Phone",
        //        ModifiedBy = new Guid(TestData.User.Id)
        //    };
        //    await instance.AddApplicationAsync(application);
        //    Assert.IsNotNull(application.Id);
        //    Assert.IsTrue(application.Id.ToString() != TestData.DefaultGuid.ToString());
        //}

        //[TestMethod]
        //public async Task TestGetApplicationsAsync() {
        //    var results = await instance.GetApplicationsAsync();
        //    Assert.IsNotNull(results);
        //    Assert.IsTrue(results.Count() > 0);
        //}


        //[TestMethod]
        //public async Task TestGetApplicationAsync() {
        //    var results = await instance.GetApplicationAsync(TestData.Application.Id);
        //    Assert.IsNotNull(results);
        //}

        //[TestMethod]
        //public async Task TestUpdateApplicationAsync() {
        //    var application = new ApplicationView {
        //        Id = TestData.Application.Id,
        //        Name = "Test 2 Appication",
        //        Description = "Updated Appication",
        //        ModifiedBy = new Guid(TestData.User.Id)
        //    };
        //    var affectedRows = await instance.UpdateApplicationAsync(application);
        //    Assert.IsNotNull(affectedRows);
        //    Assert.IsTrue(affectedRows > 0);
        //}

        //[TestMethod]
        //public async Task TestDeleteApplicationAsync() {
        //    var affectedRows = await instance.DeleteApplicationAsync(new ApplicationView { Id = TestData.Application.Id });
        //    Assert.IsNotNull(affectedRows);
        //    Assert.IsTrue(affectedRows > 0);
        //}
        //# endregion Application

        //#region Menus
        //[TestMethod]
        //public async Task TestAddMenuAsync() {

        //    var menu = new MenuView {
        //        Name = "Test Add Menu",
        //        Description = "Add MEnu"
        //    };
        //    var menuId = await instance.AddMenuAsync(menu);
        //    Assert.IsTrue(menuId != null);
        //    Assert.IsTrue(menuId.ToString() != TestData.DefaultGuid.ToString());
        //}

        [TestMethod]
        public async Task TestGetMenusAsync() {
            var results = await instance.GetMenusAsync();
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
        }

        [TestMethod]
        public async Task TestGetMenuAsync() {
            var id = new Guid("E4D8FD9E-C44D-E611-B2FB-B888E3BA34E8");
            var result = await instance.GetMenuAsync(id);
            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public async Task TestUpdateMenuAsync() {
        //    var menu = new MenuView {
        //        Id = TestData.Menu.Id,
        //        Name = "Test 2 Menu Name",
        //        Description = "Updated Menu Name",
        //    };
        //    var affectedRows = await instance.UpdateMenuAsync(menu);
        //    Assert.IsNotNull(affectedRows);
        //    Assert.IsTrue(affectedRows > 0);
        //}

        //[TestMethod]
        //public async Task TestDeleteMenuAsync() {
        //    var affectedRows = await instance.DeleteMenuAsync(new MenuView { Id = TestData.Menu.Id });
        //    Assert.IsNotNull(affectedRows);
        //    Assert.IsTrue(affectedRows > 0);
        //}
        //#endregion Menus

        //#region Menu Items
        //[TestMethod]
        //public async Task TestAddMenuItemAsync() {
        //    var menuItem = new MenuItemView {
        //        Name = "Test Menu Item Name3",
        //        LanguageId = TestData.Language.Id,
        //        Url = "http://google.com",
        //        IconUrl = "http://google.com/icon.jpg",
        //        MenuId = TestData.Menu.Id,
        //        ModifiedBy = new Guid(TestData.User.Id)
        //    };
        //    var guid = await instance.AddMenuItemAsync(menuItem);
        //    Assert.IsNotNull(guid);
        //    Assert.IsTrue(guid.ToString() != TestData.DefaultGuid.ToString());
        //    await instance.DeleteMenuItemAsync(new MenuItemView { Id = new Guid(guid.ToString()) });
        //}

        [TestMethod]
        public async Task TestGetMenuItemsAsync() {
            var results = await instance.GetMenuItemsAsync(Constant.EnglishUsCulture);
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
        }

        [TestMethod]
        public async Task TestGetMenuItemAsync() {
            var id = new Guid("E8D8FD9E-C44D-E611-B2FB-B888E3BA34E8");
            var result = await instance.GetMenuItemAsync(id, Constant.EnglishUsCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == id);
        }

        [TestMethod]
        public async Task TestGetMenuItemByMenuNameAsync() {
            string MenuName = "Main Navigation Bar Menu";
            var result = await instance.GetMenuItemsByMenuNameAsync(MenuName, Constant.EnglishUsCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        //[TestMethod]
        //public async Task TestUpdateMenuItemAsync() {
        //    var menuItem = new MenuItemView {
        //        Id = TestData.MenuItem.Id,
        //        Name = "Test Menu Item Updated Name",
        //        Description = "Updated Operation",
        //        Url = "http://fundingpack.com",
        //        MenuId = TestData.Menu.Id,
        //        ModifiedBy = new Guid(TestData.User.Id)
        //    };
        //    var affectedRows = await instance.UpdateMenuItemAsync(menuItem);
        //    Assert.IsNotNull(affectedRows);
        //    Assert.IsTrue(affectedRows > 0);
        //}

        //[TestMethod]
        //public async Task TestDeleteMenuItemAsync() {
        //    var affectedRows = await instance.DeleteMenuItemAsync(new MenuItemView { Id = TestData.MenuItem.Id });
        //    Assert.IsNotNull(affectedRows);
        //    Assert.IsTrue(affectedRows > 0);
        //}
        //#endregion Menu Items

        //#region Menu Child Items
        //[TestMethod]
        //public async Task TestAddMenuChildItemAsync() {
        //    var menuChildItem = new MenuChildItemView {
        //        Name = "Test Menu Child Item Name3",
        //        MenuItemId = TestData.MenuItem.Id,
        //        LanguageId = TestData.Language.Id,
        //        Url = "http://google.com",
        //        IconUrl = "http://google.com/icon.jpg",
        //        //ModifiedBy = new Guid(TestData.User.Id)
        //    };
        //    await instance.AddMenuChildItemAsync(menuChildItem);
        //    Assert.IsNotNull(menuChildItem.Id);
        //    Assert.IsTrue(menuChildItem.Id.ToString() != TestData.DefaultGuid.ToString());
        //}

        //[TestMethod]
        //public async Task TestGetMenuChildItemsAsync() {
        //    var results = await instance.GetMenuChildItemsAsync(Constant.EnglishUsCulture);
        //    Assert.IsNotNull(results);
        //    Assert.IsTrue(results.Count() > 0);
        //}

        //[TestMethod]
        //public async Task TestGetMenuChildItemAsync() {
        //    var result = await instance.GetMenuChildItemAsync(TestData.MenuChildItem.Id, Constant.EnglishUsCulture);
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(result.Id.ToString(), TestData.DefaultGuid.ToString());
        //}

        //[TestMethod]
        //public async Task TestUpdateMenuChildItemAsync() {
        //    var menuChildItem = new MenuChildItemView {
        //        Id = TestData.MenuChildItem.Id,
        //        Name = "Updated Menu Child Item",
        //        Url = "/app/test/get_menus",
        //        Description = "Update Operation",
        //        ModifiedBy = new Guid(TestData.User.Id),
        //        MenuItemId = TestData.MenuItem.Id
        //    };
        //    var affectedRows = await instance.UpdateMenuChildItemAsync(menuChildItem);
        //    Assert.IsNotNull(affectedRows);
        //    Assert.IsTrue(affectedRows > 0);
        //}

        //[TestMethod]
        //public async Task TestDeleteMenuChildItemAsync() {
        //    var affectedRows = await instance.DeleteMenuChildItemAsync(
        //        new MenuChildItemView {
        //            Id = TestData.MenuChildItem.Id,
        //            ModifiedBy = new Guid(TestData.User.Id)
        //        });
        //    Assert.IsNotNull(affectedRows);
        //    Assert.IsTrue(affectedRows > 0);
        //}

        //#endregion Menu Child Items

        //#region Resources
        //[TestMethod]
        //public async Task TestAddResourceAsync() {
        //    var resource = new ResourceView {
        //        Name = "Person_Age",
        //        Culture = "en-US",
        //        Value = "Age",
        //        ModifiedBy = new Guid(TestData.User.Id),
        //        ApplicationId = TestData.Application.Id
        //    };
        //    await instance.AddResourceAsync(resource);
        //    Assert.IsNotNull(resource.Id);
        //    Assert.IsTrue(resource.Id.ToString() != TestData.DefaultGuid.ToString());
        //}

        //[TestMethod]
        //public async Task TestGetResourcesAsync() {
        //    var results = await instance.GetResourcesAsync();
        //    Assert.IsNotNull(results);
        //    Assert.IsTrue(results.Count() > 0);
        //}

        //[TestMethod]
        //public async Task TestGetResourceAsync() {
        //    var result = await instance.GetResourceAsync(TestData.Resource.Id);
        //    Assert.IsNotNull(result);
        //    Assert.IsTrue(result.Id == TestData.Resource.Id);
        //}

        //[TestMethod]
        //public async Task TestGetResourceAsyncByName() {
        //    var result = await instance.GetResourceAsync("en-US", "Person_FirstName");
        //    Assert.IsNotNull(result);
        //    Assert.IsTrue(result.Id == TestData.Resource.Id);
        //}

        //[TestMethod]
        //public async Task TestUpdateResourceAsync() {
        //    var resource = new ResourceView {
        //        Id = TestData.Resource.Id,
        //        Name = "Person_Ssn",
        //        Value = "SSN",
        //        ModifiedBy = new Guid(TestData.User.Id),
        //        ModifiedDate = DateTime.UtcNow
        //    };
        //    var affectedRows = await instance.UpdateResourceAsync(resource);
        //    Assert.IsNotNull(affectedRows);
        //    Assert.IsTrue(affectedRows > 0);
        //}

        //[TestMethod]
        //public async Task TestDeleteResourceAsync() {
        //    var affectedRows = await instance.DeleteResourceAsync(
        //        new ResourceView {
        //            Id = TestData.Resource.Id,
        //            ModifiedBy = new Guid(TestData.User.Id),
        //            ModifiedDate = DateTime.UtcNow
        //        });
        //    Assert.IsNotNull(affectedRows);
        //    Assert.IsTrue(affectedRows > 0);
        //}

        //#endregion Resources
    }
}
