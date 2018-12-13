using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterChefCuisine.Model;
using System.Data.SqlClient;

namespace MasterChefCuisineTest.Model
{
    [TestClass]
    public class SQLConnectorTests
    {
        SQLConnector instance = SQLConnector.getInstance(true);
        SqlConnection connection;

        [TestMethod]
        public void connect()
        {
            connection = new SqlConnection("server=10.176.50.33;" + "user id=projet-resto;" + "password=azerty123;" + "database=masterchef;" + "connection timeout=30");

            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message));
            } finally
            {
                Assert.AreEqual("Open", connection.State.ToString());
                connection.Close();
            }
            
            
        }

        [TestMethod]
        public void closeConnection()
        {
            connection = new SqlConnection("server=10.176.50.33;" + "user id=projet-resto;" + "password=azerty123;" + "database=masterchef;" + "connection timeout=30");
            connection.Open();

            if (connection.State.ToString() == "Closed")
            {
                Assert.Fail();
            }

            try
            {
                connection.Close();
            } catch (Exception e)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message));
            } finally
            {
                Assert.AreEqual("Closed", connection.State.ToString());
            }
        }

        [TestMethod]
        public void getInstanceTest()
        {
            Assert.IsNotNull(instance);
        }
    }
}
