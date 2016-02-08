using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using PikabuForms;
using PikabuForms.Droid;
using Android.Support.V7.App;
using Android.App;
using Android.Support.V4.Widget;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(CustomMasterDetail), typeof(CustomMasterDetailRenderer))]

namespace PikabuForms.Droid
{
	public class CustomMasterDetailRenderer : MasterDetailRenderer
	{
		private CustomActionBarDrawerToggle actionBarDrawerToggle;

		protected Android.App.ActionBar ActionBar
		{
			get { return ((Activity)Forms.Context).ActionBar; }
		}

		protected MasterDetailPage MasterDetailPage
		{
			get { return (MasterDetailPage)this.Element; }
		}

		public override void SetDrawerListener(IDrawerListener listener)
		{
			base.SetDrawerListener(this.actionBarDrawerToggle);
		}

		protected override void OnElementChanged(VisualElement oldElement, VisualElement newElement)
		{
			base.OnElementChanged(oldElement, newElement);

			if (oldElement != null)
			{
				oldElement.PropertyChanged -= this.HandleMasterDetailPagePropertyChanged;
				oldElement.PropertyChanging -= this.HandleMasterDetailPagePropertyChanging;
			}

			if (newElement != null)
			{
				newElement.PropertyChanged += this.HandleMasterDetailPagePropertyChanged;
				newElement.PropertyChanging += this.HandleMasterDetailPagePropertyChanging;
			}

			if (oldElement == null && newElement != null)
			{
				this.SetFitsSystemWindows(true);

				var activity = (Activity)this.Context;

				this.actionBarDrawerToggle = new CustomActionBarDrawerToggle(this, activity, this) { DrawerIndicatorEnabled = true };

				this.ActionBar.SetDisplayHomeAsUpEnabled(true);
				this.ActionBar.SetHomeButtonEnabled(true);
				this.ActionBar.SetTitle (Resource.String.navigation_drawer_open);
				this.actionBarDrawerToggle.SyncState();
				this.ActionBar.Elevation = 8;
				this.BindNavigationEventHandlers();
			}
		}

		protected void UpdateHomeAsUpIndicator(bool navigable)
		{
			if (navigable && this.actionBarDrawerToggle.DrawerIndicatorEnabled)
			{
				this.ActionBar.SetDisplayHomeAsUpEnabled(false);
				this.actionBarDrawerToggle.DrawerIndicatorEnabled = false;
				this.ActionBar.SetDisplayHomeAsUpEnabled(true);
			}
			else if (!navigable && !this.actionBarDrawerToggle.DrawerIndicatorEnabled)
			{
				this.actionBarDrawerToggle.DrawerIndicatorEnabled = true;
			}
		}

		private void BindNavigationEventHandlers()
		{
			var navigation = this.MasterDetailPage.Detail as NavigationPage;

			if (navigation != null)
			{
				navigation.Popped += this.HandleNavigationPopped;
				navigation.PoppedToRoot += this.HandleNavigationPoppedToRoot;
				navigation.Pushed += this.HandleNavigationPushed;
			}
		}

		private void UnbindNavigationEventHandlers()
		{
			var navigation = this.MasterDetailPage.Detail as NavigationPage;

			if (navigation != null)
			{
				navigation.Popped -= this.HandleNavigationPopped;
				navigation.PoppedToRoot -= this.HandleNavigationPoppedToRoot;
				navigation.Pushed -= this.HandleNavigationPushed;
			}
		}

		private void HandleMasterDetailPagePropertyChanging(object sender, Xamarin.Forms.PropertyChangingEventArgs e)
		{
			if (e.PropertyName == "Detail")
			{
				this.UnbindNavigationEventHandlers();
			}
		}

		private void HandleMasterDetailPagePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Detail")
			{
				this.BindNavigationEventHandlers();
			}
		}

		private void HandleNavigationPopped(object sender, NavigationEventArgs e)
		{
			var canNavigateBack = ((NavigationPage)sender).Navigation.NavigationStack.Count > 1;
			this.UpdateHomeAsUpIndicator(canNavigateBack);
		}

		private void HandleNavigationPoppedToRoot(object sender, NavigationEventArgs e)
		{
			this.UpdateHomeAsUpIndicator(false);
		}

		private void HandleNavigationPushed(object sender, NavigationEventArgs e)
		{
			var canNavigateBack = ((NavigationPage)sender).Navigation.NavigationStack.Count > 1;
			this.UpdateHomeAsUpIndicator(canNavigateBack);
		}

		private class CustomActionBarDrawerToggle : ActionBarDrawerToggle
		{
			private readonly AppCompatDelegate appCompatDelegate;

			private readonly CustomMasterDetailRenderer owner;

			public CustomActionBarDrawerToggle(CustomMasterDetailRenderer owner, Activity activity, DrawerLayout drawerLayout)
				: base(activity, drawerLayout, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close)
			{
				//this.appCompatDelegate = activity.GetAppCompatDelegate();
				this.owner = owner;
			}
			public override void OnDrawerClosed (Android.Views.View drawerView)
			{
				base.OnDrawerClosed(drawerView);
				//this.appCompatDelegate.InvalidateOptionsMenu();
				this.owner.OnDrawerClosed(drawerView);
			}

			public override void OnDrawerOpened(Android.Views.View drawerView)
			{
				base.OnDrawerOpened(drawerView);
				//this.appCompatDelegate.InvalidateOptionsMenu();
				this.owner.OnDrawerOpened(drawerView);
			}

			public override void OnDrawerSlide(Android.Views.View drawerView, float slideOffset)
			{
				base.OnDrawerSlide(drawerView, slideOffset);
				this.owner.OnDrawerSlide(drawerView, slideOffset);
			}

			public override void OnDrawerStateChanged(int newState)
			{
				base.OnDrawerStateChanged(newState);
				this.owner.OnDrawerStateChanged(newState);
			}
		}
	}
}

