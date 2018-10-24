using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer03
{
    // 인덱서를 사용하는 클래스
    class DayCollection
    {
        // string 자료형 배열 days를 선언하고 초기화
        string[] days = { "일", "월", "화", "수", "목", "금", "토" };

        // Indexer가 전달한 day를 파라메터로 받는 int 자료형 private 메서드 GetDay를 선언
        private int GetDay(string day){
            // 배열 days의 길이를 사용하여 for문 구동
            for (int j = 0; j < days.Length; j++){
                // days 배열 내의 j번째 요소가 전달받은 day와 같을 경우 j를 리턴
                if (days[j] == day) { return j; }
            }
            // days 배열 내의 j번째 요소가 전달받은 day와 다를 경우 999를 리턴
            return 999;
        }

        // 문자열 자료형 day를 파라메터로 받고, GetDay 메서드를 리턴하는 인덱서를 선언
        public int this[string day] {
            get { return (GetDay(day)); }
        }

    }

    // 기동 클래스
    class Program
    {
        static void Main(string[] args)
        {
            // Indexer를 사용하는 클래스인 DayCollection을 인스턴스화
            DayCollection week = new DayCollection();

            // 객체화된 클래스 week 내부의 indexer를 사용 -> 이 indexer는 GeDay 메서드를 리턴함
            //Console.WriteLine(week["일"]); // 0을 리턴
            //Console.WriteLine(week["Made-up Day"]); // 999를 리턴 (days 배열 내에 "Made-up Day"라는 문자열이 없기 때문에)
            Console.WriteLine("토요일이 가리키는 j값은 " + week["토"] + " 입니다."); 
        }
    }
}
