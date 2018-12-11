using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class SQLConnector
    {
        static SQLConnector instance;
        SqlConnection connection;

        private SQLConnector(bool isTest)
        {
            connection = new SqlConnection("server=10.176.50.33;" + "user id=projet-resto;" + "password=azerty123;" + "database=masterchef;" +  "connection timeout=30");

            try
            {
                connection.Open();
            } catch(Exception e)
            {

            }
        }

        public void closeSQLConnection()
        {
            try
            {
                connection.Close();
            } catch(Exception e)
            {

            }
            
        }

        public static SQLConnector getInstance(bool isTest)
        { 
            if (instance != null)
            {
                return instance;
            }
            return new SQLConnector(isTest);
        }
    }
}
