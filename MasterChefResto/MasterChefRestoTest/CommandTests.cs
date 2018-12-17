using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterChefResto.model;

namespace MasterChefRestoTest
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void constructeur()
        {
            Command test = new Command();

            Assert.IsNotNull(test.customer);
            Assert.IsNotNull(test.Starter);
            Assert.IsNotNull(test.MainCourse);
            Assert.IsNotNull(test.Dessert);

        }
    }
}
