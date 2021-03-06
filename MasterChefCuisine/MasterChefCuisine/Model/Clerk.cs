﻿using System;
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
        TempStorage tempStorage = TempStorage.getInstance();
        static Semaphore semaphore = new Semaphore(1,1);
        public Clerk(bool isTest)
        {
            if (!isTest)
            {
                socket = SocketManagement.getInstance(isTest);
            }

        }

        public void sendPlate()
        {
            while (PartChief.listCommand.Any(x => x.state == Command.commandState.Ready))
            {
                semaphore.WaitOne();
                Command command = PartChief.listCommand.First(x => x.state == Command.commandState.Ready);
                if (command != null)
                {
                    if (command.recipe.nombre_parts > 1)
                    {
                        command.recipe.prendrePart();
                        tempStorage.repStore.Add(command.recipe);
                    }
                    PartChief.listCommand.Remove(PartChief.listCommand.First());
                    semaphore.Release();
                    socket.sendPlate(command);
                }
            }
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
