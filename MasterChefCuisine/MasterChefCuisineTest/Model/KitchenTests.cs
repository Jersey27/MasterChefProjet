using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterChefCuisine.Model;

namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class KitchenTests
    {
        Kitchen instance;

        [TestMethod]
        public void getInstanceTest()
        {
            instance = Kitchen.getInstance();
            Assert.IsNotNull(instance);
        }
    }
}
