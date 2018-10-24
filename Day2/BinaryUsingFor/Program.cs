using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryUsingFor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("양의 십진수 하나를 입력하세요.");

            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("입력한 십진수 숫자인 {0} 은(는)", num);

            int rem = num % 2;
            string bi = Convert.ToString(rem);

            for (int quo = num / 2; quo > 0;)
            {
                try
                {
                    rem = quo % 2;
                    quo = quo / 2;
                    bi = Convert.ToString(rem) + bi;
                }
                catch (ArithmeticException e)
                {
                    break;
                }
            }

            Console.WriteLine("이진수로 변경하면 {0} 입니다.", bi);
            Console.WriteLine();
        }
    }
}
