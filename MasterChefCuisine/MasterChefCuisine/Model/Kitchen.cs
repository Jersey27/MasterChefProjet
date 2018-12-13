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

        private static Kitchen instance = new Kitchen();

        public Kitchen()
        {
            //chief = Chief.getInstance(false);
            //cooks.Add(new PartChief(false));
            //cooks.Add(new PartChief(false));
            //clerks.Add(new Clerk(false));
            //clerks.Add(new Clerk(false));
            //plungers.Add(new Plunger());
        }

        public static Kitchen getInstance()
        {
            return instance;
        }
    }
}
