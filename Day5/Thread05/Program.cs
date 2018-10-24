using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread05
{
    class Program
    {
        bool sleep = false;

        static AutoResetEvent autoEvent = new AutoResetEvent(false);

        public void FirstWork()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("F{0}", i);
                if(i == 5)
                {
                    sleep = true;
                    Console.WriteLine("");
                    Console.WriteLine("first 쉼");
                    autoEvent.WaitOne();
                }
            }
        }

        public static void Main()
        {
            Program t = new Program();
            Thread first = new Thread(new ThreadStart(t.FirstWork));
            first.Start();
            while (t.sleep == false) { }
            Console.WriteLine("first를 꺠웁니다. 2초 후 꺠어납니다.");
            Thread.Sleep(2000);
            autoEvent.Set();
        }
    }
}
// AutoResetEvent