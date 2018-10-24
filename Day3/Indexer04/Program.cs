using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer04
{
    // 제네릭 타입의 클래스를 선언
    class HasGenericIndexer<T>
    {
        // 제네릭 타입의 private 배열 arr을 선언하고, 배열의 길이를 10으로 초기화
        private T[] arr = new T[10];

        // int 자료형 i를 프로퍼티로 받는 제네릭 타입의 인덱서를 선언
        public T this[int i]
        {
            // this[int i] 형식으로 호출될 경우 arr[i]를 리턴
            get { return arr[i]; }

            // arr[i] = value 형식으로 호출될 경우 배열 arr의 i 번째 자리에 value를 삽입
            set { arr[i] = value; }
        }
    }

    // 기동 클래스
    class Program
    {
        static void Main(string[] args)
        {
            // 제네릭 타입의 Indexer를 사용하는 제네릭 타입의 클래스 HasGenericIndexer를 string 타입으로 인스턴스화
            HasGenericIndexer<string> a = new HasGenericIndexer<string>();

            // String 타입으로 인스턴스화 된 객체 a 내부의 Indexer를 사용하여 배열 a.arr에 자료를 set
            a[0] = "Hello";

            // String 타입으로 인스턴스화 된 객체 a 내부의 Indexer를 사용해여 배열 a.arr의 자료를 get
            Console.WriteLine(a[0]); // string 자료형의 Hello가 출력

            Console.WriteLine("--------------------------------------------------");

            // 제네릭 타입의 Indexer를 사용하는 제네릭 타입의 클래스 HasGenericIndexer를 int 타입으로 인스턴스화
            HasGenericIndexer<int> b = new HasGenericIndexer<int>();

            // int 타입으로 인스턴스화 된 객체 b 내부의 Indexer를 사용하여 배열 b.arr에 자료를 set
            b[0] = 999;

            // int 타입으로 인스턴스화 된 객체 b 내부의 Indexer를 사용하여 배열 b.arr의 자료를 get
            Console.WriteLine(b[0]);
        }
    }
}
