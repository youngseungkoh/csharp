using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate06
{
    // '리턴 자료형이 void 이고, int 자료형 a와 b를 파라메터로 받는 메서드' 를 대리하는 delegate OnjDelegate를 선언 
    delegate void OnjDelegate(int a, int b);

    // 기동 클래스 선언
    class Program
    {
        // OnjDelegate에 대리를 맡길 수 있는 메서드 Plus, Minus, Multi, Div를 선언
        static void Plus(int a, int b) { Console.WriteLine("{0} + {1} = {2}", a, b, a + b); } // static : 인스턴스화 되지 않음
        static void Minus(int a, int b) { Console.WriteLine("{0} - {1} = {2}", a, b, a - b); } // static : 인스턴스화 되지 않음
        void Multi(int a, int b) { Console.WriteLine("{0} * {1} = {2}", a, b, a * b); }
        void Div(int a, int b) { Console.WriteLine("{0} / {1} = {2}", a, b, a / b); }

        // 메인 메서드 선언
        static void Main()
        {
            // 기동 클래스를 인스턴스화 (인스턴스화 된 객체명 : m)
            Program m = new Program();

            // OnjDelegate 자료형 객체 4종을 인스턴스화 하고, 이들을 엮어 딜리게이트 체인 객체 Callback으로 인스턴스화
            // 이 때 4종 각각에 대한 객체 이름은 없고, 딜리게이트 체인 객체 Callback이 호출 될 경우 4종이 각각 대리하는 메서드가 모두 호출된다
            OnjDelegate Callback = new OnjDelegate(Program.Plus);
            Callback = Callback + new OnjDelegate(Program.Minus);
            Callback = Callback + new OnjDelegate(m.Multi);
            Callback = Callback + new OnjDelegate(m.Div);

            // 인스턴스화 된 델리게이트 체인 Callback을 사용해 OnjDelegate 자료형의 네 객체를 모두 호출
            Callback(4, 3);
        }
    }
}

// 델리게이트 멀티캐스팅 1