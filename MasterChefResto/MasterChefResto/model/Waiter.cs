using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class Waiter : Staff
    {
        public bool Busy { get; set; }

        public void CheckTableState()
        {
            Boolean cleaned = false;
            foreach (Table table in Room.tableList)
            {
                if (table.State_Diner == "Dirty")
                {
                    //se déplace à la position de la table table.tableId
                    SetTable(table);
                    cleaned = true;
                }
                if(cleaned)
                {
                    //retourne à sa position d'observation
                    cleaned = false;
                }
            }
            
        }

        public static void SetTable(Table table)
        {
            table.State_Diner = "Clean";
        }

        public void ServeCustomer()
        {
            //check si une commande est complete

        }

        public void MoveToTheRight()
        {
            this.position.PosX = this.position.PosX + 1;
        }
        public void MoveToTheLeft()
        {
            this.position.PosX = this.position.PosX - 1;
        }
        public void MoveToTheTop()
        {
            this.position.PosY = this.position.PosY + 1;
        }
        public void MoveToTheBottom()
        {
            this.position.PosY = this.position.PosY - 1;
        }
    }
}
