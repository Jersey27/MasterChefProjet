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
        public void getInstanceTest()
        {
            roomClerk = RoomClerk.getInstance();
            Assert.IsNotNull(roomClerk);
        }
    }
}
