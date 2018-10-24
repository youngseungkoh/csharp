using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class TypeCastExample2
    {
        public static void Main()
        {
            int a = 50000;
            try
            {
                short b = checked((short)a);
            } catch (Exception e) {
                Console.WriteLine("Exception : {0}", e.StackTrace);
            }
        }
    }
}
