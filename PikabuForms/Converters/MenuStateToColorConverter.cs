using System;
using Xamarin.Forms;

namespace PikabuForms
{
	public class MenuStateToColorConverter: IValueConverter
	{
		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if ((bool)value) {
				return Color.FromHex("#2E2F31");
			} else {
				return Color.Transparent;
			}
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

