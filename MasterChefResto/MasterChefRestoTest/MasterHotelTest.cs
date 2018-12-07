using System;
using MasterChefResto.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterChefRestoTest
{
    [TestClass]
    public class MasterHotelTest
    {
        MasterHotel masterHotel;
        [TestMethod]
        public void getInstanceTest()
        {
            masterHotel = MasterHotel.getInstance();
            Assert.IsNotNull(masterHotel);
        }
    }
}
