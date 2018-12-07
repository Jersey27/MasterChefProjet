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

        private SQLConnector(bool isTest)
        {
           
        }

        public void connect(bool isTest)
        {
            
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
