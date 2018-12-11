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

        public RoomClerk()
        {

        }

        public void CheckStateTable()
        {
            Boolean served = false;
            foreach(Table table in Room.tableList)
            {
                if(!table.Bread || !table.Water)
                {
                    //se déplace à la position de la table table.tableId
                    Distribute(table);
                    served = true;
                }
                if(served)
                {
                    //retourne à sa position d'observation
                    served = false;
                }
            }
        }

        public static void Distribute(Table table)
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
