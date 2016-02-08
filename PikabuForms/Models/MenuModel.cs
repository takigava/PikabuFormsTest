using System;

namespace PikabuForms
{
	public class MenuModel
	{
		public string Icon{ get; private set; }
		public string Name{ get; private set; }
		public int Messages{ get; set; }
		public bool State { get; set; }

		public MenuModel(String Name, String Icon)
		{
			this.Name = Name;                     
			this.Icon = Icon;   
		}
	}
}

