using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class Waiter : Staff, ObserverWaiter
    {
        public bool HaveToKillHimself;
        public bool Busy { get; set; }
        public int IdWaiter;
        public List<String> dishInHand;
        public List<int> idClientToServe;
        public List<Table> TablesToServe;

        public Waiter(int IdWaiter)
        {
            HaveToKillHimself = false;
            TablesToServe = new List<Table>();
            idClientToServe = new List<int>();
            dishInHand = new List<String>();
            this.IdWaiter = IdWaiter;
            Thread MasterHotelThread;
            MasterHotelThread = new Thread(new ThreadStart(CheckTableState));
        }

        public void CheckTableState()
        {
            while (!HaveToKillHimself)
            {
                Boolean cleaned = false;
                foreach (Table table in Room.tableList)
                {
                    if (table.State_Diner == "Dirty")
                    {
                        //se déplace à la position de la table table.tableId
                        SetTable(table);
                        cleaned = true;
                    }
                    if (cleaned)
                    {
                        //retourne à sa position d'observation
                        cleaned = false;
                    }
                    socket.senddirty();
                }
            }
            
        }

        public static void SetTable(Table table)
        {
            table.State_Diner = "Clean";
        }

        public void ServeCustomer()
        {
            //check si une commande est complete
            bool HandIsFull = false;
            if (Temp.plateCommanded != null)
            {
                //repérer son carré
                foreach (Square squares in Room.squareList)
                {
                    //repérer son RankChief
                    if (squares.RankChiefOfTheSquare.IdRankChief == this.IdWaiter)
                    {
                        //pour toutes les tables sous la responsabilité du RankChief auquel il répond
                        foreach (Table tables in squares.RankChiefOfTheSquare.tableOfThisRankChief)
                        {
                            TablesToServe.Add(tables);
                            foreach (CustomerGroup customGroup in Room.customerGroupList)
                            {
                                //repère les groupes de clients sur les tables dont le serveur est responsable
                                if(customGroup.TableAssigned == tables.tableId)
                                {
                                    int increment = 0;
                                    //pour tous ces clients
                                    foreach(Customer custom in customGroup.customerList)
                                    {
                                        foreach(Command command in Room.commandList)
                                        {
                                            if(command.customer[increment] == custom)
                                            {
                                                bool toKill = false;
                                                foreach(String dishInTemp in Temp.plateCommanded)
                                                {
                                                    if(command.Starter[increment] == dishInTemp)
                                                    {
                                                        dishInHand.Add(dishInTemp);
                                                        idClientToServe.Add(custom.IdCustomer);
                                                        toKill = true;
                                                        //Prend le plat
                                                    }
                                                    else if(command.MainCourse[increment] == dishInTemp)
                                                    {
                                                        dishInHand.Add(dishInTemp);
                                                        idClientToServe.Add(custom.IdCustomer);
                                                        toKill = true;
                                                        //Prend le plat
                                                    }
                                                    else if(command.Dessert[increment] == dishInTemp)
                                                    {
                                                        dishInHand.Add(dishInTemp);
                                                        idClientToServe.Add(custom.IdCustomer);
                                                        toKill = true;
                                                        //Prend le plat
                                                    }
                                                    if(toKill = true)
                                                    {
                                                        Temp.plateCommanded.Remove(dishInTemp);
                                                    }
                                                    if(dishInHand.Count() == 5)
                                                    {
                                                        HandIsFull = true;
                                                        break;
                                                    }
                                                }
                                            }
                                            if(HandIsFull)
                                            {
                                                break;
                                            }
                                        }
                                        if (HandIsFull)
                                        {
                                            break;
                                        }
                                        increment = increment + 1;
                                    }
                                }
                                if (HandIsFull)
                                {
                                    break;
                                }

                            }
                            if (HandIsFull)
                            {
                                break;
                            }

                        }
                 
                    }
                    if (HandIsFull)
                    {
                        break;
                    }
                }
            }
            if (dishInHand != null)
            {
                foreach (String dishToServe in dishInHand)
                {
                    foreach(Table tablesToServe in TablesToServe)
                    {
                        foreach(Table tables in Room.tableList)
                        {
                            if(tables.tableId == tablesToServe.tableId)
                            {

                                break;
                            }
                        }


                    }
                }
            }
            
        }
    }
}
