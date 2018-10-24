using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncDelegate01
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int> func1 = () => 10;
            Console.WriteLine(func1());

            Func<int, int> func2 = (x) => x * x;
            Console.WriteLine("func2 :: {0}", func2(2));

            Func<string, string> func3 = (str) => str.ToUpper();
            Console.WriteLine("func3 :: {0}", func3("ojc"));

            Func<string, char[]> func4 = delegate (string str) { return str.ToArray(); };
            Console.WriteLine("func4 :: 배열크기 = {0}, 처음요소 = {1}", func4("ojc").Count(), func4("ojc ")[0]);

            Func<string, string> func5 = convertUpper;
            Console.WriteLine("onj를 대문자로 {0}", func5("onj"));

            Func<string, string> func6 = (str) => str.ToLower();
            string[] onjs = { "ONJ", "ONJ2", "ONJ3" };
            IEnumerable<String> onjWords = onjs.Select(func6);
            foreach (string word in onjWords) Console.WriteLine(word);
        }
        static string convertUpper(string str) { return str.ToUpper(); }
    }
}
