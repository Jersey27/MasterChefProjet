using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class Cook : Preparator
    {
        private List<Command> commands;
        bool isBusy = false;
        public Cook()
        {

        }
        public void cooking(Command command)
        {
            if
            if (!isBusy)
            {
                isBusy = true;
                Thread.Sleep(command.recipe.tpsPrep * 1000);
                if()
            }
            
        }
    }
}
