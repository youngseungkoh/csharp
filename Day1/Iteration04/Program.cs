using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("출력을 원하는 구구단 단수 : ");
            int num = Convert.ToInt32(Console.ReadLine());

            for(int i = 2; i < 10; i++){
                for(int j = 1; j < num + 1; j++){
                    Console.Write("{0}x{1} = {2}", j, i, j * i);
                    if(j == num){
                        Console.Write("\n");
                    } else{
                        Console.Write(", ");
                    }
                }
            }
        }
    }
}

//다음과 같이 출력결과를 만들어내는 C# 프로그램을 작성하세요.
 
//출력을 원하는 구구단 단수 : 3
//1x2 = 2, 2x2 = 4, 3x2 = 6
//1x3 = 3, 2x3 = 6, 3x3 = 9
//1x4 = 4, 2x4 = 8, 3x4 = 12
//1x5 = 5, 2x5 = 10, 3x5 = 15
//1x6 = 6, 2x6 = 12, 3x6 = 18
//1x7 = 7, 2x7 = 14, 3x7 = 21
//1x8 = 8, 2x8 = 16, 3x8 = 24
//1x9 = 9, 2x9 = 18, 3x9 = 27