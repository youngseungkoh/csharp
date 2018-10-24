using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerPractice02
{
    // int 자료형 인덱서를 멤버로 갖는 클래스 선언
    class DataStore
    {
        // string 자료형 배열 strArr를 선언하고, 배열의 길이를 10으로 초기화
        private string[] strArr = new string[10]; // internal data storage (내부 자료 보관함)

        // DataStore 클래스의 생성자 (생략 가능?)
        public DataStore() { }

        // int 자료형 파라메터인 index를 받아 string 자료형을 리턴하는 인덱서 선언
        public string this[int index]
        {
            get{
                // 전달받은 파라메터 index가 예상 밖일 경우(0보다 작은 경우, 배열의 길이인 10보다 큰 경우) 던져지는 에러메세지를 변경
                if (index < 0 || index >= strArr.Length) throw new IndexOutOfRangeException("Cannot store more than 10 objects");

                // 전달받은 파라메터 index가 예상 안일 경우 배열 strArr의 index번째 요소를 리턴
                return strArr[index];
            }
            set
            {
                // 전달받은 파라메터 index가 예상 밖일 경우(0보다 작은 경우, 배열의 길이인 10보다 큰 경우) 던져지는 에러메세지를 변경
                if (index < 0 || index >= strArr.Length) throw new IndexOutOfRangeException("Cannot store more than 10 objects");

                // 전달받은 파라메터 index가 예상 안일 경우 배열 strArr의 index번째 요소에 value를 삽입
                strArr[index] = value;
            }
        }

        // string 자료형 파라메터인 name을 받아 string 자료형을 리턴하는 인덱서를 선언 (인덱서 오버로딩 : 인덱서가 다른 자료형도 받게 함)
        public string this[string name]
        {
            get{
                // DataStore 클래스가 인스턴스화 된 객체 내부의 배열 strArr이 갖는 요소를 s로 표현하고, foreach 문을 사용하여 모든 s에 대해 내부의 연산 적용   
                foreach (string s in strArr){
                    // DataStore 클래스가 인스턴스화 된 객체 내부의 배열 strArr이 갖는 요소 s에 ToLower() 메서드를 적용한 값이
                    // 인덱서가 받은 파라메터인 name에 ToLower() 메서드를 적용한 값과 같을 경우 s를 리턴
                    if (s.ToLower() == name.ToLower()) return s;
                }

                // foreach 반복문에 해당사항이 없을 경우 null을 리턴
                return null;
            }
        }
    }

    // 기동 클래스
    class Program
    {
        // 기동 메서드
        static void Main(string[] args)
        {
            // int 자료형 인덱서를 멤버로 갖는 DataStore 클래스를 인스턴스화 (인스턴스화 된 객체명 : strStore)
            DataStore strStore = new DataStore();

            // 인스턴스화 된 객체 strStore 내부의 인덱서를 사용하여 strArr 배열의 0, 1, 2, 3 번째 요소에 각각 "One", "Two", "Three", "Four"를 삽입
            strStore[0] = "One";
            strStore[1] = "Two";
            strStore[2] = "Three";
            strStore[3] = "Four";

            // 인스턴스화 된 객체 strStore 내부의 인덱서를 사용하여 strArr 배열
            Console.WriteLine(strStore["one"]);
            Console.WriteLine(strStore["two"]);
            Console.WriteLine(strStore["Three"]);
            Console.WriteLine(strStore["FOUR"]);
        }
    }
}

// 아래의 결과를 출력할 수 있도록 괄호 안의 내용을 보충
//One
//Two
//Three
//Four