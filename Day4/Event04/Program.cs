using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event04
{
    class Publisher
    {   
        // p156 - p157
        public event EventHandler MyEvent; // 자료형이 EventHandler인 델리게이트 MyEvent
        public void Clap(int num)
        {
            
        }

        class Subscriber
        {
            static void Main(string[] args)
            {
                Publisher p = new EventHandler(메서드명);

                p.MyEvent += new EventHandler(메서드명); // 델리게이트 MyEvent에 메서드를 추가 (즉, 델리게이트 체인)





            }
        }
    }
}
