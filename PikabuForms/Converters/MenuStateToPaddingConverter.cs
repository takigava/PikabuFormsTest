using System;
using Xamarin.Forms;

namespace PikabuForms
{
	public class MenuStateToPaddingConverter : IValueConverter
	{
		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if ((bool)value) {
				return new Thickness(0,0,0,0);
			} else {
				return new Thickness(10,0,0,0);
			}
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

		#endregion

	}
}

