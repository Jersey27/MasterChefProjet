using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Collections;
using Newtonsoft.Json;
using System.IO;

namespace MasterChefCuisine.Model
{
    public class SocketManagement
    {
        #region variable
        private static SocketManagement instance;
        private List<ObserverChief> chiefs = new List<ObserverChief>();
        private IPAddress ip = IPAddress.Parse("10.176.129.194");
        private Socket socket, client;
        private bool service = true;
        List<Plunger> plungers = new List<Plunger>;
        private object socketmanager;
        #endregion
        private SocketManagement(bool isTest)
        {
            if (!isTest)
            {
                
                ArrayList acceptList = new ArrayList();
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(new IPEndPoint(ip, 23456));
                socket.Listen(1);
                while (true) {
                    client = socket.Accept();
                    MyThread newThread = new MyThread(client);
                    Thread _connec = new Thread(new ThreadStart(newThread.Connection));

                    acceptList.Add(client);
                    _connec.Start();
                    //Thread writer = new Thread();
                }
            }


        }


        #region commande du socket
        public class MyThread
        {
            Socket client;
            SocketManagement management;


            public MyThread(Socket newclient)
            {
                client = newclient;
                management = SocketManagement.getInstance(false);
            }

            public void Receivecommand()
            {
                bool listener = true;
                while (listener)
                {
                    byte[] data = new byte[1024];
                    client.Receive(data);

                    string message = System.Text.Encoding.UTF8.GetString(data);
                    Command newCommand = JsonConvert.DeserializeObject<Command>(message);
                    management.UpdateChiefObserver(newCommand);

                }


                // client.Shutdown(SocketShutdown.Receive);
                // client.Close();
            }
        }
        public void sendPlate(Command command)
        {
            string message = JsonConvert.SerializeObject(command);
            byte[] msg = System.Text.Encoding.UTF8.GetBytes(message);
            client.Send(msg, msg.Length, SocketFlags.None);
            //socket.
        }

        public void receiveddurty(Plunger dirty)
        {
            byte[] data = new byte[1024 * 4];
            int readBytes = client.Receive(data);

            MemoryStream memoryStream = new MemoryStream();

            while (readBytes > 0)
            {
                memoryStream.Write(data, 0, readBytes);

                if (client.Available > 0)
                {
                    readBytes = client.Receive(data);
                }
                else
                {
                    break;
                }
            }
            byte[] totalByte = memoryStream.ToArray();
            memoryStream.Close();
            string message = System.Text.Encoding.UTF8.GetString(totalByte);
            Plunger newdirty = JsonConvert.DeserializeObject<Plunger>(message);

            if (message == "dirty")
            {
               UpdatePlungerObserver();
            }
        }
        #endregion
        #region command simulant le socket (test only)
        public void testNewCommand()
        {

        }
        #endregion
        #region observer
        public void addObserverPlunger(Plunger plunger)
        {
            plungers.Add(plunger);
        }
         public void UpdatePlungerObserver()
        {
            foreach(Plunger plunger in plungers)
            {
                plunger.update();
            }
        }

        public void addChiefObserver(ObserverChief chief)
        {
            chiefs.Add(chief);
        }
        public void UpdateChiefObserver(Command command)
        {
            foreach (Chief chief in chiefs)
            {
                chief.Update(command);
            }
        }
        #endregion
        #region instantiation
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
#endregion