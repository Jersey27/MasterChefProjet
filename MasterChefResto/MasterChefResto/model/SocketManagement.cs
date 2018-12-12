using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace MasterChefResto.model
{
    public class SocketManagement
    {
        private static SocketManagement instance = new SocketManagement();

        private SocketManagement()
        {
            bool next = true;
            IPAddress ip = IPAddress.Parse("10.176.50.33");
            int port = 12345;
            IPEndPoint ipEnd = new IPEndPoint(ip, port);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                client.Connect(ipEnd);
            }
            catch (SocketException E)
            {
                Console.WriteLine("Connection" + E.Message);
            }

        }

        public static SocketManagement getInstance()
        {
            return instance;
        }
    }
}