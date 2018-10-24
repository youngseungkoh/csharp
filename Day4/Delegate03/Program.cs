using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate03
{
    // 기동 클래스 선언
    class Program
    {
        // int 자료형 파라메터 i와 j를 받는 메서드를 대리하는 딜리게이트 MyDelegate 선언
        public delegate int MyDelegate(int i, int j);
        
        // 기동 메서드 선언
        public static void Main()
        {
            // MyDelegate 자료형 딜리게이트를 인스턴스화 하는 동시에 TakeADelegate 메서드를 사용해서 Add, Minus, Gop, Nanugi 메서드를 출력 
            TakesADelegate(new MyDelegate(Add));
            TakesADelegate(new MyDelegate(Minus));
            TakesADelegate(new MyDelegate(Gop));
            TakesADelegate(new MyDelegate(Nanugi));
        }

        // MyDelegate 자료형 SomeFunction을 파라메터로 받는 메서드 TakesADelegate를 선언
        // 이 때 파라메터 SomeFunction은 i, j 등 다른 이름으로 바꾸어도 표현해도 되나, int 자료형 파라메터를 두 개 받고 int 자료형을 리턴하는 메서드여야 함 
        public static void TakesADelegate(MyDelegate SomeFunction)
        {
            Console.WriteLine(SomeFunction(1, 2));
        }

        // 딜리게이트에 대리를 맡길 Add, Minus, Gop, Nanugi 메서드를 선언
        public static int Add(int i, int j)
        {
            return i + j;
        }

        public static int Minus(int i, int j)
        {
            return i - j;
        }

        public static int Gop(int i, int j)
        {
            return i * j;
        }

        public static int Nanugi(int i, int j)
        {
            return i / j;
        }
    }
}
