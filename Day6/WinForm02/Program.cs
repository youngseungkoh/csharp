using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm02
{
    // Form 클래스를 상속하는 클래스 Program 선언
    class Program : Form
    {
        static void Main(string[] args)
        {
            Program form = new Program();

            form.Click += new EventHandler((sender, eventArgs) => { Console.WriteLine("폼 클릭 이벤트"); Application.Exit(); });
            Console.WriteLine("윈도우 시작");
            Application.Run(form);
            Console.WriteLine("윈도우 종료");
        }
    }
}
