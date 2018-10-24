using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm01
{
    // Form 클래스를 상속하는 Program 클래스 선언
    class Program : Form
    {
        static void Main(string[] args)
        {
            Program form = new Program();

            // Click 이벤트는 Form 클래스에 있다
            form.Click += new EventHandler(form.Form_Click);

            Console.WriteLine("윈도우 시작");
            Application.Run(form);
            Console.WriteLine("윈도우 종료");
        }

        void Form_Click(object sender, EventArgs e)
        {
            Console.WriteLine("폼 클릭 이벤트");
            Application.Exit();
        }
    }
}
