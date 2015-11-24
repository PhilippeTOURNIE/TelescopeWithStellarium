using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ServerTelescope.Converters
{
    public class ValidationConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {


            //-----------------------------------------
            // Cas normal
            //-----------------------------------------
            if ((bool)value)
                return new BitmapImage(new Uri("/ServerTelescope;component/Images/GreenLight.png", UriKind.RelativeOrAbsolute));
            else
                return new BitmapImage(new Uri("/ServerTelescope;component/Images/RedLight.png", UriKind.RelativeOrAbsolute));

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Mode OneWay
            return null;

        }
    }
}
