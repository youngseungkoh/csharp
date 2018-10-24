using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice012
{
    class Program
    {
        static void Main(string[] args) {
            // 4행 2열의 이차원배열을 선언
            int[,] twoDim = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            // Console.WriteLine(twoDim.Length); // 8 (Length를 쓰면 행과 열 구분 없이 길이를 읽는다)

            // 각 차원의 길이가 필요하므로 GetLength룰 사용
            // Console.WriteLine(twoDim.GetLength(0)); // 4 (1차원에 해당하는 '행' 길이를 반환)
            // Console.WriteLine(twoDim.GetLength(1)); // 2 (2차원에 해당하는 '열' 길이를 반환)

            // 반복문 1 (for문 활용)
            for (int i = 0; i < twoDim.GetLength(0); i++)
            {
                for (int j = 0; j < twoDim.GetLength(1); j++)
                {
                    Console.Write(twoDim[i, j]);
                }
            }
            Console.WriteLine();

            // 반복문 2 (foreach문 활용)
            foreach (int k in twoDim)
            {
                Console.Write(k);
            }
        }
    }
}