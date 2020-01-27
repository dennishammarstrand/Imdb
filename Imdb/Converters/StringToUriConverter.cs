using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Imdb.Converters
{
    public class StringToUriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var validString = value as string;

            if (!string.IsNullOrEmpty(validString) && validString != "N/A")
            {
                return new Uri(validString);
            }
            if (validString == "N/A")
            {
                return new Uri("http://noodleblvd.com/wp-content/uploads/2016/10/No-Image-Available.jpg");
            }

            throw new ArgumentException("String is null or empty");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
