﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class RankChief : Staff
    {
        public bool Busy { get; set; }
        public List<String> menu = new List<String>();

    }
}
