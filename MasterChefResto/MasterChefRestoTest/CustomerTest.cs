using System;
using MasterChefResto.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterChefRestoTest
{
    [TestClass]
    public class CustomerTest
    {
        Customer customer = new Customer(2, 5, 6, 8);

        [TestMethod]
        public void CheckIfServed()
        {
            Assert.Fail();
        }
        
        [TestMethod]
        public void chooseInMenu()
        {
            int test = customer.chooseInMenu(1, 30);
            Assert.IsNotNull(test);
        }
    }
}
