using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class Chief : ObserverChief
    {
        static Chief instance;
        SocketManagement socket;
        SQLQuery query = SQLQuery.getInstance();
        public List<PartChief> cooks { get; set; }
        private Chief(bool isTest)
        {
            socket = SocketManagement.getInstance(isTest);
            socket.addChiefObserver(this);
            cooks = new List<PartChief>();
        }

        /// <summary>
        /// Assigne le plat a l'un des cuisiniers
        /// </summary>
        /// <param name="command">la commande a diffuser</param>
        public void assignPlate(Command command)
        {
            UpdateObserverCook(command);
            RecipeCanBePrepared(command);
        }

        public static Chief getInstance(bool isTest)
        {
            if(instance == null)
            {
                return new Chief(isTest);
            }
            return instance;
        }

        public void Update(Command command)
        {
            assignPlate(command);
        }

        public void AddObserverCook(PartChief observer)
        {
            cooks.Add(observer);
        }

        public void UpdateObserverCook(Command command)
        {
            bool taskSended = false;
                foreach (PartChief cook in cooks)
                {
                if (!taskSended)
                {
                    cook.update(command);
                    taskSended = true;
                }

            }
        }

        public bool RecipeCanBePrepared(Command command)
        {
            foreach (Ingredient ing in command.recipe.Ingredients)
            {
                Ingredient stockIng = query.getIngredient(ing.NomIngredient);
                if (stockIng.quantityIngredient < ing.quantityIngredient * 2)
                {
                    query.updateDB("Recettes", "available", "false", "nom_recette = '" + command.recipe.NameRecipe + "'");
                }
            }
            return true;
        }
    }
}
