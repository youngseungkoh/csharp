using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread02
{
    class Program
    {
        static void Thmethod()
        {
            int id = AppDomain.GetCurrentThreadId();
            Console.WriteLine("Thread[{0}] Thmethod Method Running", id);
        }

        static void Main()
        {
            int id = AppDomain.GetCurrentThreadId();
            Console.
        }
    }
}
