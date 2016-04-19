using ProxySwitcher.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ProxySwitcher.Resources
{
    public class MenuItemToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Boolean isActive = (Boolean)value;

            if (isActive)
            {
                return System.Windows.Visibility.Visible;
            }

            else
            {
                return System.Windows.Visibility.Hidden;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
