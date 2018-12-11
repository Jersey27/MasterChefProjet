using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class Customer
    {
        private int IdCustomer { get; set; }
        private bool Served { get; set; }
        private int TimeEatStarter { get; set; }
        private int TimeEatMainCourse { get; set; }
        private int TimeEatDessert { get; set; }

        public Customer(int Id, int start, int main, int dessert)
        {
            this.IdCustomer = Id;
            this.TimeEatStarter = start;
            this.TimeEatMainCourse = main;
            this.TimeEatDessert = dessert;
        }
    }
}
