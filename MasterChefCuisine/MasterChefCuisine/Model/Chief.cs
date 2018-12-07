using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class Chief
    {
        private List<Recipe> recipes;
        static Chief instance;
        SocketManagement socket;
        private Chief(bool isTest)
        {
            
        }
        public void assignPlate()
        {

        }
        public void newMenu()
        {

        }
        public static Chief getInstance(bool isTest)
        {
            if(instance != null)
            {
                return instance;
            }
            return new Chief(isTest);
        }
    }
}
