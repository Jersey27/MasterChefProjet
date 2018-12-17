using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class RankChief : Staff
    {
        public int IdRankChief;
        public List<Table> tableOfThisRankChief;
        public bool Busy { get; set; }
        public List<String> menuStarter;
        public List<String> menuMainCourse;
        public List<String> menuDessert;
        public Waiter waiter;

        public RankChief(Waiter waiter, int IdRankChief)
        {
            this.IdRankChief = IdRankChief;
            this.waiter = waiter;
            menuStarter = new List<String>();
            menuStarter = SQLQuery.getRecipe("Entrée");
            menuMainCourse = new List<String>();
            menuMainCourse = SQLQuery.getRecipe("Plat");
            menuDessert = new List<String>();
            menuDessert = SQLQuery.getRecipe("Dessert");
            tableOfThisRankChief = new List<Table>();
            Thread MasterHotelThread;
            MasterHotelThread = new Thread(new ThreadStart(RankChiefLoop));
        }

        private void RankChiefLoop()
        {
            while (Thread.CurrentThread.IsAlive)
            {

                //recherche des groupes de clients non-assignés à une table
                foreach (CustomerGroup customGroup in Room.customerGroupList)
                {
                    foreach(Table tables in tableOfThisRankChief)
                    {
                        //si le groupe de client actuellement traité fait partit du carré dont le RankChief a la charge
                        if(customGroup.TableAssigned == tables.tableId)
                        {
                            //si les clients ne sont pas assis sur leur table
                            if(customGroup.Seated == false)
                            {
                                //les ammène à leur table
                                ///////////////////////////////////////////////////
                                //*à faire*////////////////////////////////////////
                                ///////////////////////////////////////////////////
                                //les assigner à chaque chaise de la table
                                customGroup.Seated = true;
                            }
                            else if(customGroup.Commanded == false)
                            {
                                int nbrOfCommands = Room.commandList.Count();
                                Room.commandList.Add(new Command());

                                //simule l'attente de 5min pour les choix des clients
                                Thread.Sleep(5000);
                                //prendre commande
                                int increment = 0;
                                foreach (Customer custom in customGroup.customerList)
                                {
                                    int choice = customGroup.customerList[increment].chooseInMenu(0, menuStarter.Count() - 1);
                                    Room.commandList[nbrOfCommands].customer.Add(customGroup.customerList[increment]);
                                    Room.commandList[nbrOfCommands].Starter.Add(menuStarter[choice]);
                                    choice = customGroup.customerList[increment].chooseInMenu(0, menuMainCourse.Count() - 1);
                                    Room.commandList[nbrOfCommands].Starter.Add(menuMainCourse[choice]);
                                    choice = customGroup.customerList[increment].chooseInMenu(0, menuDessert.Count() - 1);
                                    Room.commandList[nbrOfCommands].Starter.Add(menuDessert[choice]);
                                }
                                Thread.Sleep(500);

                                tables.couver = customGroup.customerList.Count();

                                //supprimer les éléments de la bdd
                                String condition = "nom_materiel = 'Fourchette' AND etat_materiel = 'Propre'";
                                SQLQuery.operationToDB("Materiel", "quantite_materiel", tables.couver, condition, false);
                                condition = "nom_materiel = 'Couteau' AND etat_materiel = 'Propre'";
                                SQLQuery.operationToDB("Materiel", "quantite_materiel", tables.couver, condition, false);
                                condition = "nom_materiel = 'Cuillère' AND etat_materiel = 'Propre'";
                                SQLQuery.operationToDB("Materiel", "quantite_materiel", tables.couver, condition, false);
                                condition = "nom_materiel = 'Assiette plate' AND etat_materiel = 'Propre'";
                                SQLQuery.operationToDB("Materiel", "quantite_materiel", tables.couver, condition, false);
                                condition = "nom_materiel = 'Verre à eau' AND etat_materiel = 'Propre'";
                                SQLQuery.operationToDB("Materiel", "quantite_materiel", tables.couver, condition, false);

                                //ajouter les couverts à la table
                                
                                Room.waiterList[IdRankChief].tablesTemp.Add(tables.tableId);
                                Room.waiterList[IdRankChief].nbrCustomerTemp.Add(tables.couver);

                            }
                        }
                    }
                }
            }
        }
    }
}

