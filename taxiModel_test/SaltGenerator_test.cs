using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Security.Cryptography;
using taxiModel;

namespace taxiModel_test
{
    [TestClass]
    public class SaltGenerator_test
    {
        string OpenPassword = "OpenPassword", OpenPassword1 = "OtherOpenPassword";

        int newSize = 512;

        [TestMethod]
        public void Create()
        {
            SaltGenerator saltGenerator = new SaltGenerator();
        }

        [TestMethod]
        public void SetSize()
        {
            SaltGenerator saltGenerator = new SaltGenerator(newSize);
        }

        [TestMethod]
        public void CheckSize()
        {
            SaltGenerator saltGenerator = new SaltGenerator(newSize);
            Assert.AreEqual(newSize, saltGenerator.GetSize);
        }

        [TestMethod]
        public void CheckHassSalt()
        {
            SaltGenerator saltGenerator = new SaltGenerator();
            byte[] hash = null, salt = null;
            saltGenerator.GetOpenPassword(OpenPassword, out hash, out salt);
        }

        [TestMethod]
        public void CheckHasPass()
        {
            SaltGenerator saltGenerator = new SaltGenerator();
            byte[] hash = null, salt = null;
            saltGenerator.GetOpenPassword(OpenPassword, out hash, out salt);
            saltGenerator.GetHash(OpenPassword, salt);
        }

        [TestMethod]
        public void CheckEqualPass()
        {
            SaltGenerator saltGenerator = new SaltGenerator();
            byte[] hash = null, salt = null, hash2 = null;
            saltGenerator.GetOpenPassword(OpenPassword, out hash, out salt);
            hash2 = saltGenerator.GetHash(OpenPassword, salt);
            for(int i = 0; i < saltGenerator.GetSize; i++)
            {
                if (hash[i] != hash2[i]) Assert.Fail();
            }
        }

    }
}
