﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class Waiter : Staff
    {
        public bool Busy { get; set; }

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
        public void MoveToTheRight()
        {
            this.position.PosX = this.position.PosX + 1;
        }
        public void MoveToTheLeft()
        {
            this.position.PosX = this.position.PosX - 1;
        }
        public void MoveToTheTop()
        {
            this.position.PosY = this.position.PosY + 1;
        }
        public void MoveToTheBottom()
        {
            this.position.PosY = this.position.PosY - 1;
        }
    }
}
