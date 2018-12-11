using System;
using MasterChefResto.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterChefRestoTest
{
    [TestClass]
    public class WaiterTest
    {
        [TestMethod]
        public void CheckTableStateTest()
        {
            //tester les mouvements
            Assert.Fail();
        }

        [TestMethod]
        public void SetTableTest()
        {
            Table table = new Table(0, 4);
            table.State_Diner = "Dirty";
            Waiter.SetTable(table);
            Assert.AreEqual("Clean", table.State_Diner);
        }

        [TestMethod]
        public void ServeCustomerTest()
        {
            //tester le service
            Assert.Fail();
        }
    }
}
