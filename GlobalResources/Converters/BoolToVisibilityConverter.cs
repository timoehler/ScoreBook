using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace GlobalResources.Converters
{
	public class BoolToVisibilityConverter : IValueConverter
	{
		public Visibility OnTrue = Visibility.Visible;
		public Visibility OnFalse = Visibility.Collapsed;

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return (bool)value ? OnTrue : OnFalse;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotSupportedException();
		}
	}
}
