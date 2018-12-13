using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterChefCuisine.Model;

namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class IngredientTests
    {
        [TestMethod]
        public void IngredientTest()
        {
            Ingredient ingredientTest = new Ingredient { NomIngredient = "Tomate", typeIngredient = "Legume", quantityIngredient = 18 };
            Assert.AreEqual(ingredientTest.NomIngredient, "Tomate");
            Assert.AreEqual(ingredientTest.quantityIngredient, 18);
            Assert.AreEqual(ingredientTest.typeIngredient, "Legume");
        }
    }
}
