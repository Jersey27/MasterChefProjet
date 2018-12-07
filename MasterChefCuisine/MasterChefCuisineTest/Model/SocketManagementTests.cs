using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterChefCuisine.Model;

namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class SocketManagementTests
    {
        SocketManagement socket;
        [TestMethod]
        public void getInstanceTest()
        {
            socket = SocketManagement.getInstance();
            Assert.IsNotNull(socket);
        }
    }
}
