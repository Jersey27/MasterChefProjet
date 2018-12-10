using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    class Waiter
    {
        private bool Busy { get; set; }

        public void CheckTableState()
        {

            //check the state of a table, if it is dirty without customer it must be cleaned
            //put an eventlistener, which activate when the state of a table change to "dirty" and has no cutomers
        }

        public void SetTable()
        {

        }

        public void ServeCustomer()
        {

        }
    }
}
