﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class Chief : ObserverChief
    {
        static Chief instance;
        SocketManagement socket;
        public List<Recipe> menu { get; set; }
        public List<PartChief> cooks { get; set; }
        private Chief(bool isTest)
        {
            socket = SocketManagement.getInstance(isTest);
            socket.addChiefObserver(this);
            menu = new List<Recipe>();
            cooks = new List<PartChief>();
            socket.addChiefObserver(this);
        }
        public void assignPlate(Command command)
        {
            command.recipe = menu.Find(x => x.IdRecipe == command.RecipeId);
            UpdateObserverCook(command);
        }
        public void newMenu()
        {
            menu = new List<Recipe>();

        }
        public static Chief getInstance(bool isTest)
        {
            if(instance == null)
            {
                return new Chief(isTest);
            }
            return instance;
        }

        public void Update(Command command)
        {
            assignPlate(command);
        }

        public void AddObserverCook(PartChief observer)
        {
            cooks.Add(observer);
        }
        public void UpdateObserverCook(Command command)
        {
            bool taskSended = false;
            while (!taskSended)
            {
                foreach (PartChief cook in cooks)
                {
                    if (!cook.isBusy)
                    {
                        cook.update(command);
                        taskSended = true;
                    }
                }

            }
        }
    }
}
