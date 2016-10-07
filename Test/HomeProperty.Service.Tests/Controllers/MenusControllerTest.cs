using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeProperty.Service.Tests.Controllers {
    using Fixtures;
    using Service.Controllers;
    using Settings.Util;
    using View;

    [TestClass]
    public class MenusControllerTest : ServiceBaseController {
        MenusController _controller;

        MenusController Controller { get { return _controller ?? new MenusController(); } }

        public MenusControllerTest() {
            _controller = new MenusController();
        }

        [TestMethod]
        public async Task TestCreateMenu() {
            SetUpController(Controller,
            TestData.ServiceEndPont, "api/menus", "menus", HttpMethod.Post);
            var response = await Controller.Post(new MenuView {
                Name = "Service Test Menu Name",
                ModifiedBy = new Guid(TestData.User.Id),
                Description = "Save Operation from Service"
            });
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task TestGetMenus() {
            var result = await Controller.Get();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task TestGetMenu() {
            Controller.Request = new System.Net.Http.HttpRequestMessage();
            Controller.Configuration = new System.Web.Http.HttpConfiguration();
            var result = await Controller.Get(TestData.Menu.Id);
            Assert.AreEqual(TestData.Menu.Id, result.Id);
        }

        [TestMethod]
        public async Task TestUpdateMenu() {
            SetUpController(Controller,
            TestData.ServiceEndPont, "api/menus", "menus", HttpMethod.Put);
            var response = await Controller.Put(new MenuView {
                Id = TestData.Menu.Id,
                Name = "Update Test Menu Name",
                ModifiedBy = new Guid(TestData.User.Id),
                Description = "Update Operation"
            });
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task TestDeleteMenu() {
            SetUpController(Controller,
            TestData.ServiceEndPont, "api/menus", "menus", HttpMethod.Put);
            var response = await Controller.Put(new MenuView {
                Id = TestData.Menu.Id,
                ModifiedBy = new Guid(TestData.User.Id)
            });
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task TestGetMenuIdByName() {
            Controller.Request = new HttpRequestMessage();
            Controller.Configuration = new System.Web.Http.HttpConfiguration();
            var menuId = await Controller.GetMenuIdByName(TestData.Menu.Name);
            Assert.IsNotNull(menuId);
            Assert.IsTrue(menuId.ToString() != Utility.DefaultGuid.ToString());
        }
    }
}
