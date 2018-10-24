using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration01
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 1; i < 11; i++){
                if(i % 2 == 0){
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine("");
        }
    }
}

// 다음과 같은 결과를 출력하는 C# 프로그램을 작성하세요. (2 4 6 8 10)