using Microsoft.VisualStudio.TestTools.UnitTesting;
using taxiModel;

namespace taxiModel_test
{
    [TestClass]
    public class taxiContext_test
    {
        public void init()
        {

        }

        [TestMethod]
        public void testCteate()
        {
            taxiContext tc = new taxiContext();
        }


        [TestMethod]
        public void SetConnectionString()
        {
            string ConnectionString = Settings1.Default.ts;
            taxiContext.SetConnectionString(ConnectionString);
        }

        [TestMethod]
        public void CheckConnectionString()
        {
            string ConnectionString = Settings1.Default.ts;
            taxiContext.SetConnectionString(ConnectionString);
            Assert.AreEqual(ConnectionString, taxiContext.GetConnectionString());
        }


    }
}
