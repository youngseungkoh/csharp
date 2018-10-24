using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda01
{
    class Program
    {
        // 델리게이트 생성 : 형식 유추가 가능한 이유
        delegate int Calc(int i, int j);

        static void Main(string[] args)
        {
            // MySum 메서드가 static 이므로 바로 델리게이트의 파라메터가 될 수 있음
            Calc c = new Calc(MySum);
            Console.WriteLine("1+2={0}", c(1, 3));

            Calc c1 = delegate (int i, int j) { return i + j; };
            Console.WriteLine("3+4={0}", c1(3, 4));

            Calc c2 = (int a, int b) => a + b;
            Console.WriteLine("3+4={0}", c2(3, 4));

            Calc c3 = (a, b) => a + b;
            Console.WriteLine("3+4={0}", c3(3, 4));
        
        }

        static int MySum(int i, int j)
        {
            return i + j;
        }
    }
}
