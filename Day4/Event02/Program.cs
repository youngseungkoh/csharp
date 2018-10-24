using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event02
{
    class EventPublisher
    {
        // public delegate void MyEventHandler();
        public event EventHandler MyEvent;
        public void Do()
        {
            if(MyEvent != null)
            {
                MyEvent(null, null);
            }
        }
    }

    class Subscriber
    {
        static void Main(string[] args)
        {
            EventPublisher p = new EventPublisher();
            p.MyEvent += new EventHandler(doAction);
            p.Do();
        }

        static void doAction(object sender, EventArgs e)
        {
            Console.WriteLine("MyEvent 라는 이벤트가 여전히 발생");
        }
    }
}
