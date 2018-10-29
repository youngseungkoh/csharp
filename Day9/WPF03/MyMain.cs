using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF03
{
    class MyMain
    {
        [STAThread]
        public static void Main()
        {
            Window mainWindow = new Window();
            mainWindow.Title = "WPF Sample(Main)";
            mainWindow.MouseDown += WinMouseDown;
            //mainWindow.Show();

            for (int i = 0; i < 2; i++)
            {
                Window win = new Window();
                win.Title = "Extra Window No." + (i + 1);
                // win.ShowInTaskbar = false;
                win.Show();
            }

            //MyMain app = new MyMain();
            //app.ShutdownMode = ShutdownMode.OnMainWindowClose;
            // 위 대신 쓰는 부분
            Application app = new Application();
            app.Run(mainWindow);
        }

        //protected override void OnStartup(StartupEventArgs e)
        //{
            //base.OnStartup(e);
        //}

        // 얘를 static으로 만듦
        static void WinMouseDown(object sender, MouseEventArgs e)
        {
            Window win = new Window();
            win.Title = "Modal DialogBox";
            win.Width = 400;
            win.Height = 200;

            Button b = new Button();
            b.Content = "Click Me!";
            b.Click += Button_Click;
            
            win.Content = b;
            win.ShowDialog();
        }

        // 얘도 static으로 만듦
        static void Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button Clicked!", sender.ToString());
        }
    }
}
