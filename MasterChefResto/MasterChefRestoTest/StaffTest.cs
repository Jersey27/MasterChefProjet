using System;
using MasterChefResto.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterChefRestoTest
{
    [TestClass]
    public class StaffTest
    {
        [TestMethod]
        public void CheckIfServiceEndedTest()
        {
            TimeInRoom.Hour = 26;
            String LaString = Staff.CheckIfServiceEnded();
            Assert.AreEqual("Fin Service", LaString);
            TimeInRoom.Hour = 23;
            LaString = Staff.CheckIfServiceEnded();
            Assert.AreEqual("Fin ouverture au public", LaString);
            TimeInRoom.Hour = 12;
            LaString = Staff.CheckIfServiceEnded();
            Assert.AreEqual("En service", LaString);
        }

        [TestMethod]
        public void MoveToTheRight()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void MoveToTheLeft()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void MoveToTheTop()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void MoveToTheBottom()
        {
            Assert.Fail();
        }
    }
}
