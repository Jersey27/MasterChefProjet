using System;
using MasterChefResto.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterChefRestoTest
{
    [TestClass]
    public class SocketManagementTest
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
