using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class Table
    {
        public int tableId;
        public int couver = 0;
        public bool Bread { get; set; }
        public bool Water { get; set; }
        public int NumberOfPlace { get; set; }
        public String State_Diner { get; set; }

        public Table(int ID, int numberSeat)
        {
            this.tableId = ID;
            this.NumberOfPlace = numberSeat;
        }
    }
}
