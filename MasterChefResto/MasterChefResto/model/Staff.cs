using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class Staff
    {
        public Position position { get; set; }

        public String CheckIfServiceEnded()
        {
            if(TimeInRoom.Hour >= 24)
            {
                return "Fin Service";
            }
            else if(TimeInRoom.Hour >= 22)
            {
                return "Fin ouverture au public";
            }
            return "En service";
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
