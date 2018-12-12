using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class Clerk : Preparator
    {
        SocketManagement socket;
        private SQLQuery query = SQLQuery.getInstance();
        static Semaphore semaphore = new Semaphore(1,1);
        public Clerk(bool isTest)
        {
            socket = SocketManagement.getInstance(isTest);
        }

        public bool sendPlate()
        {
            semaphore.WaitOne();
            Command command = PartChief.listCommand.First(x => x.state == Command.commandState.Ready);
            PartChief.listCommand.Remove(PartChief.listCommand.First());
            semaphore.Release();
            socket.sendPlate(command);
            return true;
        }

        public void bringIngredients(List<Ingredient> ingredients)
        {
            foreach(Ingredient ing in ingredients)
            {
                query.TakeIngredient(ing);
            }
        }
    }
}
