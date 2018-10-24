using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryUsingWhile
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
            int quo = num / 2;
            string bi = Convert.ToString(rem);
            
            while(quo > 0)
            {
                try
                {
                    rem = quo % 2;
                    quo = quo / 2;
                    bi = Convert.ToString(rem) + bi;
                }
                catch(ArithmeticException e)
                {
                    break;
                }
            }

            Console.WriteLine("이진수로 변경하면 {0} 입니다.", bi);
            Console.WriteLine();
        }
    }
}

//Console.WriteLine();

//int rem = num % 2;
//int quo = num / 2;
//string bi = Convert.ToString(rem);
//Console.WriteLine("1회차");
//Console.WriteLine("몫: " + quo);
//Console.WriteLine("나머지: " + rem);
//Console.WriteLine("이진수: " + bi);

//Console.WriteLine();

//rem = quo % 2;
//quo = quo / 2;
//bi = Convert.ToString(rem) + bi;
//Console.WriteLine("2회차");
//Console.WriteLine("몫: " + quo);
//Console.WriteLine("나머지: " + rem);
//Console.WriteLine("이진수: " + bi);

//Console.WriteLine();

//rem = quo % 2;
//quo = quo / 2;
//bi = Convert.ToString(rem) + bi;
//Console.WriteLine("3회차");
//Console.WriteLine("몫: " + quo);
//Console.WriteLine("나머지: " + rem);
//Console.WriteLine("이진수: " + bi);

//Console.WriteLine();

//rem = quo % 2;
//quo = quo / 2;
//bi = Convert.ToString(rem) + bi;
//Console.WriteLine("4회차");
//Console.WriteLine("몫: " + quo);
//Console.WriteLine("나머지: " + rem);
//Console.WriteLine("이진수: " + bi);

//Console.WriteLine();


// 사용자로 부터 십진수를 입력받아 이진수로 변환하는 C# 코드를 작성 하세요.
