using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MasterChefCuisine.Model
{
    public abstract class SQLQuery
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
        /// Effectue une mise a jour de la table via SQL SERVER
        /// </summary>
        /// <param name="table">la table utilisé pour modifier les données</param>
        /// <param name="column">l'attribut a modifier</param>
        /// <param name="value">La nouvelle valeur</param>
        /// <param name="condition">La condition spécifique pour les données</param>
        /// <param name="connection">la connection à la base de données</param>
        public void updateDB(string table, string column, string value, string condition, SqlConnection connection)
        {
            string cmd = string.Format("UPDATE {0} SET {1} = {2} WHERE {3};", table, column, value, condition);
            query = new SqlCommand(cmd, connection);
            query.ExecuteNonQuery();
        }
        
        /// <summary>
        /// récupère la recette selon son nom
        /// </summary>
        /// <param name="recipeName">Le nom de la recette à récupérer</param>
        /// <param name="connection">La connection à la base de donnée</param>
        /// <returns>La recette demandée</returns>
        public Recipe getRecipe(string recipeName, SqlConnection connection)
        {
            ArrayList recipeDB = new ArrayList();
            ArrayList ings = new ArrayList();
            Ingredient ingred = new Ingredient();
            List<Ingredient> ingredients = new List<Ingredient>();
            Recipe recipe = new Recipe();

            string condition = string.Format("nom_recette = {0}", recipeName);

            recipeDB = selectFromDB("*", "Recettes", condition, connection);

            foreach (object[] i in recipeDB)
            {
                recipe.IdRecipe = (int)i[0];
            }

            foreach (object[] i in recipeDB)
            {
                recipe.NameRecipe = i[1].ToString();
            }

            foreach (object[] i in recipeDB)
            {
                recipe.tpsCook = (int)i[2];
            }

            foreach (object[] i in recipeDB)
            {
                recipe.tpsRest = (int)i[3];
            }

            foreach (object[] i in recipeDB)
            {
                recipe.tpsPrep = (int)i[4];
            }

            foreach (object[] i in recipeDB)
            {
                recipe.nombre_parts = (int)i[5];
            }

            condition = string.Format("id_recette = {0}", recipe.IdRecipe);
            ings = selectFromDB("id_ingredient, quantite_ingredient_recette", "Composition_ingredient", condition, connection);

            foreach (object[] i in ings)
            {
                ingred = getIngredient((int)i[0], connection);
                ingredients.Add(ingred);
            }

            recipe.Ingredients = ingredients;

            return recipe;
        }

        /// <summary>
        /// récupère un ingrédient selon son nom
        /// </summary>
        /// <param name="name">Le nom de l'ingrédient à récupérer</param>
        /// <param name="connection"></param>
        /// <returns>L'ingrédient recetteé</returns>
        public Ingredient getIngredient(string name, SqlConnection connection)
        {
            Ingredient ingredient = new Ingredient();

            ArrayList ing = new ArrayList();

            string condition = string.Format("nom_ingredient = {0}", name);

            ing = selectFromDB("*", "Ingredient", condition, connection);

            foreach (object[] i in ing)
            {
                ingredient.NomIngredient = i[1].ToString();
            }

            foreach (object[] i in ing)
            {
                ingredient.typeIngredient = i[2].ToString();
            }

            foreach (object[] i in ing)
            {
                ingredient.quantityIngredient = (int)i[3];
            }

            foreach (object[] i in ing)
            {
                ingredient.datePeremption = (DateTime)i[4];
            }

            foreach (object[] i in ing)
            {
                ingredient.canBePrepared = (bool)i[5];
            }

            return ingredient;
        }

        public Ingredient getIngredient(int id, SqlConnection connection)
        {
            Ingredient ingredient = new Ingredient();

            ArrayList ing = new ArrayList();

            string condition = string.Format("id_ingredient = {0}", id);

            ing = selectFromDB("*", "Ingredient", condition, connection);

            foreach (object[] i in ing)
            {
                ingredient.NomIngredient = i[1].ToString();
            }

            foreach (object[] i in ing)
            {
                ingredient.typeIngredient = i[2].ToString();
            }

            foreach (object[] i in ing)
            {
                ingredient.quantityIngredient = (int)i[3];
            }

            foreach (object[] i in ing)
            {
                ingredient.datePeremption = (DateTime)i[4];
            }

            foreach (object[] i in ing)
            {
                ingredient.canBePrepared = (bool)i[5];
            }

            return ingredient;
        }
    }
}
