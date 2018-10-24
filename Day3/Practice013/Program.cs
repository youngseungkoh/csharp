using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice013
{
    class Program
    {
        static void Main() {
            // 아래 코드의 실행 결과 확인

            // This is a zero-element int array. (아래는 요소가 없는 정수형 배열입니다)
            var values1 = new int[] { };
            Console.WriteLine(values1.Length);

            // This is a zero-element int array also. (아래 역시 요소가 없는 정수형 배열입니다.
            var values2 = new int[0];
            Console.WriteLine(values2.Length);

            // 결과 : 두 형식 모두 0을 반환
            // 의미 : 배열의 길이를 따로 정하지 않으면 자동으로 0으로 설정 된다.
        }
    }
}
