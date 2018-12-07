using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class Recipe
    {
        public string NomRecipe { get; set; }
        public string typeRecipe { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public int nombre_parts { get; set; }
        public int tpsPrep { get; set; }
        public int tpsCook { get; set; }
        public int tpsRest { get; set; }
        public bool available { get; set; }
        public void prendrePart()
        {
            nombre_parts--;
        }

    }
}
