using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace MasterChefResto.model
{
    public class SocketManagement
    {
        private static SocketManagement instance = new SocketManagement();
        private Socket client;
        Socket management;
        List<ObserverWaiter> waiters;
        

        private SocketManagement()
        {
           
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
        }
        public void reader(Command command)
        {

            bool listener = true;

            while (listener)
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
                Command newCommand = JsonConvert.DeserializeObject<Command>(message);

            }
        }
        public void sendcommand(Command command)
        {

            string message = JsonConvert.SerializeObject(command);
            byte[] msg = System.Text.Encoding.UTF8.GetBytes(message);
            client.Send(msg, msg.Length, SocketFlags.None);
        }

        public void senddirty ()
        {

            string message = "dirty";
            message = JsonConvert.SerializeObject(message);
            byte[] msg = System.Text.Encoding.UTF8.GetBytes(message);
            client.Send(msg, msg.Length, SocketFlags.None);

        }

        public void addwaiterObserver(ObserverWaiter waiter)
        {
            waiters.Add(waiter);
        }
        public void UpdateChiefObserver(Command command)
        {
            foreach (Waiter chief in waiters)
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