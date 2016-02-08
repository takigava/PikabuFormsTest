using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace PikabuForms
{
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent ();
			var viewModel = new MenuViewModel ();
			viewModel.UserName = "@takigawa";
			viewModel.GroupedItems = new ObservableCollection<MenuGroupModel> ();

			var group1 = new MenuGroupModel("Лента","1");

			group1.Add (new MenuModel ("Горячее", "fire_element"));
			group1.Add (new MenuModel ("Лучшее", "medal"){State=true});
			group1.Add (new MenuModel ("Свежее", "towel"));

			var group2 = new MenuGroupModel("Профиль","2");

			group2.Add (new MenuModel ("Моя лента", "news"));
			group2.Add (new MenuModel ("Посты", "document"));
			group2.Add (new MenuModel ("Сообщения", "message"));
			group2.Add (new MenuModel ("Комментарии", "comments"));
			group2.Add (new MenuModel ("Оценки", "triangle_up"));
			group2.Add (new MenuModel ("Сохранённое", "save"));
			group2.Add (new MenuModel ("Настройки", "settings"));

			viewModel.GroupedItems.Add (group1);
			viewModel.GroupedItems.Add (group2);

//			viewModel.Items = new List<MenuModel>{ 
//				new MenuModel{Name="Горячее",Icon="fire_element",State=true},
//				new MenuModel{Name="Лучшее",Icon="medal",State=true},
//				new MenuModel{Name="Свежее",Icon="towel",State=true}};
			MenuListView.ItemsSource = viewModel.GroupedItems;
			//MenuUserName.Text = viewModel.UserName;
			BindingContext = viewModel;
		}
	}
}

