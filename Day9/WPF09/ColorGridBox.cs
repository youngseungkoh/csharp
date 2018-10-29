using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF09
{
    class Test
    {
        static void Main() { }
    }

    public class ColorGridBox : ListBox
    {
        string[] strColors =
        {
            "Black","Brown","DarkGreen","MidnightBlue",
            //"Black","D","D","D",
            //"Black","D","D","D",
            //"Black","D","D","D",
            //"Black","D","D","D",
            //"Black","D","D","D",
            //"Black","D","D","D",
            //"Black","D","D","D",
            //"Black","D","D","D",
            //"Black","D","D","D"
        };
        
        public ColorGridBox()
        {
            FrameworkElementFactory factoryUnigrid = new FrameworkElementFactory(typeof(UniformGrid));
            factoryUnigrid.SetValue(UniformGrid.ColumnsProperty, 8);

            ItemsPanel = new ItemsPanelTemplate(factoryUnigrid);

            foreach(string strColor in strColors)
            {
                Rectangle rect = new Rectangle();

                rect.Width = 12;
                rect.Height = 12;
                rect.Margin = new Thickness(4);

                rect.Fill = (Brush)
                    typeof(Brushes).GetProperty(strColor).GetValue(null, null);
                Items.Add(rect);

                ToolTip tip = new ToolTip();
                tip.Content = strColor;
                rect.ToolTip = tip;
            }

            SelectedValuePath = "Fill";
        }
    }
}
