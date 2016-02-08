using System;
using System.Collections.ObjectModel;

namespace PikabuForms
{
	public class MenuGroupModel:ObservableCollection<MenuModel>
	{
		public String Name { get; private set; }        
		public String ShortName { get; private set; }

		public MenuGroupModel(String Name, String ShortName)
		{
			this.Name = Name;                     
			this.ShortName = ShortName;   
		}
	}
}

