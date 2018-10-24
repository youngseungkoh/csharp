using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event05
{
    // 값을 저장하는 역할을 하는 클래스 만들기 (설계도)
    class PublisherArgs : System.EventArgs
    {
        // 자료를 저장할 메모리 공간 만들기
        public string myEventData;

        // 클래스가 호출될 때 자료를 저장하도록 생성자 만들기
        public PublisherArgs(string myEventData)
        {
            this.myEventData = myEventData;
        }
    }

    // 이벤트를 발생시키고, 그 발생을 알리는 클래스 만들기
    class Publisher
    {
        // 런타임에 이벤트를 처리할 수 있도록 델리게이트 자료형 만들기(Subscriber 클래스의 react 메서드와 반환 타입 및 파라메터가 같아야 한다)
        public delegate void MyEventHandler(object sender, PublisherArgs e);

        // MyEventHandler 자료형 이벤트인 MyEvent 자료형 만들기
        public event MyEventHandler MyEvent;

        // 이벤트를 발생시키는 메서드 만들기
        public void tell()
        {
            if (MyEvent != null)
            {
                PublisherArgs args = new PublisherArgs("데이터");
                MyEvent(this, args);
            }
        }
    }

    // 이벤트가 생기길 기다렸다가 움직이는 클래스 만들기
    class Subscriber
    {
        // 델리게이트가 부를 메서드 만들기
        static void react(object sender, PublisherArgs e) {
            Console.WriteLine("MyEvent라는 이벤트 발생");
            Console.WriteLine("이벤트 매개변수 : " + e.myEventData);
        }

        // 구동 클래스 만들기
        static void Main(string[] args)
        {
            // Publisher 클래스를 객체화
            Publisher p = new Publisher();

            // 델리게이트가 react 를 호출한 결과를 p.MyEvent에 부여
            p.MyEvent += new Publisher.MyEventHandler(react);

            // 이벤트를 발생
            p.tell();
        }
    }
}
