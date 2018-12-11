using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class Square
    {
        public int SquareNum { get; set; }
        public List<int> IdTablesList;
        public RankChief RankChiefOfTheSquare;

        public Square(int NumForSquare, RankChief rankchief)
        {
            IdTablesList = new List<int>();
            this.SquareNum = NumForSquare;
            this.RankChiefOfTheSquare = rankchief;
        }
    }
}
