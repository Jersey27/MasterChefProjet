using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class Plunger : Preparator
    {
        static List<IMachine> machines { get; set; }
        ArrayList dirtydishes;
        SQLQuery query = SQLQuery.getInstance();
        public void plunger()
        {
            machines = machines;
        }
        public void Wash()
        {
            // TODO : collecter tout le matériel salle
            while (dirtydishes.Count > 0)
            {
                for (int i = 0; i <15; i++)
                {

                }
            }
        }

        public void update()
        {
            Wash();
        }
    }
}
