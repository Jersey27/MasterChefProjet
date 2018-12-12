using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    class SQLQuery
    {
        /// <summary>
        /// La commande SQL
        /// </summary>
        SqlCommand query;

        /// <summary>
        /// Effectue une requête de selection SQL SERVER
        /// </summary>
        /// <param name="selection">Les Attributs a récupérer</param>
        /// <param name="table">La table utilisé pour récupérer les données</param>
        /// <param name="condition">Les conditions spécique de récupération</param>
        /// <param name="connection">La connection à la base de données</param>
        /// <returns>Le résultat de la requête</returns>
        public ArrayList selectFromDB(string selection, string table, string condition, SqlConnection connection)
        {
            string cmd = string.Format("SELECT {0} FROM {1} WHERE {2};", selection, table, condition);
            query = new SqlCommand(cmd, connection);
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


        /// <summary>
        /// récupère la recette selon son type
        /// </summary>
        /// <param name="typeRecipe">Le type de recette à récupérer</param>
        /// <param name="connection">La connection à la base de donnée</param>
        /// <returns>La recette demandée</returns>
        public List<String> getRecipe(string typeRecipe, SqlConnection connection)
        {
            ArrayList recipeDB = new ArrayList();
            List<string> recipes = new List<string>();

            string condition = string.Format("type_recette = {0}", typeRecipe);

            recipeDB = selectFromDB("nom_recette", "Recettes", condition, connection);

            foreach (object[] i in recipeDB)
            {
                recipes.Add(i[0].ToString());
            }

            return recipes;
        }
    }
}
