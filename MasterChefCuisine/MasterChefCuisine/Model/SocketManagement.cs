using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class SocketManagement
    {
        private static SocketManagement instance;
        private ObserverChief chief;

        private SocketManagement(bool isTest)
        {
            if(!isTest)
            {

            }
        }

        public void testNewCommand()
        {

        }

        public void addChiefObserver(ObserverChief chief)
        {

        }
        public void UpdateChiefObserver()
        {

        }
        
        public static SocketManagement getInstance(bool isTest)
        {
            if (instance != null)
            {
                return instance;
            }
            return new SocketManagement(isTest);
        }
    }
}
