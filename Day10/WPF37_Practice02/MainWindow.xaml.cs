using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF37_Practice02
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(VMMainWindow.LastName + ":" + VMMainWindow.FirstName);
        }

        public class User : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private string _firstname;
                public string Firstname
            {
                get {
                    return _firstname;
                }
                set {
                    _firstname = value;
                    RaisePropertyChange("FirstName");
                }
            }

            private string _lastname;

            public string LastName
            {
                get
                {
                    return _lastname;
                }
                set
                {
                    _lastname = value;
                    RaisePropertyChange("LastName");
                }
            }
            public void RaisePropertyChange(string propertyname)
            {
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                }
            }
        }
    }
}
