using System;
using Xamarin.Forms;
using PikabuForms.Droid;

[assembly:ExportRendererAttribute(typeof(Label), typeof(LabelRenderer))]

namespace PikabuForms.Droid
{
	public class LabelRenderer:Xamarin.Forms.Platform.Android.LabelRenderer
	{
		protected override void OnElementChanged (Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged (e);
			Control.SetMaxLines (1000);
			Control.SetPadding (5,0, 5, 0);
		}
	}
}

