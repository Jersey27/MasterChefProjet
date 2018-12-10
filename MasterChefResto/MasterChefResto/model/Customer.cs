using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    class Customer
    {
        private bool Served { get; set; }
        private int TimeEatStarter { get; set; }
        private int TimeEatMainCourse { get; set; }
        private int TimeEatDessert { get; set; }

        public Customer(int start, int main, int dessert)
        {
            this.TimeEatStarter = start;
            this.TimeEatMainCourse = main;
            this.TimeEatDessert = dessert;
        }
    }
}
