using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Windows.UI.Xaml.Controls;
using GlobalResources;
using Models;
using ScoreBook.ViewModels;

namespace ScoreBook
{
	public class TopLevelViewModel : PropertyChangedViewModel
	{
		private UserControl _homeView;
		public ScorebookLibrary Library { get; private set; }
		private TopLevelViewModel()
		{
		}

		private static TopLevelViewModel _instance;
		public static TopLevelViewModel Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new TopLevelViewModel();
					_instance.Library = new ScorebookLibrary();			
					_instance._homeView = new HomeView();
					_instance._homeView.DataContext = new HomeViewModel();
					_instance.CurrentView = _instance._homeView;
				}

				return _instance;
			}
		}

		private UserControl _currentView;
		public UserControl CurrentView
		{
			get { return _currentView; }
			set
			{
				_currentView = value;
				NotifyPropertyChanged();
			}
		}

		public void NavigateToHome()
		{
			CurrentView = _homeView;
			((HomeViewModel)_homeView.DataContext).Refresh();
		}

		public void NavigateToView(UserControl view)
		{
			CurrentView = view;
		}

		public void ClearLibrary()
		{
			Library = new ScorebookLibrary();
			NotifyPropertyChanged("Library");
		}

		public void SetLibrary(ScorebookLibrary library)
		{
			Library = library;
			NotifyPropertyChanged("Library");
		}

	}
}
