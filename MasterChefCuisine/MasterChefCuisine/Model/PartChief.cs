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
        public static List<Command> listCommand { get; set; }

        Chief chief;
        static List<Clerk> clerks;

        Thread thread;
        Semaphore semaphorePreparation = new Semaphore(1, 1);
        Semaphore semaphoreNewCommand = new Semaphore(1, 1);

        public bool isBusy { get; set; }

        public PartChief(bool isTest)
        {
            if (listCommand == null)
                listCommand = new List<Command>();
            ThreadPool.SetMaxThreads(1, 5);
            chief = Chief.getInstance(isTest);
            chief.AddObserverCook(this);
            thread = new Thread(cooking);
        }

        public void update(Command command)
        {
            semaphoreNewCommand.WaitOne();
            if(!listCommand.Exists(x => x.Commandid == command.Commandid) && !listCommand.Exists(x => x.recipe == command.recipe))
            {
                listCommand.Add(command);
                semaphoreNewCommand.Release();
            }
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
                semaphorePreparation.WaitOne();
                Command command = listCommand.First(x => x.state == Command.commandState.notReady);
                listCommand.Remove(listCommand.First(x => x == command));
                semaphorePreparation.Release();
                isBusy = true;
                if (command != null)
                {
                    Task<Command> task1 = Task.Run(() => prepareLoop(command));
                    task1.Wait();
                    isBusy = false;
                    if (command.recipe.tpsCook > 0)
                    {
                        command.state = Command.commandState.isCooking;
                        Task<Command> task3 = Task.Run(() => BakingLoop(command));

                        if (command.recipe.tpsRest > 0)
                        {
                            command.state = Command.commandState.isResting;
                            Task<Command> task2 = Task.Run(() => restingLoop(command));
                        }
                    }
                    else if (command.recipe.tpsRest > 0)
                    {
                        command.state = Command.commandState.isResting;
                        Task<Command> task2 = Task.Run(() => restingLoop(command));
                    }
                    listCommand.Add(command);
                    foreach (Clerk clerk in clerks)
                    {
                        clerk.sendPlate();
                    }
                }
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
            Thread.Sleep(command.recipe.tpsCook * 1000);
            return command;
        }
    }
}
#endregion