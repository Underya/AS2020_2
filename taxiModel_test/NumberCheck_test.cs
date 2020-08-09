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
            Assert.IsTrue(c.Check("1"));
        }

        [TestMethod]
        public void t2()
        {
            NumberCheck c = new NumberCheck();
            Assert.IsTrue(c.Check("12"));
        }

        [TestMethod]
        public void t3()
        {
            NumberCheck c = new NumberCheck();
            Assert.IsTrue(c.Check("1234"));
        }
    }
}
