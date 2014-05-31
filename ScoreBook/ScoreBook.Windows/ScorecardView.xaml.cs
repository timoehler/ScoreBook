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
	}
}
