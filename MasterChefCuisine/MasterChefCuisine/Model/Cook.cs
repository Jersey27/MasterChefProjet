﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class Cook : Preparator
    {
        bool isBusy = false;
        public Cook()
        {
            ThreadPool.SetMaxThreads(1,5);
        }
        public Command cooking(Command command)
        {
            Task<Command> task1 = Task.Run(() => prepareLoop(command));
            task1.Wait();
            if(command.recipe.tpsCook > 0)
            {
                command.state = Command.commandState.isCooking;
            }
            if(command.recipe.tpsRest > 0)
            {
                command.state = Command.commandState.isResting;
                Task<Command> task2 = Task.Run(() => restingLoop(command));
                task2.Wait();
            }
            command.state = Command.commandState.Ready;
            return command;
        }
        public Command prepareLoop(Command command)
        {
            Thread.Sleep(command.recipe.tpsPrep * 1000);
            return command;
        }
        public Command restingLoop(Command command)
        {
            TempStorage.comStore.Add(command);
            Thread.Sleep(command.recipe.tpsRest * 1000);
            return command;
        }
            
        private Command BakingLoop(object state)
        {
            Command command = state as Command;
            return command;
        }
        
    }
}