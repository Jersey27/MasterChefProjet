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
        Chief chief;
        [TestMethod]
        public void AssignPlateTest()
        {
            chief = Chief.getInstance();
            chief.assignPlate();
            Assert.Fail();
            
        }

        [TestMethod]
        public void getInstanceTest()
        {
            chief = Chief.getInstance();
            Assert.IsNotNull(chief);
        }

    }
}
