using System;
using System.Collections.Generic;
using System.Text;
using GlobalResources;
using Models;

namespace ScoreBook.ViewModels
{
	public class HomeViewModel : PropertyChangedViewModel
	{
		public List<Scorebook> Books { get; private set; }
		public HomeViewModel()
		{
			Refresh();
		}

		public void Refresh()
		{
			Books = new List<Scorebook>();
			Books.AddRange(TopLevelViewModel.Instance.Library.GetAllBooks());
			NotifyPropertyChanged("Books");
		}
	}
}
