using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class Kitchen
    {
        public Chief chief;
        public List<PartChief> cooks;
        public List<Clerk> clerks;
        public List<Plunger> plungers;
        public List<WashingMachine> washingMachines;

        private static Kitchen instance = new Kitchen();

        public Kitchen()
        {

        }

        public static Kitchen getInstance()
        {
            return instance;
        }
    }
}
