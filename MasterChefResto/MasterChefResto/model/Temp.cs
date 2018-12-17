using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class Temp
    {
        public static List<String> plateCommanded;
        public static List<String> dirtyObjects;

        public Temp()
        {
            plateCommanded = new List<String>();
            dirtyObjects = new List<String>();
        }
    }
}
