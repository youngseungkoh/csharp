using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePractice02
{
    // 아무 파라메터도 받지 않고 아무 결과도 리턴하지 않는 델리게이트 Callback을 선언
    public delegate void Callback();

    // 기동 클래스 선언
    class Program
    {
        // 기동 메서드 선언
        static void Main(string[] args)
        {
            // MyClass 클래스를 인스턴스화 (인스턴스화 된 객체명 : my)
            MyClass my = new MyClass();

            // Direct call (객체 my 내부의 MyMethod1과 MyMethod2를 직접 호출)
            Console.WriteLine("직접 호출 결과");
            my.MyMethod1();
            my.MyMethod2();
            Console.WriteLine("------------");

            Console.WriteLine("델리게이트 체인을 통한 호출 결과");
            // Call via a delegate (객체 my 내부의 MyMethod1과 MyMethod2를 델리게이트를 이용해 호출
            // MyClass의 GetCallback(Callback callBack) 메소드를 호출하여 MyMethod1, MyMethod2가 호출 되도록 코드를 완성하세요
            Callback cb = (Callback)Delegate.Combine(new Callback(my.MyMethod1), new Callback(my.MyMethod2));
            my.GetCallback(cb);
            Console.WriteLine("");
        }
    }

    // 델리게이트를 파라메터로 받는 메서드를 멤버로 갖는 클래스 MyClass를 선언
    public class MyClass
    {
        // MyClass 생성자 선언
        public MyClass() { }

        // Callback 자료형 델리게이트 callback을 파라메터로 받는 메서드 GetCallback 선언
        public void GetCallback(Callback callBack) {
            // 메서드 호출 시 파라메터로 전달받은 델리게이트를 호출
            callBack();
        }

        // 델리게이트에게 대리를 맡길 메서드 MyMethod1과 MyMethod2를 선언
        public void MyMethod1() { Console.WriteLine("My Method 1"); }
        public void MyMethod2() { Console.WriteLine("My Method 2"); }
    }
}