using System;
using MasterChefResto.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterChefRestoTest
{
    [TestClass]
    public class RoomClerkTest
    {
        RoomClerk roomClerk;

        [TestMethod]
        public void DistributeTest()
        {
            Table table = new Table(0, 4);
            table.Bread = false;
            table.Water = false;
            RoomClerk.Distribute(table);
            Assert.AreEqual(true, table.Bread);
            Assert.AreEqual(true, table.Water);
        }


        [TestMethod]
        public void getInstanceTest()
        {
            roomClerk = RoomClerk.getInstance();
            Assert.IsNotNull(roomClerk);
        }
    }
}
