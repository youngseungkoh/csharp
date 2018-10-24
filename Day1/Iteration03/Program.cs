using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("콤마로 구분한 숫자 10개를 입력하세요 (예: 1,2,3,4,5,6,7,8,9,10)");
            string[] str =  Console.ReadLine().Split(',');
            int[] num = new int[str.Length];

            for(int i = 0; i < str.Length; i++)
            {
                num[i] = Convert.ToInt32(str[i]);
            }

            for(int k = 0; k < str.Length; k++)
            {
                Console.Write("숫자-{0} :", k+1);
                Console.WriteLine(num[k]);
            }

            int sum = 0;
            for(int j = 0; j < str.Length; j++)
            {
                sum = sum + num[j];
            }
            Console.WriteLine("합 : " + sum);
            Console.WriteLine("평균 : " + (double)sum / str.Length);
        }
    }
}

//10개의 숫자를 입력받아 입력받은 수를 출력하고 합, 평균을 구해 출력하세요.

//Input the 10 numbers :
//숫자-1 :1
//숫자-2 :2
//숫자-3 :3
//숫자-4 :4
//숫자-5 :5
//숫자-6 :6
//숫자-7 :7
//숫자-8 :8
//숫자-9 :9
//숫자-10 :10
//합 : 55
//평균 : 5.5