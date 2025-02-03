using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Supermarket.Converters
{
    public class EditProductConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null && values[4] != null)
            {
                if (int.TryParse(values[0].ToString(), out int productId) &&
                    int.TryParse(values[1].ToString(), out int productProducerId) &&
                    int.TryParse(values[2].ToString(), out int productCategoryId))
                {
                    return Tuple.Create(productId, productProducerId, productCategoryId, values[3].ToString(), values[4].ToString());
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
