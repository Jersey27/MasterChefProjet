﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        PartChief partChief = new PartChief(true);
        [TestMethod]
        public void AssignPlateTest()
        {
            chief.AddObserverCook(partChief);
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(new Ingredient { NomIngredient = "tomate", quantityIngredient = 4, typeIngredient = "Frais" });
            Recipe tomateMoza = new Recipe { IdRecipe = 0, Ingredients = ingredients, NameRecipe = "Tomate Coupé", nombre_parts = 4, tpsCook = 0, tpsPrep = 5, tpsRest = 0, typeRecipe = "entree", available = true };
            Command commandTest = new Command { Commandid = 1, recipe = null, RecipeId = 0, state = Command.commandState.notReady };
            chief.menu.Add(tomateMoza);
            chief.assignPlate(commandTest);
        }

        [TestMethod]
        public void getInstanceTest()
        {
            Assert.IsNotNull(chief);
        }

    }
}
