using System;
using System.Collections;
using System.Data.SqlClient;
using MasterChefCuisine.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class SQLQueryTests
    {
     
        [TestMethod]
        public void selectFromDB()
        {
            SqlConnection connection = new SqlConnection("server=10.176.50.33;" + "user id=projet-resto;" + "password=azerty123;" + "database=masterchef;" + "Trusted_Connection=yes;" + "connection timeout=30");
            connection.Open();
            string cmd = string.Format("SELECT * FROM Materiel WHERE nom_materiel = 'Cuitochette';");
            SqlCommand query = new SqlCommand(cmd, connection);
            SqlDataReader reader = query.ExecuteReader();
            ArrayList result = new ArrayList();

            while (reader.Read())
            {
                Object[] row = new Object[reader.FieldCount];
                reader.GetValues(row);
                result.Add(row);
            }

            foreach(object[] i in result)
            {
                Assert.AreEqual(10, (int)i[0]);
            }

            foreach (object[] i in result)
            {
                Assert.AreEqual("Cuitochette", i[1].ToString());
            }

            foreach (object[] i in result)
            {
                Assert.AreEqual("Matériel commun", i[2].ToString());
            }

            foreach (object[] i in result)
            {
                Assert.AreEqual("Sale", i[3].ToString());
            }

            foreach (object[] i in result)
            {
                Assert.AreEqual(150, (byte)i[4]);
            }
        }

        [TestMethod]
        public void getRecipe()
        {
            object[] j = new object[6];
            ArrayList array = new ArrayList();
            Recipe recipe = new Recipe();
            j[0] = 1;
            j[1] = "Pizza";
            j[2] = 10;
            j[3] = 0;
            j[4] = 20;
            j[5] = 8;
            array.Add(j);

            foreach (object[] i in array)
            {
                recipe.IdRecipe = (int)i[0];
            }

            foreach (object[] i in array)
            {
                recipe.NameRecipe = i[1].ToString();
            }

            foreach (object[] i in array)
            {
                recipe.tpsCook = (int)i[2];
            }

            foreach (object[] i in array)
            {
                recipe.tpsRest = (int)i[3];
            }

            foreach (object[] i in array)
            {
                recipe.tpsPrep = (int)i[4];
            }

            foreach (object[] i in array)
            {
                recipe.nombre_parts = (int)i[5];
            }

            Assert.AreEqual(1, recipe.IdRecipe);
            Assert.AreEqual("Pizza", recipe.NameRecipe);
            Assert.AreEqual(10, recipe.tpsCook);
            Assert.AreEqual(0, recipe.tpsRest);
            Assert.AreEqual(20, recipe.tpsPrep);
            Assert.AreEqual(8, recipe.nombre_parts);
        }

        [TestMethod]
        public void getIngredient()
        {
            object[] j = new object[6];
            ArrayList array = new ArrayList();
            Ingredient ingredient = new Ingredient();
            j[0] = 1;
            j[1] = "Tomate";
            j[2] = "Longue conserv";
            j[3] = 25;
            j[4] = "11/12/2018";
            j[5] = 1;
            array.Add(j);

            foreach (object[] i in array)
            {
                ingredient.NomIngredient = i[1].ToString();
            }

            foreach (object[] i in array)
            {
                ingredient.typeIngredient = i[2].ToString();
            }

            foreach (object[] i in array)
            {
                ingredient.quantityIngredient = (int)i[3];
            }

            foreach (object[] i in array)
            {
                ingredient.datePeremption = Convert.ToDateTime(i[4]);
            }

            foreach (object[] i in array)
            {
                ingredient.canBePrepared = Convert.ToBoolean(i[5]);
            }

            Assert.AreEqual("Tomate", ingredient.NomIngredient);
            Assert.AreEqual("Longue conserv", ingredient.typeIngredient);
            Assert.AreEqual(25, ingredient.quantityIngredient);
            Assert.AreEqual(Convert.ToDateTime("11/12/2018 00:00:00"), ingredient.datePeremption);
            Assert.AreEqual(Convert.ToBoolean(1), ingredient.canBePrepared);
        }
    }

}
