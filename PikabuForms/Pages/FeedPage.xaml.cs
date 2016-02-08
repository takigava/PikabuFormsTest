using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PikabuForms
{
	public partial class FeedPage : ContentPage
	{
		public FeedPage (FeedType feedType)
		{
			InitializeComponent ();

			var itemsSource = new List<PostModel> ();
			var item = new PostModel ();
			item.AuthorName = "@Semen";
			item.Rating = 125;
			item.PostTime ="2 часа назад";
			item.Title = "Как-то так приложение some test";
			item.Description = "Мастерим очередное приложение для сайта some test на xamarin";
			item.Tags = "#xamarin #мобильное приложение #длиннопост";
			item.Comments = Int32.MaxValue;
			item.CardRating = "5741 плюсов";
			item.CardComments = "1041 комментариев";
			item.RatingString = "+ " + item.Rating;
			itemsSource.Add (item);
			itemsSource.Add (item);
			itemsSource.Add (item);
			itemsSource.Add (item);
			itemsSource.Add (item);
			for (var i = 0; i < 150; i++) {
				itemsSource.Add (item);
			}
			FeedListView.ItemsSource = itemsSource;
		}
	}
}

