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

namespace WPF18_TunnelingEvent01
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        string mouseActivity = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_PreviewMouseDown(object sender, RoutedEventArgs e)
        {
            mouseActivity = "PreviewMouseDown Button \n";
            MessageBox.Show(mouseActivity);
        }

        private void StackPanel_PreviewMouseDown(object sender, RoutedEventArgs e)
        {
            mouseActivity = "PreviewMouseDown StackPanel \n";
            MessageBox.Show(mouseActivity);
        }
        private void Window_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            mouseActivity = "PreviewMouseDown Window \n";
            MessageBox.Show(mouseActivity);
        }
    }
}
