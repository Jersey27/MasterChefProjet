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
            while (Thread.CurrentThread.IsAlive)
            {

                //recherche des groupes de clients non-assignés à une table
                foreach (CustomerGroup customGroup in Room.customerGroupList)
                {
                    //si un groupe a toujours la valeur par défaut signalant qu'il n'est pas assigné à une table
                    if (customGroup.TableAssigned == -1)
                    {
                        //assigne une table avec un nombre de place adapté (nombre de place supérieur ou égal au nombre de clients dans le groupe)
                        foreach (Table tables in Room.tableList)
                        {
                            //si l'une des tables dans la liste de la Salle correspond à la demande
                            if (customGroup.NbrCustomerInGroup <= tables.NumberOfPlace)
                            {
                                //assigner la table au Groupe de client
                                customGroup.TableAssigned = tables.tableId;
                            }
                        }
                    }
                }
                foreach (CustomerGroup customGroup in Room.customerGroupList)
                {
                    if(customGroup.Finished)
                    {
                        //se fait payer et renvoie les clients
                    }
                }

            }
        }

        public static MasterHotel getInstance()
        {
            return instance;
        }
    }
}
