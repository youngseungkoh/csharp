using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            int mok;
            string binum = "";

            Int32.TryParse(Console.ReadLine(), out num);
            Console.WriteLine("입력한 숫자는 " + num + " 입니다.");

            mok = num / 2;
            binum = Convert.ToString(num % 2);
            Console.WriteLine("3을 2로 나눈 몫은: " + mok);

            mok = mok / 2;
            binum = binum + Convert.ToString(mok % 2);

            mok = mok / 2;
            binum = binum + Convert.ToString(mok % 2);

            Console.WriteLine(mok);
            Console.WriteLine(binum);
            
            //Console.WriteLine("입력한 숫자를 이진수로 표현하면 " + binum + " 입니다.");

        }
    }
}
