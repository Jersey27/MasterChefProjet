﻿using System;
using System.Collections;
using System.Collections.Generic;
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

        public void updateDB(string table, string column, string value, string condition, SqlConnection connection)
        {
            string cmd = string.Format("UPDATE {0} SET {1} = {2} WHERE {3};", table, column, value, condition);
            query = new SqlCommand(cmd, connection);
        }

        public Recipe getRecipe(string recipeName, SqlConnection connection)
        {
            ArrayList recipeDB = new ArrayList();
            ArrayList ings = new ArrayList();
            Ingredient ingred = new Ingredient();
            List<Ingredient> ingredients = new List<Ingredient>();
            Recipe recipe = new Recipe();

            string condition = string.Format("nom_recette = {0}", recipeName);

            recipeDB = selectFromDB("*", "Recettes", condition, connection);

            int recipeId = new Int32();

            foreach (object[] i in recipeDB)
            {
                recipeId = (int)i[0];
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

            condition = string.Format("id_recette = {0}", recipeId);
            ings = selectFromDB("id_ingredient, quantite_ingredient_recette", "Composition_ingredient", condition, connection);

            foreach (object[] i in ings)
            {
                ingred = getIngredient((int)i[0], connection);
                ingredients.Add(ingred);
            }

            recipe.Ingredients = ingredients;

            return recipe;
        }

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
