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
            int i = 1;
            for (i = 1; i < 6;)
            {
                Console.WriteLine("C# For Loop: Iteration {0}", i);
                i++;
            }
        }
    }
}

//아래의 결과를 낼 것
//C# For Loop: Iteration 1
//C# For Loop: Iteration 2
//C# For Loop: Iteration 3
//C# For Loop: Iteration 4
//C# For Loop: Iteration 5