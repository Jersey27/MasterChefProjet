﻿using System;
using MasterChefResto.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterChefRestoTest
{
    [TestClass]
    public class SQLConnectorTest
    {
        SQLConnector instance = SQLConnector.getInstance(true);

        [TestMethod]
        public void getInstanceTest()
        {
            Assert.IsNotNull(instance);
        }
    }
}