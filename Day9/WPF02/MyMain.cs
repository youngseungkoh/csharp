using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF02
{
    // Appliction 클래스를 상속받는 MyMain 클래스 선언
    class MyMain : Application
    {
        // 어트리뷰트 Single Thread Apartment Thread
        [STAThread]

        //
        public static void Main()
        {
            MyMain app = new MyMain();
            // 메인윈도우가 닫히면 모든 app 프로그램을 닫음
            //app.ShutdownMode = ShutdownMode.OnMainWindowClose;

            // 마지막 윈도우가 닫히면 모든 app 프로그램을 닫음
            app.ShutdownMode = ShutdownMode.OnLastWindowClose;


            // 객체 app 실행
            app.Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Window mainWindow = new Window();
            mainWindow.Title = "WPF Sample(Main)";

            // 메인윈도우에서 MouseDown하면 WinMouseDown 메서드 호출
            mainWindow.MouseDown += WinMouseDown;

            // 메인윈도우를 띄움
            mainWindow.Show();

            // 서브윈도우를 반복해서 띄움
            for(int i = 0; i < 2; i++)
            {
                Window win = new Window();
                win.Title = "Extra Window No." + (i + 1);
                win.Show();
                win.Owner = mainWindow;
            }
        }

        void WinMouseDown(object sender, MouseEventArgs e)
        {
            Window win = new Window();
            win.Title = "Modal DialogBox";
            win.Width = 400;
            win.Height = 200;

            Button b = new Button();
            b.Content = "Click Me!";
            b.Click += Button_Click;

            // 인스턴스화 한 버튼 컨트롤 b를 Content 속성에 넣음
            win.Content = b;
            win.ShowDialog();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button Clicked!", sender.ToString());
        }
    }
}
