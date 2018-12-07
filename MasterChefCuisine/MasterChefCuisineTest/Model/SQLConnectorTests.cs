using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterChefCuisine.Model;

namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class SQLConnectorTests
    {
        SQLConnector instance;
        [TestMethod]
        public void ConnectTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void getInstance()
        {
            instance = SQLConnector.getInstance(true);
            Assert.IsNotNull(instance);
        }
    }
}
