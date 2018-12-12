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
            // On met dans un ArrayList le matos sale récup sur la BDD
            ArrayList matos = query.selectFromDB("nom_materiel, quantite_materiel", "Materiel", "etat_materiel = 'Sale'");

            // La liste de chose en machine prêtes à laver
            List<string> lavage = new List<string>();

            // TODO : collecter tout le matériel sale
            while (dirtydishes.Count > 0)
            {
                for (int i = 0; i <15; i++)
                {
                    // Récupération des valeurs d'un résultat à chaque boucle
                    foreach(object[] o in matos)
                    {
                        // o[0] de chaque objet vaut nom_materiel
                        lavage.Add(o[0].ToString());
                        // o[1] de chaque objet vaut quantite_materiel

                    }
                }
            }
        }

        public void update()
        {
            Wash();
        }
    }
}
