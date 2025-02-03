using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using Supermarket.ViewModels;
using System.Globalization;

namespace Supermarket.Converters
{
    public class TextboxToMarketUserVM : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] != null || values[1] != null)
            {
                return new Tuple<string, string>(values[0].ToString(), values[1].ToString());
            }
            else
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
