using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using GlobalResources;
using ScoreBook.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
	public sealed partial class ScoreCellView : UserControl
	{
		public ScoreCellView()
		{
			this.InitializeComponent();
		}

		private void FirstBase_Click(object sender, RoutedEventArgs e)
		{
			var vm = this.DataContext as ScoreCellViewModel;

			if (vm.FurthestBase != Base.First)
				vm.FurthestBase = Base.First;
			else
				vm.FurthestBase = Base.NotApplicable;
		}

		private void SecondBase_Click(object sender, RoutedEventArgs e)
		{
			var vm = this.DataContext as ScoreCellViewModel;

			if (vm.FurthestBase != Base.Second)
				vm.FurthestBase = Base.Second;
			else
				vm.FurthestBase = Base.NotApplicable;
		}

		private void ThirdBase_Click(object sender, RoutedEventArgs e)
		{
			var vm = this.DataContext as ScoreCellViewModel;

			if (vm.FurthestBase != Base.Third)
				vm.FurthestBase = Base.Third;
			else
				vm.FurthestBase = Base.NotApplicable;
		}

		private void HomePlate_Click(object sender, RoutedEventArgs e)
		{
			var vm = this.DataContext as ScoreCellViewModel;

			if (vm.FurthestBase != Base.Home)
				vm.FurthestBase = Base.Home;
			else
				vm.FurthestBase = Base.NotApplicable;
		}
	}

	public class FurthestBaseToThicknessConverter : IValueConverter
	{
		public int T { get; set; }
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var furthestBase = (Base)value;
			if (furthestBase == Base.First)
			{
				return new Thickness(0, 0, 0, T);
			}
			if (furthestBase == Base.Second)
			{
				return new Thickness(0, 0, T, T);
			}
			if (furthestBase == Base.Third)
			{
				return new Thickness(0, T, T, T);
			}
			if (furthestBase == Base.Home)
			{
				return new Thickness(T);
			}

			return new Thickness(0);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}

	public class HomeRunToFillColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var furthestBase = (Base)value;
			if (furthestBase == Base.Home)
			{
				return new SolidColorBrush(Colors.Yellow);
			}
			return new SolidColorBrush(Colors.Transparent);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
