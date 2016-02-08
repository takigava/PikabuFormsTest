using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PikabuForms
{
	public class PostModel
	{
		public int Id{ get; set; }
		public string AuthorName{ get; set; }
		public int Rating{ get; set; }
		public string PostTime{ get; set; }
		public string Title{ get; set; }
		public string Description{ get; set; }
		public string Tags{ get; set; }
		public PostType PostType{ get; set; }
		public string PostUrl{ get; set; }
		public int Comments{ get; set; }
		public string CardComments{ get; set;}
		public string CardRating{ get; set; }
		public string RatingString{ get; set; }

		public int Width { get; set; }
		public int Height { get; set; }

		public List<string> Text{ get; set; }
		public List<string> ImageUrl{ get; set; }
		public List<string> GifUrl { get; set; }
		public List<string> VideoUrl{ get; set; }

		public bool IsBiggerAvailable{ get; set; }
	}
}

