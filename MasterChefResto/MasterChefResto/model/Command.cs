using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class Command
    {
        public List<Customer> customer;
        public List<String> Starter;
        public List<String> MainCourse;
        public List<String> Dessert;

        public Command()
        {
            customer = new List<Customer>();
            Starter = new List<String>();
            MainCourse = new List<String>();
            Dessert = new List<String>();
        }
    }
}
