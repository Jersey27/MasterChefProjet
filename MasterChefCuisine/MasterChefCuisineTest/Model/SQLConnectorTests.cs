using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterChefCuisine.Model;

namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class SQLConnectorTests
    {
        SQLConnector instance = SQLConnector.getInstance(true);

        [TestMethod]
        public void getInstanceTest()
        {
            Assert.IsNotNull(instance);
        }
    }
}
