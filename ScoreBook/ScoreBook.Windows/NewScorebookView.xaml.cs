using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Models;
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
	public sealed partial class NewScorebookView : UserControl
	{
		public NewScorebookView()
		{
			this.InitializeComponent();
		}

		private void ButtonHome_Click(object sender, RoutedEventArgs e)
		{
			TopLevelViewModel.Instance.NavigateToHome();
		}

		private void ButtonAdd_Click(object sender, RoutedEventArgs e)
		{
			var vm = (NewScorebookViewModel)this.DataContext;

			// Create a new Scorebook (with it's first scorecard) and add it to our library
			var scorebook = new Scorebook(vm.Name, vm.TeamName);
			var card = new Scorecard();
			card.Team = vm.TeamName;
			scorebook.AddScorecard(card);
			TopLevelViewModel.Instance.Library.AddBook(scorebook);

			// Navigate to the first Scorecard
			var view = new ScorecardView();
			view.DataContext = new ScorecardViewModel(card);
			TopLevelViewModel.Instance.NavigateToView(view);
		}
	}
}
