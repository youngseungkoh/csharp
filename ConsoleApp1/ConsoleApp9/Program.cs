using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop
{
    class ForLoop
    {

        public static void Main(string[] args)
        {
            int i;
            int j;

            for (i = 0; i < 3; i++)
            {
                j = i;
                Console.WriteLine("i = {0} and j = {1}", i, j);
            }
        }
    }
}

//아래의 결과를 낼 것
//i = 0 and j = 0
//i = 1 and j = 1
//i = 2 and j = 2