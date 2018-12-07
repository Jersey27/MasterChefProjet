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
        public static int Hour { set; get; }
        public static int Minute { set; get; }
        private static TimeInRoom instance = new TimeInRoom();
        
        private TimeInRoom()
        {
            Thread TimeThread;
            TimeThread = new Thread(new ThreadStart(ThreadLoop));
        }

        public static void ThreadLoop()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                Thread.Sleep(1000);
                AddMinute();
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
