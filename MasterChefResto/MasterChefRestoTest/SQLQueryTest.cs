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
            string cmd = string.Format("SELECT * FROM Materiel WHERE nom_materiel = 'Nappe' AND etat_materiel = 'Propre' ;");
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
                Assert.AreEqual(31, (int)i[0]);
                Assert.AreEqual("Nappe", i[1].ToString());
                Assert.AreEqual("Matériel commun", i[2].ToString());
                Assert.AreEqual("Propre", i[3].ToString());
                Assert.AreEqual(40, (int)i[4]);
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

        [TestMethod]
        public void operationToDB()
        {
            SqlConnection connection = new SqlConnection("server=10.176.50.33;" + "user id=projet-resto;" + "password=azerty123;" + "database=masterchef;" + "connection timeout=30");
            connection.Open();

            string cmds = string.Format("SELECT quantite_materiel FROM Materiel WHERE nom_materiel = 'Nappe' AND etat_materiel = 'Propre' ;");
            SqlCommand querys = new SqlCommand(cmds, connection);
            SqlDataReader reader = querys.ExecuteReader();
            int quantity = new int();
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
                quantity = (int)i[0];
            }

            result.Clear();

            string operateur1 = "+";
            string operateur2 = "-";

            string cmdu = string.Format("UPDATE Materiel SET quantite_materiel = quantite_materiel {0} 15 WHERE nom_materiel = 'Nappe' AND etat_materiel = 'Propre';", operateur2);
            SqlCommand queryu = new SqlCommand(cmdu, connection);
            queryu.ExecuteNonQuery();

            reader = querys.ExecuteReader();


            while (reader.Read())
            {
                Object[] row = new Object[reader.FieldCount];
                reader.GetValues(row);
                result.Add(row);
            }

            reader.Close();

            foreach (object[] i in result)
            {
                Assert.AreEqual(quantity - 15, (int)i[0]);
            }

            result.Clear();

            cmdu = string.Format("UPDATE Materiel SET quantite_materiel = quantite_materiel {0} 15 WHERE nom_materiel = 'Nappe' AND etat_materiel = 'Propre';", operateur1);
            queryu = new SqlCommand(cmdu, connection);
            queryu.ExecuteNonQuery();

            reader = querys.ExecuteReader();


            while (reader.Read())
            {
                Object[] row = new Object[reader.FieldCount];
                reader.GetValues(row);
                result.Add(row);
            }

            reader.Close();

            foreach (object[] i in result)
            {
                Assert.AreEqual(quantity, (int)i[0]);
            }
        }

    }
}
