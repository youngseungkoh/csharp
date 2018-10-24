using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Emp
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        //public void SetName(string name)
        //{
        //    this.name = name;
        //}

        //public string GetName(string name)
        //{
        //    return this.name;
        //}
    }

    class EmpTest
    {
        static void Main(string[] args)
        {
            Emp e = new Emp();
            e.SetName = "홍길동";
            Console.WriteLine(e.GetName);
        }
    }
}
