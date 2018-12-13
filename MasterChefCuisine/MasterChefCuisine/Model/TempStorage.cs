using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class TempStorage
    {
        public List<Command> comStore { get; set; }
        public List<Ingredient> ingStore { get; set; }
        public List<Recipe> repStore { get; set; }

        private static TempStorage instance = new TempStorage();

        private TempStorage()
        {
            comStore = new List<Command>();
            ingStore = new List<Ingredient>();
            repStore = new List<Recipe>();
        }

        public static TempStorage getInstance()
        {
            return instance;
        }

    }
}
