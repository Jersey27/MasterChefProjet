using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public abstract class Preparator : Employee
    {
        public void prepareLegume(Ingredient ingredient)
        {
            TempStorage tempStorage = TempStorage.getInstance();
            while(ingredient.quantityIngredient > 0)
            {
                if (tempStorage.ingStore.Exists(x => x.NomIngredient == ingredient.NomIngredient + " préparé"))
                {
                    foreach (Ingredient ing in tempStorage.ingStore.Where(x => x.NomIngredient == ingredient.NomIngredient + " préparé"))
                    {
                        ing.quantityIngredient++;
                    }
                }
                else
                {
                    string newName = ingredient.NomIngredient.ToString() + " préparé";
                    Ingredient IngPrep = new Ingredient { NomIngredient = newName, quantityIngredient = 1, typeIngredient = "frais", canBePrepared = false };
                    tempStorage.ingStore.Add(IngPrep);
                }
                ingredient.quantityIngredient--;

            }
            ingredient.Dispose();
        }
    }
}
