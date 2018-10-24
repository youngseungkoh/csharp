using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class AsTest
    {
        class Emp
        {
            public override string ToString()
            {
                return "e is Emp. It is like a extends of JAVA";
            }
        }

        class Programmer : Emp { }

        class Program
        {
            static void Main()
            {
                Programmer p = new Programmer();
                Emp e = p as Emp;
                if (e != null) System.Console.WriteLine(e.ToString());
            }
        }
    }
}
