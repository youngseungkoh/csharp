using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDelegate02
{
    public delegate void ShowName();

    public class Onj
    {
        private string name;

        public Onj(string name) { this.name = name; }
        public void DisplayToConsole() { Console.WriteLine(this.name); }
        public void DisplayToWindow() { MessageBox.Show(this.name); }
    }

    public class Program
    {
        public static void Main()
        {
            Onj onj1 = new Onj("Education");
            ShowName act1 = onj1.DisplayToWindow;
            act1();

            Onj onj2 = new Onj("OJC");
            Action act2 = onj2.DisplayToWindow;
            act2();

            Onj onj3 = new Onj("OJC EDU");
            Action act3 = delegate ()
            {
                onj3.DisplayToWindow();
            };
            act3();

            Onj onj4 = new Onj("OJC");
            Action act5 = () => onj4.DisplayToWindow();
            act5();
        }
    }
}
