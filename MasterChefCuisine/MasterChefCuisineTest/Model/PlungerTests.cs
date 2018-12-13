using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterChefCuisine.Model;

namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class PlungerTests
    {
        Plunger plunger = new Plunger();
        
        SQLQuery query = SQLQuery.getInstance();

        [TestMethod]
        public void washTest()
        {
            plunger.Wash();
        }
    }
}
