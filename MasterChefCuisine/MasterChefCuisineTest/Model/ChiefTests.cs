using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterChefCuisine.Model;


namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class ChiefTests
    {
        Chief chief = Chief.getInstance(true);
        SocketManagement socket = SocketManagement.getInstance(true);
        Cook cook = new Cook();
        [TestMethod]
        public void AssignPlateTest()
        {
            
        }

        [TestMethod]
        public void getInstanceTest()
        {
            Assert.IsNotNull(chief);
        }

    }
}
