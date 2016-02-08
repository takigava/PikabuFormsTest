using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PikabuForms
{
	public class MenuViewModel
	{
		public string UserIcon{ get; set;}
		public string UserName{get;set;}

		public ObservableCollection<MenuGroupModel> GroupedItems{ get; set; }
	}
}

