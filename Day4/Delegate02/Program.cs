using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate02
{
    // 메서드를 멤버로 갖는 클래스 선언
    class OnjMath
    {
        // internal : 동일한 cs 파일에서 접근 할 수 있다
        // static : 정적 멤버는 클래스 인스턴스가 생성되지 않은 경우에도 클래스에 대해 호출할 수 있다.

        // double 자료형 파라메터 value를 받는 메서드 MultipleByTwo를 선언 - static
        internal static double MultipleByTwo(double value) { return value * 2; }

        // double 자료형 파라메터 value를 받는 메서드 Square를 선언 - static
        internal static double Square(double value) { return value * value; }
    }

    // 대리하려는 메서드와 파라메터 및 리턴 자료형이 같은 (double 자료형 파라메터 x를 받아 double 자료형을 리턴하는) 델리게이트 OnjDouble을 선언
    // OnjMath.MultipleByTow와 OnjMath.Square를 모두 대리할 수 있다
    delegate double OnjDouble(double x);

    // 기동 클래스 선언
    class Program
    {
        // 기동 메서드 선언
        static void Main(string[] args)
        {
            // OnjDouble 델리게이트를 사용하여 배열 op를 인스턴스화
            OnjDouble[] op =
            {
                // OnjDouble 델리게이트를 사용하여 OnjMath클래스의 멤버 메서드 MultipleByTwo를 인스턴스화 하고, 배열 op의 요소에 삽입
                new OnjDouble(OnjMath.MultipleByTwo),

                // OnjDouble 델리게이트를 사용하여 OnjMath클래스의 멤버 메서드 Square를 인스턴스화 하고, 배열 op의 요소에 삽입
                new OnjDouble(OnjMath.Square)
            };

            // int 자료형 변수 i를 선언하고, 값을 0으로 초기화
            // OnjDouble 델리게이트 자료형 배열 op의 길이를 사용하여 for문 구동
            for (int i = 0; i < op.Length; i++) {
                Console.WriteLine("op[{0}] 호출: ", i);
                // OnjDouble 델리게이트 자료형 배열 op[i]와 double 자료형 변수를 파라메터로 받는 CallDelegate 메서드를 사용하여
                // MultiplyByTwo와 Square 메서드 기동
                CallDelegate(op[i], 3.0);
                Console.WriteLine();
            }
        }

        // OnjDouble 델리게이트 자료형 func, double 자료형 value를 파라메터로 받는 CallDelegate 메서드를 선언 - static
        static void CallDelegate(OnjDouble func, double value)
        {
            // double 자료형 변수 ret을 선언하고, double 자료형 value를 파라메터로 받는 OnjDouble 델리게이트 자료형 func로 초기화
            double ret = func(value);

            // double 자료형 파라메터 value와 double 자료형 변수 ret를 출력
            Console.WriteLine("입력된 값은 {0}이고 결과는 {1}이다.", value, ret);
        }
    }
}
