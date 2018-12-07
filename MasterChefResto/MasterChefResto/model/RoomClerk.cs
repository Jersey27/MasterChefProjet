using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class RoomClerk
    {
        static RoomClerk instance = new RoomClerk();

        private RoomClerk()
        {

        }

        public void CheckStateTable()
        {

        }

        public void DistributeWater()
        {

        }

        public void DistributeBread()
        {

        }

        public static RoomClerk getInstance()
        {
            return instance;
        }
    }
}
