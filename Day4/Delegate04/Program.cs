using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate04
{
    // 기동 클래스 선언
    class Program
    {
        // 'string 자료형 s를 파라메터로 받고 리턴 자료형이 없는 메서드'를 대리하는 딜리게이트 Deli를 선언
        delegate void Deli(string s);

        // 기동 메서드 선언
        static void Main()
        {
            // 람다식을 사용하여 Deli 자료형 객체 d0를 인스턴스화 (이 때, v는 i, j 등의 다른 값으로 변경할 수 있다) - 익명함수 사용
            // Deli d0 = (string v) => Console.WriteLine(v); // 이 모양으로도 불러올 수 있다
            Deli d0 = (v) => Console.WriteLine(v);
            d0.Invoke("OJC - This is a string from object d0");

            // 메서드 d를 파라메터로 해서 Deli 자료형 객체 d1을 인스턴스화 
            Deli d1 = new Deli(d);
            d1.Invoke("OJC - This is a string from object d1");

            // 메서드 d를 파라메터로 해서 Deli 자료형 객체 d2를 인스턴스화 (new 구문을 생략)
            Deli d2 = d;
            d2.Invoke("OJC - This is a string from object d2");
        }

        // string 자료형 파라메터 s를 받고 리턴 자료형이 없는 메서드 (딜리게이터 Deli가 대리할 메서드) d를 선언 - static
        static void d(string s)
        {
            Console.WriteLine(s);
        }
    }
}
