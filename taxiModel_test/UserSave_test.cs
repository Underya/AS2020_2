using Microsoft.VisualStudio.TestTools.UnitTesting;
using taxiModel;

namespace taxiModel_test
{
    /// <summary>
    /// Тесты для класса работы объекта с БД
    /// </summary>
    [TestClass]
    public class UserSave_test
    {
        string ConnectionString = "";

        [TestInitialize]
        public void Initial()
        {
            ConnectionString = Settings1.Default.ConnectionString;
            taxiContext.SetConnectionString(ConnectionString);
        }

        [TestMethod]
        public void CreateUserSave()
        {
            UserSave userSave = new UserSave();
        }

        public void SetNewId()
        {
            UserSave userSave = new UserSave();
            userSave.SetNewId();
        }

    }
}
