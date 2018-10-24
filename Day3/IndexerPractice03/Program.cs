using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerPractice03
{
    // 인덱서를 멤버로 갖는 클래스 선언
    class OvrIndexer
    {
        // string 자료형 배열 myData를 선언
        private string[] myData;

        // int 자료형 변수 arrSize를 선언
        private int arrSize;

        // 이 클래스의 인스턴스화 시점에 int 자료형 파라메터 size를 받도록 생성자를 선언
        public OvrIndexer(int size)
        {
            // 입력되는 int 자료형 파라메터 size로 arrSize 변수를 초기화
            arrSize = size;

            // arrSize를 이용하여 string 자료형 배열 myData의 길이를 초기화 
            myData = new string[arrSize];

            // myData setting (size 변수를 이용하여 for문을 구동하고, string 자료형 배열 myData의 모든 요소에 string "empty"를 삽입)
            for (int i = 0; i < size; i++) myData[i] = "empty";
        }

        // int 자료형 파라메터 pos를 받는 인덱서를 선언 (이 때 pos는 position을 표현할 목적으로 사용한 약자이고, i나 j 등 다른 값으로 바꾸어도 무방)
        public string this[int pos]
        {
            // '인스턴스화 된 객체명[int 자료형 파라메터 pos]'의 형식으로 호출될 경우
            get
            {
                // string 자료형 배열 myData의 pos 번째 요소를 리턴
                return myData[pos];
            }
            // '인스턴스화 된 객체명[int 자료형 파라메터 pos] = string 자료형 값 value'의 형식으로 호출될 경우
            set
            {
                // string 자료형 배열 myData의 pos 번째 요소에 value를 삽입
                myData[pos] = value;
            }
        }

        // string 자료형 파라메터 data를 받는 인덱서를 선언 (이 때 data는 i나 j등 다른 값으로 바꾸어도 무방)
        public string this[string data]
        {
            // '인스턴스화 된 객체명[string 자료형 파라메터 data]'의 형식으로 호출될 경우 
            get
            {
                // int 자료형 변수 count를 선언하고, 값을 0으로 초기화
                int count = 0;

                // int 자료형 변수 i를 선언하고, 값을 0으로 초기화
                // i와 OvrIndexer 클래스의 멤버변수 arrSize를 이용하여 for문 구동
                for (int i = 0; i < arrSize; i++)
                {
                    // string 자료형 배열 myData의 i 번째 요소가 string 자료형 파라메터 data와 같은 경우 count 변수의 값을 1씩 증가
                    if (myData[i] == data) { count++; }
                }
                // for문 구동 완료 후 string 자료형 변수 count를 string 자료형으로 변환
                return count.ToString();
            }

            // '인스턴스화 된 객체명[string 자료형 파라메터 data] = string 자료형 값'의 형식으로 호출될 경우
            set
            {
                // int 자료형 변수 i를 선언하고, 값을 0으로 초기화
                // i와 OvrIndexer 클래스의 멤버변수 arrSize를 이용하여 for문 구동
                for (int i = 0; i < arrSize; i++)
                {
                    // string 자료형 배열 myData의 i 번째 요소가 string 자료형 파라메터 data와 같은 경우 myData의 i 번째 요소에 value를 삽입
                    if (myData[i] == data) { myData[i] = value; }
                }
            }
        }
    }

    // 기동 클래스 선언
    class Program
    {
        // 기동 메서드 선언
        static void Main(string[] args){
            // int 자료형 변수 size를 선언하고, 값을 10으로 초기화
            int size = 10;

            // 변수 size를 파라메터로 사용하여 OvrIndexer 클래스를 인스턴스화 (인스턴스화 된 객체 명 : myInd)
            // 이 때 생성자에 의해 객체 myInd 안에 생성되는 배열 myData의 모든 요소들이 "empty"로 초기화 됨 
            OvrIndexer myInd = new OvrIndexer(size);

            // 객체 myInd의 인덱서를 사용하여 
            // myInd 내부의 string 자료형 배열 myData의 9, 3, 5 번째 요소에 "Some Value", "Another Value", "Any Value"를 각각 삽입 
            myInd[9] = "Some Value";
            myInd[3] = "Another Value";
            myInd[5] = "Any Value";
            
            // 객체 myInd의 인덱서를 사용하여 myInd 내부의 string 자료형 배열 myData의 요소 중 "empty"를 값으로 갖는 요소들에 "no value"를 삽입
            myInd["empty"] = "no value";

            Console.WriteLine("\nIndexer Output\n");

            // int 자료형 변수 i를 선언하고, 값을 0으로 초기화
            // i와 구동 메서드에서 선언한 변수 size를 이용하여 for문 구동
            // 객체 myInd의 인덱서를 사용하여 myInd 내부의 string 자료형 배열 myData의 i 번째 요소를 출력
            for (int i = 0; i < size; i++) { Console.WriteLine("myInd[{0}]: {1}", i, myInd[i]); }


            // 객체 myInd의 인덱서를 사용하여 myInd 내부의 string 자료형 배열 myData의 모든 요소 중 값을 "no value"로 갖는 요소의 갯수를 출력
            Console.WriteLine("\nNumber of \"no value\" entries: {0}", myInd["no value"]);
        }
    }
} // namespace 종료


//괄호를 수정하여 아래의 결과를 출력

//myInd[0]: no value
//myInd[1]: no value
//myInd[2]: no value
//myInd[3]: Another Value
//myInd[4]: no value
//myInd[5]: Any Value
//myInd[6]: no value
//myInd[7]: no value
//myInd[8]: no value
//myInd[9]: Some Value

//Number of "no value" entries: 7