using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ06
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = numbers.GroupBy(n => (n % 2 == 0));
            Console.WriteLine("2로 나누어 떨어지는 것과 아닌 것 두 개의 그룹으로 나뉨");

            foreach(IGrouping<bool,int> group in result)
            {
                if (group.Key == true) Console.WriteLine("2로 나누어 떨어지는 것");
                else Console.WriteLine("2로 나누어 떨어지지 않는 것");

                foreach (int num in group) Console.WriteLine(num);
            }
        }
    }
}

// LINQ(GROUP BY 01)