using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterChefCuisine.Model;

namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class PreparatorTests
    {
        string resultat = "carotte préparé";
        TempStorage tempStorage = TempStorage.getInstance();
        [TestMethod]
        public void preparerLegumesTest()
        {
            Ingredient ingredient = new Ingredient { NomIngredient = "carotte", quantityIngredient = 1, typeIngredient = "frais", canBePrepared = true };
            Clerk cook = new Clerk();
            cook.prepareLegume(ingredient);
            Ingredient newIngredient = tempStorage.ingStore.Find(x => x.NomIngredient.ToString() == "carotte préparé");
            Assert.AreEqual(resultat, newIngredient.NomIngredient);
        }
    }
}
