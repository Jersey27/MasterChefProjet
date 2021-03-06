﻿using System;
using MasterChefResto.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterChefRestoTest
{
    [TestClass]
    public class TimeInRoomTest
    {
        TimeInRoom time = TimeInRoom.getInstance();

        [TestMethod]
        public void AddMinuteTest()
        {
            TimeInRoom.Minute = 58;
            TimeInRoom.Hour = 2;
            TimeInRoom.AddMinute();
            Assert.AreEqual(59, TimeInRoom.Minute);
            TimeInRoom.AddMinute();
            Assert.AreEqual(3, TimeInRoom.Hour);
            Assert.AreEqual(0, TimeInRoom.Minute);
        }

        [TestMethod]
        public void getInstanceTest()
        {
            time = TimeInRoom.getInstance();
            Assert.IsNotNull(time);
        }
    }
}
