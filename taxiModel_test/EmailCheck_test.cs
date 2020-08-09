using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using taxiModel.check;

namespace taxiModel_test
{
    [TestClass]
    public class EmailCheck_test
    {
        [TestMethod]
        public void Create()
        {
            EmailCheck c = new EmailCheck();
        }

        [TestMethod]
        public void t1()
        {
            EmailCheck c = new EmailCheck();
            Assert.IsTrue(c.Check("dawdd@dawd.ru"));
        }

        [TestMethod]
        public void t2()
        {
            EmailCheck c = new EmailCheck();
            Assert.IsTrue(c.Check("dawdd123@dawd123.ru"));
        }

        [TestMethod]
        public void t3()
        {
            EmailCheck c = new EmailCheck();
            Assert.IsFalse(c.Check("abc123@.ru"));
        }

        [TestMethod]
        public void t4()
        {
            EmailCheck c = new EmailCheck();
            Assert.IsFalse(c.Check("@com.ru"));
        }

        [TestMethod]
        public void t5()
        {
            EmailCheck c = new EmailCheck();
            Assert.IsFalse(c.Check("abv123@com."));
        }

        [TestMethod]
        public void t6()
        {
            EmailCheck c = new EmailCheck();
            Assert.IsTrue(c.Check("abc1234@dawd.ru"));
        }

        [TestMethod]
        public void t7()
        {
            EmailCheck c = new EmailCheck();
            Assert.IsTrue(c.Check("abcdefghjz1290@dawd.ru"));
        }

        [TestMethod]
        public void t8()
        {
            EmailCheck c = new EmailCheck();
            Assert.IsTrue(c.Check("abcdefghj0@abcd1214.ru"));
        }

        [TestMethod]
        public void t9()
        {
            EmailCheck c = new EmailCheck();
            Assert.IsTrue(c.Check("abc123@abc123.ru"));
        }

        [TestMethod]
        public void t10()
        {
            EmailCheck c = new EmailCheck();
            Assert.IsTrue(c.Check("nik.nikita.matveev.1997@gmail.com"));
        }
    }
}
