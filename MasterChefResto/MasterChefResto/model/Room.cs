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
        public static List<Square> squareList;
        public static List<Staff> staffList;
        public static List<Command> commandList;
        public static List<CustomerGroup> customerGroupList = new List<CustomerGroup>();
        int nbrTableTwo = 10;
        int nbrTableFour = 10;
        int nbrTableSix = 5;
        int nbrTableEight = 5;
        int nbrTableTen = 2;
        public int increment;

        private Room()
        {
            squareList = new List<Square>();
            tableList = new List<Table>();
            staffList = new List<Staff>();
            commandList = new List<Command>();
            increment = 0;
            squareList.Add(new Square(1, new RankChief()));
            while (increment < nbrTableTwo)
            {
                tableList.Add(new Table(increment, 2));
                squareList[0].IdTablesList.Add(increment);
                increment = increment + 1;
            }
            squareList.Add(new Square(2, new RankChief()));
            while (increment < nbrTableFour + 10)
            {
                tableList.Add(new Table(increment, 4));
                squareList[1].IdTablesList.Add(increment);
                increment = increment + 1;
            }
            squareList.Add(new Square(3, new RankChief()));
            while (increment < nbrTableSix + 20)
            {
                tableList.Add(new Table(increment, 6));
                squareList[2].IdTablesList.Add(increment);
                increment = increment + 1;
            }
            squareList.Add(new Square(4, new RankChief()));
            while (increment < nbrTableEight + 25)
            {
                tableList.Add(new Table(increment, 8));
                squareList[3].IdTablesList.Add(increment);
                increment = increment + 1;
            }
            squareList.Add(new Square(5, new RankChief()));
            while (increment < nbrTableTen + 30)
            {
                tableList.Add(new Table(increment, 10));
                squareList[4].IdTablesList.Add(increment);
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
            foreach (CustomerGroup customGroup in Room.customerGroupList)
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
