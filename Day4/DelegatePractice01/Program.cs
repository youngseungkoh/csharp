using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePractice01
{
    delegate void Calculate(double i, double j);

    // 기동 클래스 선언
    class Program
    {
        // 기동 메서드 선언
        static void Main(string[] args)
        {
            // 임의의 수를 콤마로 구분해서 Console.ReadLine() 으로 입력 받기
            Console.WriteLine("임의의 두 수를 콤마로 구분해서 입력하세요. (예: 10,20)");

            string a = Console.ReadLine();
            string[] b = a.Split(',');
            double[] c = new double[b.Length];

            for (int i = 0; i < b.Length; i++) c[i] = Convert.ToInt32(b[i]);

            // 델리게이트에 대리를 맡길 사칙연산 메서드를 선언
            void Plus(double i, double j) { Console.WriteLine("{0} + {1} = {2}", i, j, i + j); }
            void Minus(double i, double j) { Console.WriteLine("{0} - {1} = {2}", i, j, i - j); }
            void Multiply(double i, double j) { Console.WriteLine("{0} * {1} = {2}", i, j, i * j); }
            void Divide(double i, double j) { Console.WriteLine("{0} / {1} = {2}", i, j, i / j); }

            // 기동 클래스 Program을 인스턴스화
            Program p = new Program();

            // 델리게이트 Caculate를 사용하여 사칙연산 메서드를 인스턴스화
            Calculate pl = new Calculate(Plus);
            Calculate mi = new Calculate(Minus);
            Calculate mu = new Calculate(Multiply);
            Calculate di = new Calculate(Divide);

            // 델리게이트 Caculate를 사용하여 인스턴스화 한 사칙연산 메서드를 멀티캐스팅
            Calculate calc = pl + mi + mu + di;

            // 입력받은 두 수를 파라메터로 받아 멀티캐스팅 델리게이트를 호출
            Console.WriteLine("\n입력하신 두 수의 사칙연산 결과는 아래와 같습니다.\n");
            calc(c[0], c[1]);
            Console.WriteLine("");
        }
    }
}

// 임의의 수를 콤마로 구분해서 Console.ReadLine() 으로 입력 받은 후 델리게이트를
// 이용하여 사칙연산을 구하는 프로그램을 델리게이트 체인 및 델리게이트 멀티 캐스팅을
// 이용하여 구현하세요.