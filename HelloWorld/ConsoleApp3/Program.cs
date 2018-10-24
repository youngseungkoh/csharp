using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class MyConstants
    {
        public const double PI = 3.14;
        public const int MYAGE = 22;
    }

    class Program
    {
        static void Main(string[] args)
        {
            double radius = 2;
            double area = MyConstants.PI * (radius * radius);
            Console.WriteLine("Area = {0}, Age = {1}", area, MyConstants.MYAGE);
            //MyConstants.MYAGE = 20; // ERROR

            const string name = "GilDong Hong";
            Console.WriteLine("name : " + name);

            //name = "Gildong Kim"; // ERROR
        }
    }
}
