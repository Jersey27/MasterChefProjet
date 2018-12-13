using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MasterChefCuisine.Model
{
    public class Command
    {
        public int Commandid { get; set; }
        public int RecipeId { get; set; }
        public Recipe recipe { get; set; }
        public commandState state { get; set; }
        public enum  commandState {notReady, isCooking, isResting, Ready}

        public void resting(int tpsResting)
        {
                Thread thread = new Thread(restingThread);
                thread.Start();
        }

        public void restingThread()
        {
            int i = recipe.tpsRest;
            while(i > 0)
            {
                Thread.Sleep(1000);
                i--;
            }
            this.state = commandState.Ready;
        }

        public void ResearchRecipe()
        {

        }

    }
}
