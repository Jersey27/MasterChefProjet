﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterChefCuisine.Model;

namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class PlungerTests
    {
        Plunger plunger = new Plunger();
        IMachine sink = new Sink();
        IMachine dishwasher = new DishWasher();
        IMachine whashingMachine = new WashingMachine();

        SQLQuery query;

        [TestMethod]
        public void washTest()
        {
            plunger.Wash(dishwasher);
            Assert.Fail();
        }

        [TestMethod]
        public void StoreTest()
        {
            Assert.Fail();
        }
    }
}