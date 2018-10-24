using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllImportAttribute
{
    class Program
    {
        [DllImport("User32.Dll")]
        public static extern int MessageBox()
        static void Main(string[] args)
        {
        }
    }
}
