using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterChefCuisine.Model;


namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class ChiefTests
    {
        Chief chief = Chief.getInstance(true);
        Cook cook = new Cook();
        [TestMethod]
        public void AssignPlateTest()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(new Ingredient { NomIngredient = "tomate", quantityIngredient = 4, typeIngredient = "Frais" });
            Recipe tomateMoza = new Recipe { IdRecipe = 0, Ingredients = ingredients, NameRecipe = "Tomate Coupé", nombre_parts = 4, tpsCook = 0, tpsPrep = 5, tpsRest = 0, typeRecipe = "entree", available = true };
            Command commandTest = new Command { Commandid = 1, recipe = null, RecipeId = 1, state = Command.commandState.notReady };
            chief.newMenu();
           // chief.assignPlate();
        }

        [TestMethod]
        public void NewMenu()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void getInstanceTest()
        {
            Assert.IsNotNull(chief);
        }

    }
}
