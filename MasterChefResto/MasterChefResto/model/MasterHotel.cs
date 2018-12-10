using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class MasterHotel : Staff
    {
        static MasterHotel instance = new MasterHotel();

        public MasterHotel()
        {
            Thread MasterHotelThread;
            MasterHotelThread = new Thread(new ThreadStart(MasterHotelLoop));
        }

        private void MasterHotelLoop()
        {
            /*throw new NotImplementedException();*/
        }

        public void SearchTable(int groupCustomerId)
        {

            //si une table est reconnue comme libre et possède un nombre suffisant de place (choix de la plus petite correspondant à cette dernière contrainte).
        }

        public void AttributeTable()
        {
            //Donne une valeur particulière au client pour le diriger vers la table choisie
        }

        public static MasterHotel getInstance()
        {
            return instance;
        }
    }
}
