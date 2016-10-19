using HomeProperty.Fixtures;
using HomeProperty.Service.Controllers;
using HomeProperty.View.App;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HomeProperty.Service.Tests.Controllers
{
    public class PackageControllerTest : ServiceBaseController
    {
        private PackagesController _controller;

        public PackagesController Controller { get { return _controller ?? new PackagesController(); } }

        public PackageControllerTest()
        {
            _controller = new PackagesController();
        }

        [TestMethod]
        public async Task TestGetPackages()
        {
            var result = await Controller.Get();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task TestCreatePackage()
        {
            SetUpController(Controller,
            TestData.ServiceEndPont, "api/packages", "packages", HttpMethod.Post);
            var response = await Controller.Post(new PackageView
            {
                Name = "Standard",
                Price = "39.99",
                ModifiedBy = new Guid(TestData.User.Id),
                Description = "Save Operation from Service",
               
            });
            Assert.IsNotNull(response);
        }
    }
}
