using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class TempStorage
    {
        public static List<Command> comStore { get; set; }
        public static List<Ingredient> ingStore { get; set; }

        private static TempStorage instance = new TempStorage();

        public static TempStorage getInstance()
        {
            return instance;
        }

    }
}
