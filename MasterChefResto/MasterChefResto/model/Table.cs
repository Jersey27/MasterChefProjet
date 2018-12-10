using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    class Table
    {
        private int tableId;
        private bool Bread { get; set; }
        private bool Water { get; set; }
        private int NumberOfPlace { get; set; }
        private String State_Diner { get; set; }

        public Table(int ID, int numberSeat)
        {
            this.tableId = ID;
            this.NumberOfPlace = numberSeat;
        }
    }
}
