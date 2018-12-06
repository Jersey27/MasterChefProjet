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
        public List<Cook> cooks;
        public List<Plunger> plungers;
        public List<DishWasher> dishWashers;
        public List<WashingMachine> washingMachines;
        public List<KitchenObserver> observers;
        public List<Sink> sinks;

        public Kitchen()
        {

        }
    }
}
