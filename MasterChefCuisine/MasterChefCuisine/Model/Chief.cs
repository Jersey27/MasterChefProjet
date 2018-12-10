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
        List<Recipe> menu = new List<Recipe>();
        private Chief(bool isTest)
        {
            socket = SocketManagement.getInstance(isTest);
            socket.addChiefObserver(this);
        }
        public void assignPlate(Command command)
        {
            command.recipe = menu.Find(x => x.IdRecipe == command.recipe.IdRecipe);
        }
        public void newMenu()
        {
            menu = new List<Recipe>();

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
    }
}
