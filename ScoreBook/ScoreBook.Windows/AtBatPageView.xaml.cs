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
	public sealed partial class AtBatPageView : UserControl
	{
		public AtBatPageView()
		{
			this.InitializeComponent();
		}

		private void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			var vm = DataContext as ScoreCellViewModel;
			vm.GoBack();
		}
	}
}
