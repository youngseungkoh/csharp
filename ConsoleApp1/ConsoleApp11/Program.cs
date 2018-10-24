using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("버블정렬");
            Console.WriteLine("콤마로 구분된 숫자를 입력하세요 (예: 1, 2, 3, 4, 5)");
            string s = Console.ReadLine(); // 문자로 입력 받음
            string[] sArr = s.Split(','); // 입력받은 문자열을 ,를 기준으로 잘라 배열에 삽입
            int[] iArr = Array.ConvertAll(sArr, str => int.Parse(str)); // 배열의 문자를 숫자로 변경

            int i;
            int j;
            int temp;
            int k;

            for (i = 1; i < iArr.Length; i++)
            {
                for (j = 0; j < i; j++)
                {
                    // j > i 이면 둘의 자리를 바꾼다
                    if (iArr[j] > iArr[i])
                    {
                        temp = iArr[i];
                        iArr[i] = iArr[j];
                        iArr[j] = temp;
                    }
                }
            }

            Console.WriteLine(" ");
            Console.WriteLine("버블 정렬의 결과는 ");
            for (k = 0; k < iArr.Length; k++)
            {
                Console.Write(iArr[k] + " ");
            }
            Console.WriteLine(" 입니다.");
            Console.WriteLine(" ");
        }
    }
}
