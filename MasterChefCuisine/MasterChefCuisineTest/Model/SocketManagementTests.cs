using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterChefCuisine.Model;

namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class SocketManagementTests
    {
        SocketManagement socket = SocketManagement.getInstance(true);
        [TestMethod]
        public void getInstanceTest()
        {
            Assert.IsNotNull(socket);
        }
    }
}
