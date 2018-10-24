using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class Bitoper
    {
        public static void Main(string[] args)
        {
            int i = 10;
            int j = 20;
            int a;

            a = i & j;
            i = i >> 3;
            j = i << 3;

            Console.WriteLine("a={0}, i={1}, j={2}", a, i, j);
            Console.ReadLine();
        }
    }

    class LogicalAnd
    {
        static void Main()
        {
            //Method1이 false라도 Method2 실행
            Console.WriteLine("정상적인 AND:");
            if (Method1() & Method2())
                Console.WriteLine("Both methods returned true.");
            else
                Console.WriteLine("둘 중 하나의 메소드는 false");
        }
    }
}
