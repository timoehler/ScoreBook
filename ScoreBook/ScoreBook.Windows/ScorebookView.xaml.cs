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
	public sealed partial class ScorebookView : UserControl
	{
		public ScorebookView()
		{
			this.InitializeComponent();
		}

		private void ButtonHome_Click(object sender, RoutedEventArgs e)
		{
			TopLevelViewModel.Instance.NavigateToHome();
		}

		private void ButtonAdd_Click(object sender, RoutedEventArgs e)
		{

		}

		private void ButtonCurrentScorecard_Click(object sender, RoutedEventArgs e)
		{
			var vm = (ScorebookViewModel)this.DataContext;
			var card = vm.Cards.Where(c => c.Title == (string)((Button)sender).Content).FirstOrDefault();
			if (card != null)
			{
				var view = new ScorecardView();
				view.DataContext = new ScorecardViewModel(card);
				TopLevelViewModel.Instance.NavigateToView(view);
			}
		}
	}
}
