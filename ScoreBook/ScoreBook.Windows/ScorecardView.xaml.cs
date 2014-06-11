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
			var vm = (ScoreCellViewModel)((Button)sender).DataContext;
			var button = sender as Button;

			var size = Math.Min(_scrollViewer.ActualHeight, _scrollViewer.ActualWidth);
			float zoomFactor = (float)(size / (1.25 * (button.ActualWidth + button.Margin.Right + button.Margin.Left)));

			
			var x = (_buttonName.ActualWidth + _buttonName.Margin.Left + _buttonName.Margin.Right +
				_buttonNumber.ActualWidth + _buttonNumber.Margin.Left + _buttonNumber.Margin.Right +
				_buttonPos.ActualWidth + _buttonPos.Margin.Left + _buttonPos.Margin.Right) * zoomFactor;
			var y = (_buttonName.ActualHeight + _buttonName.Margin.Top + _buttonName.Margin.Bottom) * zoomFactor;

			


			x += (vm.Inning - 1) * (button.ActualWidth + button.Margin.Left + button.Margin.Right) * zoomFactor;
			y += (vm.BattingOrder - 1) * (button.ActualHeight + button.Margin.Top + button.Margin.Bottom) * zoomFactor;

			var offsetY = ((_scrollViewer.ActualHeight - (button.Height + button.Margin.Top + button.Margin.Bottom) * zoomFactor) / 2);
			var offsetX = ((_scrollViewer.ActualWidth - (button.Width + button.Margin.Left + button.Margin.Right) * zoomFactor) / 2);
			// TODO.  divide by two and shift half a square over
			_scrollViewer.ChangeView(x - offsetX, y - offsetY, zoomFactor);
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
