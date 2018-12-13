using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterChefCuisine.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class ClerkTest
    {
        Clerk clerk = new Clerk(true);
        [TestMethod]
        public void bringIngredients()
        {
            SQLConnector connector = SQLConnector.getInstance(false);
            connector.connection = new SqlConnection("server=10.176.50.33;" + "user id=projet-resto;" + "password=azerty123;" + "database=masterchef;" + "connection timeout=30");

            Ingredient expected = new Ingredient { NomIngredient = "Les bonnes pâtes sa mère", typeIngredient = "Longue conserv", canBePrepared = true, datePeremption = new DateTime(2019, 12, 17), quantityIngredient = 10 };
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(expected);
            clerk.bringIngredients(ingredients);
        }
    }
}
