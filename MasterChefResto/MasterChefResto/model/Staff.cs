using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public abstract class Staff
    {
        public Position position { get; set; }

        public static String CheckIfServiceEnded()
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
    }
}
