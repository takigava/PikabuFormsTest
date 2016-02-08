using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace PikabuForms
{
	public partial class App : Application
	{
		//public static DataTemplate AndroidFeedItemTemplate { get; set; }
		public App ()
		{
			InitializeComponent ();
			MainPage = new Main();
			//var temp = App.Current.Resources;;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

