using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class Room
    {
        static Room instance = new Room();
        List<Table> tableList = new List<Table>();
        public static List<CustomerGroup> customerGroupList = new List<CustomerGroup>();
        int nbrTableTwo = 10;
        int nbrTableFour = 10;
        int nbrTableSix = 5;
        int nbrTableEight = 5;
        int nbrTableTen = 2;
        public int increment;

        private Room()
        {
            increment = 0;
            while(increment < nbrTableTwo)
            {
                tableList.Add(new Table(increment, 2));
                increment = increment++;
            }
            while(increment < nbrTableFour + 10)
            {
                tableList.Add(new Table(increment, 4));
                increment = increment++;
            }
            while(increment < nbrTableSix + 15)
            {
                tableList.Add(new Table(increment, 6));
                increment = increment++;
            }
            while (increment < nbrTableEight + 20)
            {
                tableList.Add(new Table(increment, 8));
                increment = increment++;
            }
            while (increment < nbrTableTen + 22)
            {
                tableList.Add(new Table(increment, 10));
                increment = increment++;
            }
            increment = 0;
        }

        public static void CreateCustomerGroup()
        {
            int nbrOfGroupCreated = customerGroupList.Count;
            customerGroupList.Add(new CustomerGroup(nbrOfGroupCreated + 1));
        }

        public static Room getInstance()
        {
            return instance;
        }
    }
}
