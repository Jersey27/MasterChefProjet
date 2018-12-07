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
        public void ThreadLoopTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void AddMinuteTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void getInstanceTest()
        {
            time = TimeInRoom.getInstance();
            Assert.IsNotNull(time);
        }
    }
}
