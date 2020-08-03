using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Security.Cryptography;
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

        string OpenPass = "Password1";

        string email = "nikNikitaMatveev@mail.ru";

        int id = -1;


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

        [TestMethod]
        public void SetNewId()
        {
            UserSave userSave = new UserSave();
            userSave.SetNewId();
            //Проверка новости ID
            taxiContext tc = new taxiContext();
            Assert.AreEqual(0, tc.Users.Where(t => t.Id == userSave.Id).Count());
        }

        [TestMethod]
        public void CheckUniqPassord()
        {
            
        }

    }
}
