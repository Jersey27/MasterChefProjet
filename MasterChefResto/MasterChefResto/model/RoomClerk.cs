using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class RoomClerk : Staff
    {
        static RoomClerk instance = new RoomClerk();

        private RoomClerk()
        {

        }

        public void CheckStateTable()
        {
            foreach(Table table in Room.tableList)
            {
                if(!table.Bread || !table.Water)
                {
                    //se déplace à la position de la table table.tableId
                    Distribute(table);
                }
            }
        }

        public void Distribute(Table table)
        {
            table.Bread = true;
            table.Water = true;
        }

        public static RoomClerk getInstance()
        {
            return instance;
        }
    }
}
