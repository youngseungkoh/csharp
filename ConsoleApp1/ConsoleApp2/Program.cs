using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class ParamsTest
    {
        static void Main()
        {
            ParamsTest p = new ParamsTest();
            Console.WriteLine(p.Sum(j:1, i:2));
        }

        int Sum(int i, int j)
        {
            Console.WriteLine("i={0}, j={1}", i, j);
            return i + j;
        }

         
    }
}
