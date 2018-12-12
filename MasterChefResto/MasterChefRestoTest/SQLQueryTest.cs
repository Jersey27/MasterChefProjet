using System;
using System.Collections;
using System.Data.SqlClient;
using MasterChefResto.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MasterChefRestoTest
{
    [TestClass]
    public class SQLQueryTest
    {
        [TestMethod]
        public void selectFromDB()
        {
            SqlConnection connection = new SqlConnection("server=10.176.50.33;" + "user id=projet-resto;" + "password=azerty123;" + "database=masterchef;" + "connection timeout=30");
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

            foreach (object[] i in result)
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
            List<string> recipes = new List<string>();
            j[0] = "Pizza";

            array.Add(j);
            foreach (object[] i in array)
            {
                recipes.Add(i[0].ToString());
            }

            Assert.AreEqual("Pizza", recipes[0]);
        }

    }
}