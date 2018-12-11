using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Collections;
using Newtonsoft.Json;

namespace MasterChefCuisine.Model
{
    public class SocketManagement
    {
        #region variable
        private static SocketManagement instance;
        private List<ObserverChief> chiefs = new List<ObserverChief>();
        private IPAddress ip = IPAddress.Parse("10.176.129.194");
        private Socket socket;
        private bool service = true;
        #endregion
        private SocketManagement(bool isTest)
        {
            if(!isTest)
            {
                ArrayList acceptList = new ArrayList();
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(new IPEndPoint(ip, 23456));
                socket.Listen(1);
                while (true) { 
                    Socket client = socket.Accept();
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

            public void Connection()
            {
                bool listener = true;
                bool writer = true;
                while (listener)
                {
                    byte[] data = new byte[1024];
                    client.Receive(data);

                    string message = System.Text.Encoding.UTF8.GetString(data);
                    Command newCommand = JsonConvert.DeserializeObject<Command>(message);
                    management.UpdateChiefObserver(newCommand);
                    if (message == "exit")
                    {

                        message = "L'utilisateur s'est déconnecté.";
                        listener = false;

                    }
                    Console.WriteLine("Message: {0} {1}", message, listener);
                    Thread.Sleep(1000);
                }
                while (writer)
                {
                    

                }

                // client.Shutdown(SocketShutdown.Receive);
                // client.Close();
            }
        }
            public void sendMenu()
        {
            //socket.
        }
        #endregion
        #region command simulant le socket (test only)
        public void testNewCommand()
        {

        }
        #endregion
        #region observer
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