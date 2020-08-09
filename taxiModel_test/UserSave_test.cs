using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using taxiModel;
using System.Threading;

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
        string name = "Name";
        string family = "family";
        string midname = "midname";
        DateTime dateTime = new DateTime(194, 3, 14);
        string number = "0 123-456-7890";
        char sex = 'm';

        /// <summary>
        /// Созадние пользователя без пароля, но со всеми другими стандартными параметрами
        /// </summary>
        /// <returns></returns>
        UserSave CreateUser()
        {
            UserSave user = new UserSave();
            user.Id = -1;
            user.Email = email;
            user.Datebirth = dateTime;
            user.Number = number;
            user.Firstname = name;
            user.Lastname = family;
            user.Midname = midname;
            user.Sex = sex;
            return user;
        }

        void DeleteUser(int id)
        {
            using(taxiContext tm = new taxiContext())
            {
                Users user = tm.Users.Where(t => t.Id == id).FirstOrDefault();
                tm.Users.Remove(user);
                tm.SaveChanges();
            }
        }

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
        public void CheckUniqPassword()
        {
            UserSave user = new UserSave();
            user.SetHashPassword(OpenPass);
            Assert.AreNotEqual(OpenPass, user.Hash);
        }

        [TestMethod]
        public void CheckSalt()
        {
            UserSave user = new UserSave();
            user.SetHashPassword(OpenPass);
            Assert.IsNotNull(user.Salt);
        }

        [TestMethod]
        public void s01_e01_setPass()
        {
            using (taxiContext tc = new taxiContext())
            {
                UserSave user = CreateUser();
                user.SetHashPassword(OpenPass);
                tc.Users.Add(user);
                tc.SaveChanges();
            }
        }

        [TestMethod]
        public void s01_e02_checkCreate()
        {
            using (taxiContext tc = new taxiContext())
            {
                var user = tc.Users.Where(t => t.Id == id);
                Assert.AreEqual(1, user.Count());
            }
        }

        [TestMethod]
        public void s01_e03_checkPass()
        {
            Assert.IsTrue(UserSave.CheckUser(email, OpenPass));
        }

        [TestMethod]
        public void s01_e04_get_user()
        {
            UserSave user = UserSave.GetUser(email);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void s01_e05_checkName()
        {
            UserSave user = UserSave.GetUser(email);
            Assert.AreEqual(this.name, user.Firstname);
        }

        [TestMethod]
        public void s01_e06_checkDate()
        {
            UserSave user = UserSave.GetUser(email);
            Assert.AreEqual(this.dateTime, user.Datebirth);
        }

        [TestMethod]
        public void s01_e99_deleteUser()
        {
            UserSave user = UserSave.GetUser(email);
            DeleteUser(user.Id);
        }

        [TestMethod]
        public void add2equalId()
        {
            bool exec = false;
            using (taxiContext tc = new taxiContext())
            {
                Users user1 = new Users(), user2 = new Users();
                user1.Id = id;
                user2.Id = id;
                user1.Email = email;
                user2.Email = "new" + email;
                try
                {
                    tc.Users.Add(user1);
                    tc.Users.Add(user2);
                    tc.SaveChanges();
                }
                catch
                {
                    exec = true;
                }

                if (!exec)
                {
                    DeleteUser(user1.Id);
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void add2equalEmail()
        {
            bool exec = false;
            using (taxiContext tc = new taxiContext())
            {
                Users user1 = new Users(), user2 = new Users();
                user1.Id = id;
                user2.Id = id + id;
                user1.Email = email;
                user2.Email = email;
                try
                {
                    tc.Users.Add(user1);
                    tc.Users.Add(user2);
                    tc.SaveChanges();
                }
                catch
                {
                    exec = true;
                }

                if (!exec)
                {
                    DeleteUser(user1.Id);
                    Assert.Fail();
                }
            }
        }
    }
}
