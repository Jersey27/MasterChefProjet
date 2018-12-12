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
        public static List<String> menuStarter;
        public static List<String> menuMainCourse;
        public static List<String> menuDessert;

        public RankChief()
        {
            menuStarter = new List<String>();
            //Requete sql pour remplir menuStarter
            menuMainCourse = new List<String>();
            //Requete sql pour remplir menuMainCourse
            menuDessert = new List<String>();
            //Requete sql pour remplir menuDessert
            tableOfThisRankChief = new List<Table>();
        }

    }
}
