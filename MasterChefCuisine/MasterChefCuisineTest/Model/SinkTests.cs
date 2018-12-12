using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterChefCuisine.Model;

namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class SinkTests
    {
        DishWasher dishwasher;
        [TestMethod]
        public void WashTest()
        {
            dishwasher.Wash();
            Assert.Fail();
        }
    }
}
