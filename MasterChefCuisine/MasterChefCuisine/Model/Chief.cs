using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class Chief
    {
        static Chief instance = new Chief();
        private Chief()
        {

        }
        public void assignPlate()
        {

        }

        public void notifyNewCommand()
        {

        }
        public static Chief getInstance()
        {
            return instance;
        }
    }
}
