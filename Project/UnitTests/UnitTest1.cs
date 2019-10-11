using System;
using DatabaseMS;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            var exists = false;
            //act
            var user = new User { Username = "Bill" };

            using (var model = new DatabaseContext())
            {
                exists = model.Database.Exists();
            }
            //asset
            Assert.IsTrue(exists);
        }
    }
}
