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

namespace MenuApplication
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // 아래 코드는 Xaml을 안 쓸거라 필요없음
            // InitializeComponent();

            Title = "Peruse the Menu";

            DockPanel dock = new DockPanel();
            Content = dock;

            Menu menu = new Menu();
            dock.Children.Add(menu);
            DockPanel.SetDock(menu, Dock.Top);

            TextBlock text = new TextBlock();
            text.Text = Title;
            text.FontSize = 32;
            text.TextAlignment = TextAlignment.Center;
            dock.Children.Add(text);

            MenuItem itemFile = new MenuItem();
            itemFile.Header = "_File";
            menu.Items.Add(itemFile);

            MenuItem itemNew = new MenuItem();
            itemNew.Header = "_New";
            itemNew.Click += UnimplementedOnClick;
            itemFile.Items.Add(itemNew);

            MenuItem itemOpen = new MenuItem();
            itemOpen.Header = "_Open";
            itemOpen.Click += UnimplementedOnClick;
            itemFile.Items.Add(itemOpen);

            MenuItem itemSave = new MenuItem();
            itemSave.Header = "_Save";
            itemSave.Click += UnimplementedOnClick;
            itemFile.Items.Add(itemSave);

            itemFile.Items.Add(new Separator());

            MenuItem itemExit = new MenuItem();
            itemExit.Header = "E_xit";
            itemExit.Click += ExitOnClick;
            itemFile.Items.Add(itemExit);






            MenuItem itemWindow = new MenuItem();
            itemWindow.Header = "_Window";
            menu.Items.Add(itemWindow);

            MenuItem itemTaskbar = new MenuItem();
            itemTaskbar.Header = "_Show in Taskbar";
            itemTaskbar.IsCheckable = true;
            itemTaskbar.IsChecked = ShowInTaskbar;
            itemTaskbar.Click += TaskbarOnClick;
            itemWindow.Items.Add(itemTaskbar);

            MenuItem itemSize = new MenuItem();
            itemSize.Header = "Size to _Content";
            itemSize.IsCheckable = true;
            itemSize.IsChecked = SizeToContent == SizeToContent.WidthAndHeight;
            itemSize.Checked += SizeOnCheck;
            itemSize.Unchecked += SizeOnCheck;
            itemWindow.Items.Add(itemSize);
        }

        private void SizeOnCheck(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            SizeToContent = item.IsChecked ? SizeToContent.WidthAndHeight : SizeToContent.Manual;
        }

        private void TaskbarOnClick(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            ShowInTaskbar = item.IsChecked;
        }

        // Exit 버튼을 누르면 이 메서드를 실행
        void ExitOnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // 기능이 없는 버튼을 누르면 이 메서드를 실행
        void UnimplementedOnClick(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            string strItem = item.Header.ToString().Replace("_", "");
            MessageBox.Show("The " + strItem + " option has not yet been implemented", Title);
        }
    }
}
