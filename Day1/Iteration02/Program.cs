using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration02
{
    class Program
    {
        static void Main(string[] args)
        {
            // 숫자를 입력
            Console.WriteLine("숫자를 입력하세요.");
            int num = Convert.ToInt32(Console.ReadLine());

            // 입력한 숫자를 출력
            Console.WriteLine("\n입력숫자 : " + num);

            // 10 까지의 숫자를 출력
            Console.Write("{0}까지의 숫자 : ", num);
            for (int i = 1; i < num + 1; i++){
                Console.Write(i + " ");
            }
            Console.WriteLine("");

            // 10 까지의 숫자합
            int sum = 0;
            for (int j = 1; j < num + 1; j++)
            {
                sum = sum + j;
            }
            Console.Write("{0}까지의 숫자합은 : ", sum);
            Console.WriteLine(sum + "\n");
        }
    }
}

//숫자를 입력하면 다음과 같이 출력하는 C# 프로그램을 작성하세요. 

//[출력]
//입력숫자 : 10
//10까지의 숫자 : 1 2 3 4 5 6 7 8 9 10
//10까지의 숫자합은 : 55