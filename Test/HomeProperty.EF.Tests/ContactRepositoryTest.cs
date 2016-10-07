using HomeProperty.EF.Repository;
using HomeProperty.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace HomeProperty.EF.Tests {

    [TestClass]
    public class ContactRepositoryTest {

        #region Setting Up
        private IContactRepository instance;

        public object TestData { get; private set; }

        [TestInitialize]
        public void SettingUp() {
            instance = new ContactRepository();
        }
        #endregion Setting Up

        [TestMethod]
        public async Task TestGetEmailTypesAsync() {
            var results = await instance.GetEmailTypesAsync();
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
        }

        [TestMethod]
        public async Task TestGetEmailTypeAsync() {
            var result = await instance.GetEmailTypeAsync(HomeProperty.Fixtures.TestData.EmailType.Id, HomeProperty.Settings.Constant.Constant.EnglishUsCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id.ToString() == HomeProperty.Fixtures.TestData.EmailType.Id.ToString());
        }


        [TestMethod]
        public async Task TestAddEmailTypeAsync() {
            var emailTypeView = new EmailTypeView {
                Name = "Test Public Email",
                LanguageId = HomeProperty.Fixtures.TestData.Language.Id,
                Description = "General Public Email Address"
            };
            var emailTypeId = await instance.AddEmailTypeAsync(emailTypeView);
            Assert.IsTrue(emailTypeId != null);
            Assert.IsTrue(emailTypeId.ToString() != HomeProperty.Fixtures.TestData.DefaultGuid.ToString());
        }

    }
}
