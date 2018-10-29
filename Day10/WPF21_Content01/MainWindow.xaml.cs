using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF21_Content01
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        StringBuilder s;

        public MainWindow()
        {
            InitializeComponent();

            Title = "사용자 입력을 Window의 Content 속성에 매핑하기";
            s = new StringBuilder("");
            Content = s;
        }

        protected override void OnTextInput(TextCompositionEventArgs args)
        {
            string str = Content.ToString();

            if (args.Text == "\b")
            {
                if (str.Length > 0) s.Remove(s.Length - 1, 1);
            }
            else
            {
                s.Append(args.Text);
            }

            Content = null;
            Content = s;
        }
    }
}
