using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread01
{
    public class Program
    {
        public void FirstWork()
        {
            for(int i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("F{0} ", i);
            }
        }

        public void SecondWork()
        {
            for(int i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("S{0} ", i);
            }
        }

        [MTAThread]
        public static void Main()
        {
            Program t = new Program();

            Thread first = new Thread(t.FirstWork);
            Thread second = new Thread(new ThreadStart(t.SecondWork));

            first.Priority = ThreadPriority.Lowest;
            second.Priority = ThreadPriority.Highest;

            first.Start();
            second.Start();
        }
    }
}
