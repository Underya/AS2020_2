using Microsoft.VisualStudio.TestTools.UnitTesting;
using taxiModel;

namespace taxiModel_test
{
    [TestClass]
    public class taxiContext_test
    {
        /// <summary>
        /// Строка соеденения с БД
        /// </summary>
        string ConnectionString = "";

        [TestInitialize]
        public void init()
        {
            ConnectionString = Settings1.Default.ConnectionString;
        }

        [TestMethod]
        public void testCteate()
        {
            taxiContext tc = new taxiContext();
        }

        [TestMethod]
        public void SetConnectionString()
        {
            taxiContext.SetConnectionString(ConnectionString);
        }

        [TestMethod]
        public void CheckConnectionString()
        {
            taxiContext.SetConnectionString(ConnectionString);
            Assert.AreEqual(ConnectionString, taxiContext.GetConnectionString());
        }

        [TestMethod]
        public void UsingContext()
        {
            taxiContext.SetConnectionString(ConnectionString);
            using(taxiContext tc = new taxiContext())
            {
            }
        }

    }
}
