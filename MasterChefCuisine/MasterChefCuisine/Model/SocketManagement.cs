using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class SocketManagement
    {
        private static SocketManagement instance = new SocketManagement();

        private SocketManagement()
        {

        }

        public static SocketManagement getInstance()
        {
            return instance;
        }
    }
}
