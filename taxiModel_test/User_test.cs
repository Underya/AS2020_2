using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Security.Cryptography;
using taxiModel;

namespace taxiModel_test
{
    /// <summary>
    /// Тесты для класса юзер
    /// </summary>
    [TestClass]
    public class User_test
    {
        /// <summary>
        /// Строка соеденения с БД
        /// </summary>
        string ConnectionString = "";

        /// <summary>
        /// Емейл он же пароль
        /// </summary>
        string login = "test@mail.ru";

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        string password = "testPassword";

        [TestInitialize]
        public void Initial()
        {
            ConnectionString = Settings1.Default.ConnectionString;
            taxiContext.SetConnectionString(ConnectionString);
        }

        [TestMethod]
        public void CreateDefaultUser()
        {
            Users user = new Users();
        }

        /// <summary>
        /// Создания нового пользователя
        /// </summary>
        [TestMethod]
        public void s01_e01_testCreate()
        {
            using(taxiContext tc = new taxiContext())
            {
                Users user = new Users();
                user.Id = -1;
                user.Email = this.login;
                user.Hash = this.password;
                user.Salt = this.password;
                tc.Users.Add(user);
                tc.SaveChanges();
            }
        }

        [TestMethod]
        public void s01_e02_SelectUser()
        {
            using (taxiContext tc = new taxiContext())
            {
                Users user = tc.Users.Where(t => t.Id == -1).FirstOrDefault();
            }
        }

        [TestMethod]
        public void s01_e03_CheckUsers()
        {
            using (taxiContext tc = new taxiContext())
            {
                Users user = tc.Users.Where(t => t.Id == -1).FirstOrDefault();
                Assert.AreEqual(login, user.Email);
                Assert.AreEqual(password, user.Hash);
                Assert.AreEqual(password, user.Salt);
            }
        }

        [TestMethod]
        public void s01_e04_DeleteUsers()
        {
            using (taxiContext tc = new taxiContext())
            {
                Users user = tc.Users.Where(t => t.Id == -1).FirstOrDefault();
                tc.Remove(user);
                tc.SaveChanges();
            }
        }

        [TestMethod]
        public void s01_e05_CheckDelete()
        {
            using (taxiContext tc = new taxiContext())
            {
                var users = tc.Users.Where(t => t.Id == -1);
                Assert.AreEqual(0, users.Count());
            }
        }
    }
}
