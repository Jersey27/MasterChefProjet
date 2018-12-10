using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public abstract class SQLQuery
    {
        SqlCommand query;

        public ArrayList selectFromDB(string selection, string table, string condition, SqlConnection connection)
        {
            string cmd = string.Format("SELECT {0} FROM {1} WHERE {2}", selection, table, condition);
            query = new SqlCommand(cmd , connection);
            SqlDataReader reader = query.ExecuteReader();
            ArrayList result = new ArrayList();

            while (reader.Read())
            {
                Object[] row = new Object[reader.FieldCount];
                reader.GetValues(row);
                result.Add(row);
            }

            return result;
        }

        public void insertIntoDB()
        {
            
        }
    }
}
