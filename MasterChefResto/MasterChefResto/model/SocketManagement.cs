using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;

namespace MasterChefResto.model
{
    public class SocketManagement
    {
        private static SocketManagement instance = new SocketManagement();
        private Socket client;
        Socket management;


        private SocketManagement()
        {
            management = SocketManagement.getInstance(false);
            
            IPAddress ip = IPAddress.Parse("");
            int port = 12345;
            IPEndPoint ipEnd = new IPEndPoint(ip, port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                client.Connect(ipEnd);
            }
            catch (SocketException E)
            {
                Console.WriteLine("Connection" + E.Message);
            }

            bool listener = true;

            while (listener)
            {
                byte[] data = new byte[1024];
                client.Receive(data);

                string message = System.Text.Encoding.UTF8.GetString(data);
                Command newCommand = JsonConvert.DeserializeObject<Command>(message);
                management.(newCommand);
                if (message == "exit")
                {

                    message = "L'utilisateur s'est déconnecté.";
                    listener = false;

                }
                Console.WriteLine("Message: {0} {1}", message, listener);
            }
        }
        public void sendcommand(Command command)
        {

            string message = JsonConvert.SerializeObject(command);
            byte[] msg = System.Text.Encoding.UTF8.GetBytes(message);
            client.Send(msg, msg.Length, SocketFlags.None);
        }

        public void addwaiterObserver(ObserverWaiter waiter)
        {
            waiter.Add(chief);
        }
        public void UpdateChiefObserver(Command command)
        {
            foreach (Chief chief in chiefs)
            {
                chief.Update(command);
            }
        }


        public static SocketManagement getInstance()
        {
            if (instance != null)
            {
                return instance;
            }
            return new SocketManagement();
        }
    }
}
