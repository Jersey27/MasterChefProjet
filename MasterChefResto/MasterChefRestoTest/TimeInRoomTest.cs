using System;
using MasterChefResto.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterChefRestoTest
{
    [TestClass]
    public class TimeInRoomTest
    {
        TimeInRoom time;
        [TestMethod]
        public void getInstanceTest()
        {
            time = TimeInRoom.getInstance();
            Assert.IsNotNull(time);
        }
    }
}
