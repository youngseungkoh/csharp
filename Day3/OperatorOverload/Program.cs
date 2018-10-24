using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverload
{
    public class AddClass
    {
        public int val;
        public static AddClass operator + (AddClass op1, AddClass op2)
        {
            AddClass obj = new AddClass();
            obj.val = op1.val + op2.val;
            return obj;
        }
    }

    class Test
    {
        static void Main(string[] args)
        {
            AddClass op1 = new AddClass();
            op1.val = 1;

            AddClass op2 = new AddClass();
            op2.val = 2;

            AddClass op3 = op1 + op2;
            Console.WriteLine("op1 + op2 = {0}", op3.val);
        }
    }
}
