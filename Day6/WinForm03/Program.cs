using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 필터
namespace WinForm03
{
    // IMessageFilter 클래스를 상속받는 필터 클래스 OnjMessageFilter 선언
    class OnjMessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            if(m.Msg == 0x201)
            {
                Console.WriteLine("마우스 클릭 필터링 됨");
                return true;
            }
            return false;
        }
    }

    // Form 클래스를 상속받는 기동 클래스 Program 선언
    class Program : Form
    {
        static void Main(string[] args)
        {
            Application.AddMessageFilter(new OnjMessageFilter());
            Program p = new Program();
            p.Click += new EventHandler(p.Form_Click);
            Application.Run(p);
        }

        void Form_Click(object sender, EventArgs e)
        {
            Console.WriteLine("마우스 클릭 이벤트 발생");
            Application.Exit();
        }
    }
}
