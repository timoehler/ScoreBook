using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace GlobalResources.Converters
{
	public class StringEmptyToBoolConverter : IValueConverter
	{
		public bool OnEmpty = false;
		public bool OnNotEmpty = true;

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return string.IsNullOrEmpty((string)value) ? OnEmpty : OnNotEmpty;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotSupportedException();
		}
	}
}
