using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class Room
    {
        static Room instance = new Room();
        public static List<Table> tableList;
        public static List<Staff> staffList;
        public static List<CustomerGroup> customerGroupList = new List<CustomerGroup>();
        int nbrTableTwo = 10;
        int nbrTableFour = 10;
        int nbrTableSix = 5;
        int nbrTableEight = 5;
        int nbrTableTen = 2;
        public int increment;

        private Room()
        {
            tableList = new List<Table>();
            staffList = new List<Staff>();
            increment = 0;
            while(increment < nbrTableTwo)
            {
                tableList.Add(new Table(increment, 2));
                increment = increment + 1;
            }
            while(increment < nbrTableFour + 10)
            {
                tableList.Add(new Table(increment, 4));
                increment = increment + 1;
            }
            while(increment < nbrTableSix + 20)
            {
                tableList.Add(new Table(increment, 6));
                increment = increment + 1;
            }
            while (increment < nbrTableEight + 25)
            {
                tableList.Add(new Table(increment, 8));
                increment = increment + 1;
            }
            while (increment < nbrTableTen + 30)
            {
                tableList.Add(new Table(increment, 10));
                increment = increment + 1;
            }
            increment = 0;
            staffList.Add(new MasterHotel());
            
        }

        public static void CreateCustomerGroup()
        {
            int nbrOfGroupCreated = customerGroupList.Count;
            customerGroupList.Add(new CustomerGroup());
            customerGroupList[nbrOfGroupCreated].GroupNumber = nbrOfGroupCreated;
        }

        public static int CountNumberOfCustomer()
        {
            int nbrOfClient = 0;
            foreach(CustomerGroup customGroup in Room.customerGroupList)
            {
                nbrOfClient = nbrOfClient + customGroup.NbrCustomerInGroup;
            }
            return nbrOfClient + 1;
        }

        public static Room getInstance()
        {
            return instance;
        }
    }
}
