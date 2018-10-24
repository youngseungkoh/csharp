using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice011
{
    class Program
    {
        static void Main(string[] args)
        {
            //가변배열, 처음방에는 1,2 두번째방에는 1,2,3 세번째방에는 1,2,3,4

            int[][] a = {
                new int[] { 1, 2 },
                new int[] { 1, 2, 3 },
                new int[] { 1, 2, 3, 4 }
            };

            //이차원배열(3행 2열), 1행은 (1,2), 2행은 (3,4), 3행은 (5,6)

            int[,] b = new int[3, 2] {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 }
            };

            //상단의 가변배열을 출력
            
            int m = 1;
            Console.WriteLine("가변배열 내\n");
            foreach(int[] i in a) {
                Console.WriteLine("{0}번째 행의 값은", m);
                    foreach(int j in i) {
                        Console.Write(j + " ");
                    }
                m += 1;
                Console.WriteLine(" 입니다.");
                Console.WriteLine("");
            }

            Console.WriteLine("\n---------------\n");

            //상단의 이차원 배열을 출력

            Console.WriteLine("이차원 배열 내부의 값은");
            foreach(int i in b) {
                Console.Write(i + " ");
            }
            Console.WriteLine(" 입니다.");
            Console.WriteLine("\n---------------\n");
        }
    }
}