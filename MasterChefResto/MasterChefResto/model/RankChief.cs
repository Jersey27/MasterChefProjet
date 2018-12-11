using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class RankChief : Staff
    {
        public static List<Table> tableOfThisRankChief;
        public bool Busy { get; set; }
        public static List<String> menu;

        public RankChief()
        {
            menu = new List<String>();
            tableOfThisRankChief = new List<Table>();
        }

    }
}
