using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerPractice01
{
    // 제네릭 자료형 인덱서를 멤버로 갖는는 제네릭 자료형 클래스 DataStore를 선언
    class DataStore<T>
    {
        // 제네릭 자료형 private 배열 s를 선언하고, 배열의 길이를 10으로 초기화
        private T[] s = new T[10];

        // int 자료형 index를 파라메터로 받아 제네릭 자료형을 리턴하는 인덱서를 선언 (이 때 index는 i, j 등 원하는 것으로 바꿔도 된다)
        public T this[int index] {

            get{
                // 전달받은 파라메터 index가 예상 밖일 경우(0보다 작은 경우, 배열의 길이인 10보다 큰 경우) 던져지는 에러메세지를 변경
                if (index < 0 || index >= s.Length) throw new IndexOutOfRangeException("Cannot store more than 10 objects");

                // 전달받은 파라메터 index가 예상 안일 경우 배열 s의 index번째 요소를 리턴
                return s[index];
            }
            set{
                // 전달받은 파라메터 index가 예상 밖일 경우(0보다 작은 경우, 배열의 길이인 10보다 큰 경우) 던져지는 에러메세지를 변경
                if (index < 0 || index >= s.Length) throw new IndexOutOfRangeException("Cannot store more than 10 objects");

                // 전달받은 파라메터 index가 예상 안일 경우 배열 s의 index번째 요소에 value를 삽입
                s[index] = value;
            }
        }
    }
    
    // 기동 클래스를 선언
    class Program
    {
        // 기동 메서드를 선언
        static void Main(string[] args)
        {
            // 제네릭 자료형 클래스 DataStore를 string 자료형으로 인스턴스화 (인스턴스화 된 객체명 : ds1)
            DataStore<string> ds1 = new DataStore<string>();

            // string 자료형으로 인스턴스화 된 객체 ds1 내부의 인덱스를 사용하여 배열 ds1.s의 0, 1, 2 번째 요소에 "One", "Two", "Three"를 각각 입력
            ds1[0] = "One";
            ds1[1] = "Two";
            ds1[2] = "Three";

            // string 자료형으로 인스턴스화 된 객체 ds1 내부의 인덱스와 반복문 for를 사용하여 배열 ds1.s의 0, 1, 2 번째 요소를 출력 
            for (int i = 0; i < 3; i++) Console.WriteLine(ds1[i]);

            // 제네릭 자료형 클래스 DataStore를 int 자료형으로 인스턴스화 (인스턴스화 된 객체명 : ds2)
            DataStore<int> ds2 = new DataStore<int>();

            // int 자료형으로 인스턴스화 된 객체 ds2 내부의 인덱스를 사용하여 배열 ds2.s의 0, 1, 2 번째 요소에 1, 2, 3을 각각 입력
            ds2[0] = 1;
            ds2[1] = 2;
            ds2[2] = 3;

            // int 자료형으로 인스턴스화 된 객체 ds2 내부의 인덱스와 반복문 for를 사용하여 배열 ds2.s의 0, 1, 2 번째 요소를 출력
            for (int i = 0; i < 3; i++) Console.WriteLine(ds2[i]);

            // int 자료형으로 인스턴스화 된 객체 ds2 내부의 인덱스를 사용하여 배열 ds2.s의 11번째 요소를 출력하고자 시도
            // 그러나, 배열의 길이는 10으로 초기화 되어있으므로, 입력한 index가 예상 밖인 경우에 해당하고, 에러를 출력함
            // 인덱서 내부의 if 문을 생략하면 "인덱스가 배열 범위를 벗어났습니다."라는 메세지가 출력됨
            ds2[11] = 11; // 처리되지 않은 예외: System.IndexOutOfRangeException: Cannot store more than 10 objects
        }
    }
}