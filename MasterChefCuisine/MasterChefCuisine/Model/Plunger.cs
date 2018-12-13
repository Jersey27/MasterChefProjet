using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MasterChefCuisine.Model
{
    public class Plunger : Preparator
    {
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
            List<string> nom = new List<string>();
            List<int> qte = new List<int>();

            foreach (object[] o in matos)
            {
                // o[0] de chaque objet vaut nom_materiel
                nom.Add(o[0].ToString());
                // o[1] de chaque objet vaut quantite_materiel
                qte.Add((int)o[1]);
            }
            // TODO : collecter tout le matériel sale
            while (nom.Count != 0)
            {
                int washing = 0;
                while (washing < 15 || nom.Count != 0)
                {
                    if (qte.First() > 15 - washing)
                    {
                        int mat = qte.First();
                        mat = qte.First() - (washing - 15);
                        washing = 15;
                        Thread.Sleep(10000);

                        string condition = string.Format("nom_materiel = '{0}' AND etat_materiel = '{1}'", nom.First(), "Propre");
                        query.operationToDB("Materiel", "quantite_materiel", mat, condition, true);
                    }
                    else if (qte.First() <= 15 - washing)
                    {
                        int mat = qte.First();
                        washing = washing + qte.First();

                        Thread.Sleep(10000);

                        string condition = string.Format("nom_materiel = '{0}' AND etat_materiel = '{1}'", nom.First(), "Propre");
                        query.operationToDB("Materiel", "quantite_materiel", mat, condition, true);

                        qte.RemoveAt(0);
                        nom.RemoveAt(0);
                    }
                }


                washing = 0;
            }
        }

        public void update()
        {
            Wash();
        }
    }
}
