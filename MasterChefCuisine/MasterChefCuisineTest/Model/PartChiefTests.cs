using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterChefCuisine.Model;
using System.Collections.Generic;
using System.Threading;

namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class PartChiefTests
    {
        PartChief cook = new PartChief(true);
        Command commandTest;

        [TestMethod]
        public void CookingTest()
        {

            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(new Ingredient { NomIngredient = "tomate", quantityIngredient = 4, typeIngredient = "Frais" });
            Recipe tomateMoza = new Recipe { Ingredients = ingredients, NameRecipe = "Tomate Coupé", nombre_parts = 4, tpsCook = 0, tpsPrep = 5, tpsRest = 0, typeRecipe = "entree", available= true };
            commandTest = new Command { Commandid = 1, recipe = tomateMoza, RecipeId = 1, state = Command.commandState.notReady };
            cook.cooking();
        }
    }
}
