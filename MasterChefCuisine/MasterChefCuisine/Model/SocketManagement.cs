using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace MasterChefCuisine.Model
{
    public class SocketManagement
    {
        #region variable
        private static SocketManagement instance;
        private ObserverChief chief;
        private IPAddress ip = IPAddress.Parse("10.176.129.194");
        private Socket socket;
        private bool service = true;
        #endregion
        private SocketManagement(bool isTest)
        {
            if(!isTest)
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(new IPEndPoint(ip, 23456));
                socket.Listen(1);
                Socket client = socket.Accept();
                Thread writer = new Thread()
            }
        }
        #region commande du socket

        public void sendMenu()
        {
            socket.
        }
        public void 
        #endregion
        #region command simulant le socket (test only)
        public void testNewCommand()
        {

        }
        #endregion
        #region observer
        public void addChiefObserver(ObserverChief chief)
        {

        }
        public void UpdateChiefObserver()
        {

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