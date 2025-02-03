using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Supermarket.Converters
{
    public class MarketUserTypeToBackground : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int userType)
            {
                if (userType == 1)
                {
                    return new BitmapImage(new Uri("/Images/adminBackground.jpg"));
                }
                else if (userType == 2)
                {
                    return new BitmapImage(new Uri("/Images/cashierBackground.jpg"));
                }
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}