using System;
using MasterChefResto.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterChefRestoTest
{
    [TestClass]
    public class RoomTest
    {
        Room room;
        [TestMethod]
        public void getInstanceTest()
        {
            room = Room.getInstance();
            Assert.IsNotNull(room);
        }
    }
}
