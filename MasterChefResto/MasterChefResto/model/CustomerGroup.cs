using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class CustomerGroup
    {
        public int GroupNumber { get; set; }
        public int NbrCustomerInGroup { get; set; }
        public int TableAssigned { get; set; }
        public Boolean Seated { get; set; } 
        public Boolean Commanded { get; set; }
        public Boolean Finished { get; set; }
        public List<Customer> customerList;

        public CustomerGroup()
        {
            this.TableAssigned = -1;
            this.Commanded = false;
            this.Seated = false;
            this.Finished = false;
            customerList = new List<Customer>();
            Random random = new Random();
            this.NbrCustomerInGroup = random.Next(1, 10);
            int increment = 0;
            while (increment < this.NbrCustomerInGroup)
            {
                int NumberOfExistingCustomer = Room.CountNumberOfCustomer();
                int randomTimeToEatStarter = random.Next(10, 20);
                int randomTimeToEatMainCourse = random.Next(15, 35);
                int randomTimeToEatDessert = random.Next(5, 15);
                customerList.Add(new Customer(NumberOfExistingCustomer, randomTimeToEatStarter, randomTimeToEatMainCourse, randomTimeToEatDessert));
            }
        }
    }
}

