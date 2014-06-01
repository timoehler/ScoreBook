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
	public sealed partial class ScorecardView : UserControl
	{
		public ScorecardView()
		{
			this.InitializeComponent();
		}

		private void ButtonHome_Click(object sender, RoutedEventArgs e)
		{
			TopLevelViewModel.Instance.NavigateToHome();
		}

		private void ButtonScorebook_Click(object sender, RoutedEventArgs e)
		{

		}

		private void ButtonEdit_Click(object sender, RoutedEventArgs e)
		{

		}

		private void ButtonCell_Click(object sender, RoutedEventArgs e)
		{
			var vm = (ScoringWidgetViewModel)((Button)sender).DataContext;

			var view = new AtBatPageView();
			view.DataContext = vm;
			TopLevelViewModel.Instance.NavigateToView(view);
		}

		private void ButtonName_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var view = new MessageBoxView();
			var viewModel = new MessageBoxViewModel();
			viewModel.Text = "Please enter the player name:";
			viewModel.Result = (string)button.Content;
			viewModel.OnOk = new Action(() => button.Content = viewModel.Result);
			view.DataContext = viewModel;
			TopLevelViewModel.Instance.ShowMessage(view);	
		}

		private void ButtonNumber_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var view = new MessageBoxView();
			var viewModel = new MessageBoxViewModel();
			viewModel.Text = "Please enter the player number:";
			viewModel.Result = (string)button.Content;
			viewModel.OnOk = new Action(() => button.Content = viewModel.Result);
			view.DataContext = viewModel;
			TopLevelViewModel.Instance.ShowMessage(view);
		}

		private void ButtonPosition_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var view = new MessageBoxView();
			var viewModel = new MessageBoxViewModel();
			viewModel.Text = "Please enter the player position:";
			viewModel.Result = (string)button.Content;
			viewModel.OnOk = new Action(() => button.Content = viewModel.Result);
			view.DataContext = viewModel;
			TopLevelViewModel.Instance.ShowMessage(view);
		}
	}
}
