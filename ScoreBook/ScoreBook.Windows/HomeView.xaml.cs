using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ScoreBook.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace ScoreBook
{
	public sealed partial class HomeView : UserControl
	{
		public HomeView()
		{
			this.InitializeComponent();
		}

		private void ButtonIntro_Click(object sender, RoutedEventArgs e)
		{
			var view = new IntroductionView();
			view.DataContext = new IntroductionViewModel();
			TopLevelViewModel.Instance.NavigateToView(view);
		}

		private void ButtonNewScorebook_Click(object sender, RoutedEventArgs e)
		{
			var view = new NewScorebookView();
			view.DataContext = new NewScorebookViewModel();
			TopLevelViewModel.Instance.NavigateToView(view);
		}

		private void ButtonCurrentScorecard_Click(object sender, RoutedEventArgs e)
		{
			string name = (string)((Button)sender).Content;
			var book = TopLevelViewModel.Instance.Library.GetBook(name);

			var view = new ScorebookView();
			view.DataContext = new ScorebookViewModel(book);
			TopLevelViewModel.Instance.NavigateToView(view);
		}
	}
}
