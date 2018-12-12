using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class PartChief : Employee
    {
        Chief chief;
        static List<Clerk> clerks;
        static List<Command> listCommand = new List<Command>();
        Thread thread;
        Semaphore semaphore = new Semaphore(1, 1);

        public bool isBusy { get; set; }

        public PartChief(bool isTest)
        {
            ThreadPool.SetMaxThreads(1, 5);
            chief = Chief.getInstance(isTest);
            chief.AddObserverCook(this);
            thread = new Thread(cooking);
        }

        public void update(Command command)
        {
            listCommand.Add(command);
            if (!thread.IsAlive)
            {
                thread.Start();
            }
        }

        TempStorage tempStorage = TempStorage.getInstance();
        public void cooking()
        {
            while (listCommand.Any())
            {
                semaphore.WaitOne();
                Command command = listCommand.First();
                listCommand.Remove(listCommand.First());
                semaphore.Release();
                isBusy = true;
                Task<Command> task1 = Task.Run(() => prepareLoop(command));
                task1.Wait();
                isBusy = false;
                if (command.recipe.tpsCook > 0)
                {
                    command.state = Command.commandState.isCooking;
                    Task<Command> task3 = Task.Run(() => BakingLoop(command));
                }
                if (command.recipe.tpsRest > 0)
                {
                    command.state = Command.commandState.isResting;
                    Task<Command> task2 = Task.Run(() => restingLoop(command));
                }
                command.state = Command.commandState.Ready;

            }
        }
        #region cooking method
        public Command prepareLoop(Command command)
        {
            Thread.Sleep(command.recipe.tpsPrep * 1000);
            return command;
        }
        public Command restingLoop(Command command)
        {
            tempStorage.comStore.Add(command);
            Thread.Sleep(command.recipe.tpsRest * 1000);
            Command search = tempStorage.comStore.Find(x => x.Commandid == command.Commandid);
            foreach (Command com in tempStorage.comStore)
            {
                if (com == search)
                {
                    com.state = Command.commandState.Ready;
                }
            }

            return command;
        }
        public Command BakingLoop(Command command)
        {
            return command;
        }
    }
}
#endregion