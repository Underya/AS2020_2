using Microsoft.VisualStudio.TestTools.UnitTesting;
using taxiModel;
using System.Configuration;

namespace taxiModel_test
{
    [TestClass]
    public class taxiContext_test
    {
        [TestMethod]
        public void testCteate()
        {
            taxiContext tc = new taxiContext();
        }

        [TestMethod]
        public void SetConnectionString()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["defaultString"].ConnectionString;
            taxiContext.SetConnectionString(ConnectionString);
        }

        [TestMethod]
        public void CheckConnectionString()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["defaultString"].ConnectionString;
            taxiContext.SetConnectionString(ConnectionString);
            Assert.AreEqual(ConnectionString, taxiContext.GetConnectionString());
        }


    }
}
