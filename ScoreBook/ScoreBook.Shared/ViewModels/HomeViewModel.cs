using System;
using System.Collections.Generic;
using System.Text;
using GlobalResources;
using Models;

namespace ScoreBook.ViewModels
{
	public class HomeViewModel : PropertyChangedViewModel
	{
		public List<Scorebook> Books
		{
			get 
			{ 
				var b = TopLevelViewModel.Instance.Library.GetAllBooks();
				return b;
			}
		}
		public HomeViewModel()
		{
			NotifyPropertyChanged();
		}
	}
}
