using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Supermarket.Converters
{
    public class EditStockConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null || values[1] != null || values[2] != null || values[3] != null || values[4] != null)
            {
                if (int.TryParse(values[0].ToString(), out int stockId) &&
                    int.TryParse(values[1].ToString(), out int stockProductId) &&
                    int.TryParse(values[2].ToString(), out int stockQuantity) &&
                    DateTime.TryParse(values[3].ToString(), out DateTime stockSupplyDate) &&
                    DateTime.TryParse(values[4].ToString(), out DateTime stockExpirationDate) &&
                    decimal.TryParse(values[5].ToString(), out decimal stockSellingPrice))
                {
                    return Tuple.Create(stockId, stockProductId, stockQuantity, stockSupplyDate, stockExpirationDate, stockSellingPrice);
                }
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
