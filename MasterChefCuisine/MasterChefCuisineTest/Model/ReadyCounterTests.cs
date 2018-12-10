using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterChefCuisine.Model;
using System.Collections.Generic;

namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class ReadyCounterTests
    {
        [TestMethod]
        public void SendPlateTest(Recipe recipe)
        {
            List<Ingredient> ingredients = new List<Ingredient>;
            ingredients.Add(new Ingredient { NomIngredient = "tomate", quantityIngredient = 4, typeIngredient = "Frais" });
            Recipe tomateMoza = new Recipe { IdRecipe = 0, Ingredients = ingredients, NomRecipe = "Tomate Coupé", nombre_parts = 4, tpsCook = 0, tpsPrep = 5, tpsRest = 0, typeRecipe = "entree", available = true };
            Command commandTest = new Command { Commandid = 1, recipe = null, RecipeId = 1, state = Command.commandState.notReady };

        }
    }
}
