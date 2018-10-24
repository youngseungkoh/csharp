using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Dog
    {
        public string Name
        {
            get; set;
        }
        public virtual void jitda()
        {
            Console.WriteLine(Name + "가 짖다.");
        }
    }

    public class Pudle : Dog
    {
        public override void jitda()
        {
            Console.WriteLine(Name + " 푸들푸들~");
        }

        public void Work()
        {
            Console.WriteLine(Name + "가 일한다.");
        }
    }

    public class Jindo : Dog
    {
        public override void jitda()
        {
            //base.jitda();
            Console.WriteLine(Name + " 진도진도~");
        }

        public void Run
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
