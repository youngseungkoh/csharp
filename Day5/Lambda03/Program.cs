using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda03
{
    class Program
    {
        delegate int Sum(int[] arg);

        static void Main(string[] args)
        {
            Sum sumdeli = (arg) =>
            {
                int mySum = 0;
                foreach (int i in arg) mySum += i;
                return mySum;
            };

            int sum = sumdeli(new int[] { 1, 2, 3, 4, 5 });
            Console.WriteLine("1+2+3+4+5=" + sum);
        }
    }
}
