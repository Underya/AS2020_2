using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using taxiModel.check;


namespace taxiModel_test
{
    [TestClass]
    public class NumberCheck_test
    {
        [TestMethod]
        public void Create()
        {
            NumberCheck c = new NumberCheck();
        }

        [TestMethod]
        public void t1()
        {
            NumberCheck c = new NumberCheck();
            Assert.IsFalse(c.Check("1"));
        }

        [TestMethod]
        public void t2()
        {
            NumberCheck c = new NumberCheck();
            Assert.IsFalse(c.Check("12"));
        }

        [TestMethod]
        public void t3()
        {
            NumberCheck c = new NumberCheck();
            Assert.IsFalse(c.Check("1234"));
        }

        [TestMethod]
        public void t4()
        {
            NumberCheck c = new NumberCheck();
            Assert.IsTrue(c.Check("1 234-567-8910"));
        }

        [TestMethod]
        public void t5()
        {
            NumberCheck c = new NumberCheck();
            Assert.IsTrue(c.Check("9 999-999-0000"));
        }

        [TestMethod]
        public void t6()
        {
            NumberCheck c = new NumberCheck();
            Assert.IsFalse(c.Check("09 999-999-0000"));
        }

        [TestMethod]
        public void t7()
        {
            NumberCheck c = new NumberCheck();
            Assert.IsFalse(c.Check("9 0999-999-0000"));
        }

        [TestMethod]
        public void t8()
        {
            NumberCheck c = new NumberCheck();
            Assert.IsFalse(c.Check("9 999-0999-0000"));
        }

        [TestMethod]
        public void t9()
        {
            NumberCheck c = new NumberCheck();
            Assert.IsFalse(c.Check("9 999-999-10000"));
        }

        [TestMethod]
        public void t10()
        {
            NumberCheck c = new NumberCheck();
            Assert.IsFalse(c.Check("9 99-999-0000"));
        }

        [TestMethod]
        public void t11()
        {
            NumberCheck c = new NumberCheck();
            Assert.IsFalse(c.Check("9 990-99-0000"));
        }

        [TestMethod]
        public void t12()
        {
            NumberCheck c = new NumberCheck();
            Assert.IsFalse(c.Check("9 990-999-000"));
        }

        [TestMethod]
        public void t13()
        {
            NumberCheck c = new NumberCheck();
            Assert.IsFalse(c.Check("9 990-999-0a00"));
        }
    }
}
