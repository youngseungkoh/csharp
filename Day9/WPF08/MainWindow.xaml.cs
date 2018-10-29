using System;
using System.Reflection;
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

namespace WPF08
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (PropertyInfo prop in typeof(Brushes).GetProperties())
                lstbox.Items.Add(prop.Name);
        }

        void ButtonOnClick(object sender,RoutedEventArgs args)
        {
            Button b = sender as Button;
            MessageBox.Show(b.Content.ToString());
        }

        void ListBoxOnSelection(object sender, SelectionChangedEventArgs args)
        {
            ListBox listBox = sender as ListBox;
            string items = listBox.SelectedItem as string;
            PropertyInfo pInfo = typeof(Brushes).GetProperty(items);
            elips.Fill = (Brush)pInfo.GetValue(null, null);
        }
    }
}
