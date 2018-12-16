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
        SQLQuery query;
        SQLConnector connector = SQLConnector.getInstance(false);

        [TestMethod]
        public void selectFromDB()
        {
            string cmd = string.Format("SELECT * FROM Materiel WHERE nom_materiel = 'Nappe' AND etat_materiel = 'Propre' ;");
            SqlCommand query = new SqlCommand(cmd, connector.connection);
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
                Assert.AreEqual(31, (int)i[0]);
                Assert.AreEqual("Nappe", i[1].ToString());
                Assert.AreEqual("Matériel commun", i[2].ToString());
                Assert.AreEqual("Propre", i[3].ToString());
                Assert.AreEqual(40, (int)i[4]);
            }

        }

        [TestMethod]
        public void updateDB()
        {
            SqlConnection connection = new SqlConnection("server=10.176.50.33;" + "user id=projet-resto;" + "password=azerty123;" + "database=masterchef;" + "connection timeout=30");
            connection.Open();

            string cmd = string.Format("SELECT quantite_materiel FROM Materiel WHERE nom_materiel = 'Cuitochette' AND etat_materiel = 'Sale' ;");
            SqlCommand query = new SqlCommand(cmd, connection);
            SqlDataReader reader = query.ExecuteReader();

            ArrayList result = new ArrayList();

            while (reader.Read())
            {
                Object[] row = new Object[reader.FieldCount];
                reader.GetValues(row);
                result.Add(row);
            }

            reader.Close();

            foreach(object[] i in result)
            {
                if ((int)i[0] != 15)
                    Assert.Fail();
            }
            result.Clear();

            cmd = string.Format("UPDATE Materiel SET quantite_materiel = 149 WHERE nom_materiel = 'Cuitochette' AND etat_materiel = 'Sale';");
            query = new SqlCommand(cmd, connection);
            query.ExecuteNonQuery();

            cmd = string.Format("SELECT quantite_materiel FROM Materiel WHERE nom_materiel = 'Cuitochette' AND etat_materiel = 'Sale';");
            query = new SqlCommand(cmd, connection);
            reader = query.ExecuteReader();

            while (reader.Read())
            {
                Object[] row = new Object[reader.FieldCount];
                reader.GetValues(row);
                result.Add(row);
            }
            reader.Close();

            foreach (object[] i in result)
            {
                Assert.AreEqual((int)i[0], 149);
            }

            cmd = string.Format("UPDATE Materiel SET quantite_materiel = 15 WHERE nom_materiel = 'Cuitochette' AND etat_materiel = 'Sale';");
            query = new SqlCommand(cmd, connection);
            query.ExecuteNonQuery();
        }

        [TestMethod]
        public void getRecipe()
        {
            SQLQuery instance = SQLQuery.getInstance();

            Recipe recipe = instance.getRecipe("Pâtes carbonara");

            Assert.AreEqual(19, recipe.IdRecipe);
            Assert.AreEqual("Pâtes carbonara", recipe.NameRecipe);
            Assert.AreEqual(15, recipe.tpsCook);
            Assert.AreEqual(0, recipe.tpsRest);
            Assert.AreEqual(5, recipe.tpsPrep);
            Assert.AreEqual(4, recipe.nombre_parts);
            Assert.AreEqual("Plat", recipe.typeRecipe);
            Assert.AreEqual(true, recipe.available);
        }

        [TestMethod]
        public void getIngredient()
        {
            SQLQuery instance = SQLQuery.getInstance();

            Ingredient ingredient = instance.getIngredient(2);

            Assert.AreEqual("Oeufs", ingredient.NomIngredient);
            Assert.AreEqual("Frais", ingredient.typeIngredient);
            Assert.AreEqual(200, ingredient.quantityIngredient);
            Assert.AreEqual(Convert.ToDateTime("20/12/2018 00:00:00"), ingredient.datePeremption);
            Assert.AreEqual(Convert.ToBoolean(1), ingredient.canBePrepared);
        }

    }

}
