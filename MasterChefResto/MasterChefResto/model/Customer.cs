using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class Customer
    {
        public bool HaveToKillHimself;
        public int WhenEatBreadOrWater;
        public int IdCustomer { get; set; }
        public bool Served { get; set; }
        public int TimeEatStarter { get; set; }
        public int TimeEatMainCourse { get; set; }
        public int TimeEatDessert { get; set; }

        public Customer(int Id, int start, int main, int dessert)
        {
            HaveToKillHimself = false;
            Served = false;
            Random random = new Random();
            WhenEatBreadOrWater = random.Next(1, 3);
            IdCustomer = Id;
            TimeEatStarter = start;
            TimeEatMainCourse = main;
            TimeEatDessert = dessert;
            Thread CustomerThread;
            CustomerThread = new Thread(new ThreadStart(CheckIfServed));
        }

        private void CheckIfServed()
        {
            while(!HaveToKillHimself)
            {
                while(!Served)
                {
                    Thread.Sleep(5000);
                    if(WhenEatBreadOrWater == 1)
                    {
                        //trouver la table qui lui a été assigné
                        foreach(CustomerGroup customGroup in Room.customerGroupList)
                        {
                            foreach(Customer custom in customGroup.customerList)
                            {
                                if(custom.IdCustomer == this.IdCustomer)
                                {
                                    foreach(Table tables in Room.tableList)
                                    {
                                        //si la table actuellement checkée est celle surlaquelle est le client
                                        if (customGroup.TableAssigned == tables.tableId)
                                        {
                                            //s'il reste du pain sur la table
                                            if (tables.Bread)
                                            {
                                                //mange le pain
                                                tables.Bread = false;
                                                WhenEatBreadOrWater = 4;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(TimeEatStarter);
                while (!Served)
                {
                    Thread.Sleep(5000);
                    if (WhenEatBreadOrWater == 1)
                    {
                        //trouver la table qui lui a été assigné
                        foreach (CustomerGroup customGroup in Room.customerGroupList)
                        {
                            foreach (Customer custom in customGroup.customerList)
                            {
                                if (custom.IdCustomer == this.IdCustomer)
                                {
                                    foreach (Table tables in Room.tableList)
                                    {
                                        //si la table actuellement checkée est celle surlaquelle est le client
                                        if (customGroup.TableAssigned == tables.tableId)
                                        {
                                            //s'il reste du pain sur la table
                                            if (tables.Bread)
                                            {
                                                //mange le pain
                                                tables.Bread = false;
                                                WhenEatBreadOrWater = 4;
                                            }
                                            if (tables.Water)
                                            {
                                                //Boie l'eau
                                                tables.Water = false;
                                                WhenEatBreadOrWater = 4;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(TimeEatMainCourse);
                while (!Served)
                {
                    Thread.Sleep(5000);
                    if (WhenEatBreadOrWater == 1)
                    {
                        //trouver la table qui lui a été assigné
                        foreach (CustomerGroup customGroup in Room.customerGroupList)
                        {
                            foreach (Customer custom in customGroup.customerList)
                            {
                                if (custom.IdCustomer == this.IdCustomer)
                                {
                                    foreach (Table tables in Room.tableList)
                                    {
                                        //si la table actuellement checkée est celle surlaquelle est le client
                                        if (customGroup.TableAssigned == tables.tableId)
                                        {
                                            //s'il reste du pain sur la table
                                            if (tables.Water)
                                            {
                                                //mange le pain
                                                tables.Water = false;
                                                WhenEatBreadOrWater = 4;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(TimeEatDessert);
                HaveToKillHimself = true;
            }
        }

        public int choseInMenu(int firstEntry, int lastEntry)
        {
            Random random = new Random();
            int choice = random.Next(firstEntry, lastEntry);
            return choice;
        }
    }
}
