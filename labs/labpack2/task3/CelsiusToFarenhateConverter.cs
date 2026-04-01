using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace task3;

public class CelsiusToFarenhateConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => (value is float tempareture) ? (Math.Round((1.8 / tempareture + 32) * 1000) / 1000).ToString() : null;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        float result = 0;
        if (float.TryParse(value.ToString(), out float tempareture))
            result = (float)Math.Round(((tempareture - 32) * 5 / 9) * 1000) / 1000;

        return result;
    }
}
