using HomeProperty.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeProperty.Tests {
    [TestClass]
    public class ErrorLogRepositoryTest {
        #region Setting Up
        private IRepositoryBase instance;

        [TestInitialize]
        public void SettingUp() {
            instance = new RepositoryBase();
        }
        #endregion Setting Up


    }
}
