using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public class TimeInRoom
    {
        public static int TimeUnit { set; get; }
        public static int Hour { set; get; }
        public static int Minute { set; get; }
        private static TimeInRoom instance = new TimeInRoom();
        
        private TimeInRoom()
        {
            TimeUnit = 1000;
            Thread TimeThread;
            TimeThread = new Thread(new ThreadStart(ThreadLoop));
        }

        public static void ThreadLoop()
        {
            int increment = 0;
            int nextGroupCustomerIn = 1000;
            Random random = new Random();
            while (Thread.CurrentThread.IsAlive)
            {
                Thread.Sleep(TimeUnit);
                AddMinute();
                increment++;
                if ((Hour > 12 && Hour < 15) || (Hour > 19 && Hour < 22))
                {
                    if (increment == 10)
                    {
                        nextGroupCustomerIn = random.Next(1, 10);
                        nextGroupCustomerIn = nextGroupCustomerIn + increment;
                    }
                    if (increment == nextGroupCustomerIn)
                    {
                        Room.CreateCustomerGroup();
                        increment = 0;
                    }
                }
            }
        }

        public static void AddMinute()
        {
            if(Minute >= 59)
            {
                Minute = 0;
                Hour = Hour + 1;
            }
            else
            {
                Minute = Minute + 1;
            }
        }
        
        public static TimeInRoom getInstance()
        {
            return instance;
        }
    }
}
