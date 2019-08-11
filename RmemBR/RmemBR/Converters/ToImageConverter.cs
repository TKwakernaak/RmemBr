using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace RmemBR.Core.Converters
{
  public class ToImageConverter : IValueConverter
  {
    public string Assembly { get; set; }
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var source = value as string;
      if (string.IsNullOrEmpty(source))
        return null;

      var imagePath = $"{Assembly}.{source}";

      return ImageSource.FromResource(imagePath);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }


  }
}
