﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class Room
    {
        static Room instance = new Room();

        private Room()
        {

        }

        public static Room getInstance()
        {
            return instance;
        }
    }
}
