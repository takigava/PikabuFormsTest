using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PikabuForms
{
	public partial class Main : CustomMasterDetail
	{
		public Main ()
		{
			InitializeComponent ();
			Detail = new FeedPage (FeedType.New);
			Title = "Горячее";
		}
	}
}

