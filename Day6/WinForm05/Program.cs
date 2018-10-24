using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 윈폼 클래스 - 속성
namespace WinForm05
{
    class Program : Form
    {
        Random r;

        public Program()
        {
            r = new Random();    
            this.MouseWheel += new MouseEventHandler(OnjMouseWheel);
            this.MouseDown += new MouseEventHandler(OnjMouseDown);
        }

        void OnjMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.MaximizeBox = true;
                this.MinimizeBox = true;
                Color oldcolor = this.BackColor;
                this.BackColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
            }

            if (e.Button == MouseButtons.Right)
            {
                this.MaximizeBox = false;
                this.MinimizeBox = false;
            }
        }

        void OnjMouseWheel(object sender, MouseEventArgs e)
        {
            this.Opacity = this.Opacity + (e.Delta > 0 ? 0.1 : -0.1);
            Console.WriteLine("Opacity : {0}", this.Opacity);
        }

        static void Main(string[] args)
        {
            Application.Run(new Program());
        }
    }
}
