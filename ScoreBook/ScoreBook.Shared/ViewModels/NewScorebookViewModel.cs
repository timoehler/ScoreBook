using System;
using System.Collections.Generic;
using System.Text;
using GlobalResources;

namespace ScoreBook.ViewModels
{
	public class NewScorebookViewModel : PropertyChangedViewModel
	{
		private string _name;
		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				NotifyPropertyChanged();
			}
		}
		public string TeamName { get; set; }
	}
}
