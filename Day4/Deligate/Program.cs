using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate01
{
    // 델리게이트를 멤버로 갖는 구동 클래스 선언
    class Delegate
    {
        // 대리하려는 메서드와 파라메터와 반환 자료형이 같은(int 자료형 파라메터 i와 j를 받아 int 자료형을 반환하는) 델리게이트 선언
        private delegate int OnjSum(int i, int j);

        // 구동 메서드 선언
        static void Main(string[] args)
        {
            // 델리게이트를 인스턴스화 방법 1
            //OnjSum myMethod = new OnjSum(Delegate.Sum);

            // 델리게이트를 인스턴스화 방법 2
            //OnjSum myMethod = new OnjSum(Sum);

            // 델리게이트를 인스턴스화 방법 3
            OnjSum myMethod = Sum;

            // OnjSum 자료형으로 인스턴스화 된 델리게이트 myMethod를 사용해 Sum 메서드를 구동 
            Console.WriteLine("두수 합 : {0}", myMethod(10, 30));
        }

        // 델리게이트에게 대리권을 넘길 메서드를 선언
        static int Sum(int i, int j)
        {
            return i + j;
        }
    }
}
