using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public bool Served { get; set; }
        public int TimeEatStarter { get; set; }
        public int TimeEatMainCourse { get; set; }
        public int TimeEatDessert { get; set; }

        public Customer(int Id, int start, int main, int dessert)
        {
            this.IdCustomer = Id;
            this.TimeEatStarter = start;
            this.TimeEatMainCourse = main;
            this.TimeEatDessert = dessert;
        }

        public int choseInMenu(int firstEntry, int lastEntry)
        {
            Random random = new Random();
            int choice = random.Next(firstEntry, lastEntry);
            return choice;
        }
    }
}
