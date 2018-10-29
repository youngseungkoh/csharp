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

namespace WPF22_Button01
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        Run runButton1;
        Run runButton2;

        public MainWindow()
        {
            InitializeComponent();

            Title = "ButtonTest1";

            Button btn = new Button();
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.MouseEnter += ButtonOnMouseEnter;
            btn.MouseEnter += ButtonOnMouseLeave;
            Content = btn;

            TextBlock txtblk = new TextBlock();
            txtblk.FontSize = 24;
            txtblk.TextAlignment = TextAlignment.Center;
            btn.Content = txtblk;

            txtblk.Inlines.Add(new Italic(new Run("Click")));
            txtblk.Inlines.Add(" the ");
            txtblk.Inlines.Add(runButton1 = new Run("button"));
            txtblk.Inlines.Add(new LineBreak());
            txtblk.Inlines.Add("to launch the ");
            txtblk.Inlines.Add(new Bold(runButton2 = new Run("rocket")));

        }

        void ButtonOnMouseLeave(object sender, MouseEventArgs e)
        {
            runButton1.Foreground = SystemColors.ControlTextBrush;
            runButton2.Foreground = SystemColors.ControlTextBrush;
        }

        void ButtonOnMouseEnter(object sender, MouseEventArgs e)
        {
            runButton1.Foreground = Brushes.Red;
            runButton2.Foreground = Brushes.Blue;
        }
    }
}
