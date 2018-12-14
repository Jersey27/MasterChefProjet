using System;
using MasterChefResto.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MasterChefRestoTest
{
    [TestClass]
    public class RoomTest
    {
        Room room;

        [TestMethod]
        public void CreateCustomerGroup()
        {
            List<CustomerGroup> custom = new List<CustomerGroup>();
            int nbrCustomGroupInCustom = custom.Count;
            custom.Add(new CustomerGroup());
            custom[nbrCustomGroupInCustom].GroupNumber = nbrCustomGroupInCustom;
            Assert.IsNotNull(custom[nbrCustomGroupInCustom]);
            Assert.AreEqual(0, custom[nbrCustomGroupInCustom].GroupNumber);
        }

        [TestMethod]
        public void CountNumberOfCustomer()
        {
            List<CustomerGroup> customerGroupList = new List<CustomerGroup>();
            customerGroupList.Add(new CustomerGroup());
            Assert.IsNotNull(customerGroupList[0].NbrCustomerInGroup);
            customerGroupList.Add(new CustomerGroup());
            Assert.IsNotNull(customerGroupList[1].NbrCustomerInGroup);
            customerGroupList.Add(new CustomerGroup());
            Assert.IsNotNull(customerGroupList[2].NbrCustomerInGroup);
        }


        [TestMethod]
        public void getInstanceTest()
        {
            room = Room.getInstance();
            Assert.IsNotNull(room);
        }
    }
}
