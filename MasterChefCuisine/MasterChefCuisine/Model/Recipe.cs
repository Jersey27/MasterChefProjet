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

    }
}
