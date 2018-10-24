using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm07
{
    class MessageBoxTest
    {
        static void Main(string[] args)
        {
            MessageBox.Show("메세지");

            MessageBox.Show("메세지", "타이틀");

            DialogResult result1 = MessageBox.Show("메세지", "타이틀(두 버튼 메세지박스)", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes) Console.WriteLine("YES 클릭");
            else Console.WriteLine("NO 클릭");
            Console.WriteLine("1. --------------------");

            DialogResult result2 = MessageBox.Show("메세지", "타이틀(Question 메시지박스, YesNoCancel)", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result2 == DialogResult.Yes) Console.WriteLine("YES 클릭");
            else if (result2 == DialogResult.No) Console.WriteLine("NO 클릭");
            else if (result2 == DialogResult.Cancel) Console.WriteLine("CANCEL 클릭");
            Console.WriteLine("2. -------------------");

            DialogResult result3 = MessageBox.Show("메세지", "타이틀(Question, YesNoCancel, Default버튼)", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            MessageBox.Show("메세지", "타이틀(메시지 우측 정렬, Error 아이콘)", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true);

            MessageBox.Show("메세지", "타이틀(exclamation icon)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
