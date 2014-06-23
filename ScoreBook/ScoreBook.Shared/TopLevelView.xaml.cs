using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ScoreBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TopLevelView : Page
    {
        public TopLevelView()
        {
            this.InitializeComponent();

			// This view is created once at startup and remains the top level view for the lifetime of the app.

			this.DataContext = TopLevelViewModel.Instance;
        }

		private void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			var vm = this.DataContext as TopLevelViewModel;
			vm.GoBack();
		}

		private void ButtonHome_Click(object sender, RoutedEventArgs e)
		{
			var vm = this.DataContext as TopLevelViewModel;
			vm.NavigateToHome();
		}
    }
}
