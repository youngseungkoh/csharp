using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread04
{
    class Program
    {
        public static Thread sleeperThread;
        
        public static void Main(string[] args)
        {
            sleeperThread = new Thread(new ThreadStart(ThreadToSleep));
            sleeperThread.Start();
            sleeperThread.Interrupt();
        }

        private static void ThreadToSleep()
        {
            int i = 0;
            while (true)
            {
                Console.WriteLine("[Sleeper : " + i++ + "]");
                
                if(i == 9)
                {
                    try
                    {
                        Console.WriteLine("i가 9가 되어 1초 쉼");
                        Thread.Sleep(1000);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine("방해!");
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}

// thread 종료