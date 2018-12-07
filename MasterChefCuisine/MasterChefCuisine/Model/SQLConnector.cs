using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public abstract class SQLConnector
    {
        SQLConnector instance;
        

        public void connect(bool isTest)
        {
            
        }
    }
}
