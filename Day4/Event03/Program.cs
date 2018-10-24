using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event03
{
    delegate void MyDelegate(int i);
    class Publisher
    {
        public event MyDelegate ClapEvent;
        public void Clap(int num)
        {
            if (num % 2 == 0)
            {
                ClapEvent(num);
            }
        }


        class Subscriber
        {
            static void Caller(int num)
            {
                Console.WriteLine("{0} : 짝", num);
            }

            public static void Main()
            {
                Publisher p = new Publisher();
                p.ClapEvent += new MyDelegate(Caller);

                int[] iArr = Array.ConvertAll((Console.ReadLine()).Split(','), i => int.Parse(i));

                foreach (int i in iArr)
                {
                    p.Clap(i);
                }
            }
        }
    }
}
