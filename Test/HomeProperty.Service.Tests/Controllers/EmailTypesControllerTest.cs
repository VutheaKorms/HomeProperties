using HomeProperty.Fixtures;
using HomeProperty.Service.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace HomeProperty.Service.Tests.Controllers {
    public class EmailTypesControllerTest : ServiceBaseController {

        private EmailTypesController _controller;

        public EmailTypesController Controller { get { return _controller ?? new EmailTypesController(); } }

        public EmailTypesControllerTest() {
            _controller = new EmailTypesController();
        }

        [TestMethod]
        public async Task TestGetEmailTypes() {
            var result = await Controller.Get();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task TestGetEmailType() {
            Controller.Request = new System.Net.Http.HttpRequestMessage();
            Controller.Configuration = new System.Web.Http.HttpConfiguration();
            var result = await Controller.Get(TestData.EmailType.Id);
            Assert.AreEqual(TestData.EmailType.Id, result.Id);
        }
    }
}
