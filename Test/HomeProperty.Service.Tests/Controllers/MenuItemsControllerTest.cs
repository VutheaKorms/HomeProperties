using HomeProperty.Fixtures;
using HomeProperty.Service.Controllers;
using HomeProperty.View;
using HomeProperty.View.QueryParameter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeProperty.Service.Tests.Controllers {
    [TestClass]
    public class MenuItemsControllerTest : ServiceBaseController {
        MenuItemsController _controller;

        MenuItemsController Controller { get { return _controller ?? new MenuItemsController(); } }

        public MenuItemsControllerTest() {
            _controller = new MenuItemsController();
        }

        [TestMethod]
        public async Task TestCreateMenuItem() {
            SetUpController(Controller,
            TestData.ServiceEndPont, "api/menuItems", "menuItems", HttpMethod.Post);
            var response = await Controller.Post(new MenuItemView {
                Name = "Service Test Menu Item Name",
                ModifiedBy = new Guid(TestData.User.Id),
                Description = "Save Operation from Service",
                MenuId = TestData.Menu.Id
            });
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task TestGetMenuItems() {
            var param = new MenuItemQueryParameter();
            var result = await Controller.Get(param);
            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public async Task TestGetMenuItems() {
        //    var result = await Controller.Get();
        //    Assert.IsNotNull(result);
        //}


        [TestMethod]
        public async Task TestGetMenuItem() {
            Controller.Request = new HttpRequestMessage();
            Controller.Configuration = new System.Web.Http.HttpConfiguration();
            var result = await Controller.Get(TestData.MenuItem.Id);
            Assert.AreEqual(TestData.MenuItem.Id, result.Id);
        }

        //[TestMethod]
        //public async Task TestUpdateMenuItem() {
        //    SetUpController(Controller,
        //    TestData.ServiceEndPont, "api/menuItems", "menuItems", HttpMethod.Put);
        //    var response = await Controller.Put(new MenuItemView {
        //        Id = TestData.MenuItem.Id,
        //        Name = "Update Test Menu Item Name",
        //        ModifiedBy = new Guid(TestData.User.Id),
        //        Description = "Update Operation"
        //    });
        //    Assert.IsNotNull(response);
        //}

        //[TestMethod]
        //public async Task TestDeleteMenuItem() {
        //    SetUpController(Controller,
        //    TestData.ServiceEndPont, "api/menuItems", "menuItems", HttpMethod.Put);
        //    var response = await Controller.Put(new MenuItemView {
        //        Id = TestData.MenuItem.Id,
        //        ModifiedBy = new Guid(TestData.User.Id)
        //    });
        //    Assert.IsNotNull(response);
        //}

        //[TestMethod]
        //public async Task TestGetMenuItemsByName() {
        //    Controller.Request = new HttpRequestMessage();
        //    Controller.Configuration = new System.Web.Http.HttpConfiguration();
        //    var menuName = Utility.GetDescription(MenuNameEnum.MainNavigationBarMenu);
        //    // English culture 
        //    var results = await Controller.Get(menuName);
        //    Assert.IsNotNull(results);
        //    // Khmer culture 
        //    results = await Controller.Get(menuName, Constant.KhmerCulture);
        //    Assert.IsNotNull(results);
        //}
    }
}
