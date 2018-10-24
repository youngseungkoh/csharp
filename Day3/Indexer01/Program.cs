using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer01
{
    class Animation
    {
        // 변수들을 선언
        private int total;                  // 해당 배급사가 배급하는 영화의 갯수
        private string[] title;             // 영화 제목을 저장하는 배열
        private string distributor;         // 배급사명
        private string date;                // 영화 제작 날짜
        private int price;                  // 영화의 가격

        // 생성자를 선언 (생성자와 클래스는 이름이 같아야 함)
        public Animation(int total, string distributor, string date, int price)
        {
            this.total = total;
            this.title = new string[total];
            this.distributor = distributor;
            this.date = date;
            this.price = price;
        }

        // number와 title 배열을 파라메터로 받아 title 배열의 number 번째 자리에 문자열 title을 삽입하는 메서드
        public void setTitle(int number, string title) { this.title[number] = title; }
        
        // number를 파라메터로 받아 title 배열의 number 번째 문자열을 리턴하는 메서드
        public string getTitle(int number) { return title[number]; }

        // 생성된 Animation 객체의 distributor 프로퍼티를 리턴하는 메서드
        public string getDistributor() { return distributor; }

        // 생성된 Animation 객체의 price 프로퍼티를 리턴하는 메서드
        public int getPrice() { return price; }

        // 생성된 Animation 객체의 total 프로퍼티를 리턴하는 메서드
        public int getTotal() { return total; }
    }

    class AniTest
    {
        static void Main()
        {
            // Animation 클래스를 인스턴스화
            Animation ani = new Animation(5, "한국애니메이션", "10-27-2018", 35000);

            // 인스턴스화 된 ani 객체 내부의 setTitle 메서드를 사용해 title 배열의 number 번째 자리에 영화 제목을 삽입
            ani.setTitle(0, "인어공주");
            ani.setTitle(1, "신데렐라");
            ani.setTitle(2, "백설공주");
            ani.setTitle(3, "바보온달");
            ani.setTitle(4, "라이온킹");

            // 인스턴스화 된 ani 객체 내부의 getDistributor 메서드를 사용해 배급사명을 출력
            Console.WriteLine("배급사 : {0}", ani.getDistributor());

            // 인스턴스화 된 ani 객체 내부의 getPrice 메서드를 사용해 영화의 가격을 출력
            Console.WriteLine("가격   : {0}", ani.getPrice());

            Console.WriteLine("-----------------------------------------------------");

            // 인스턴스화 된 ani 객체 내부의 getTotal 메서드를 사용해 for 문을 구동
            for(int i = 0; i < ani.getTotal(); i++){
                // 인스턴스화 된 ani 객체 내부의 getTitle 메서드를 사용해 배급번호와 영화 제목을 출력
                Console.WriteLine("배급번호 {0} : {1}", i, ani.getTitle(i));
            }
        }
    }
}
