using System;
using System.Windows.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterTest
{
    class YesNoToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object param, System.Globalization.CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "Yes": return true;
                case "yes": return true;
                case "No": return false;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object param, System.Globalization.CultureInfo culture)
        {
            if(value is bool)
            {
                if ((bool)value == true) return "Yes";
                else return "No";
            }
            return "No";
        }
    }
}
