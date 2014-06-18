using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Models;
using ScoreBook.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
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
			string name = (string)((Button)sender).Tag;
			var book = TopLevelViewModel.Instance.Library.GetBook(name);

			var view = new ScorebookView();
			view.DataContext = new ScorebookViewModel(book);
			TopLevelViewModel.Instance.NavigateToView(view);
		}

		private void ButtonDelete_Click(object sender, RoutedEventArgs e)
		{
			TopLevelViewModel.Instance.ClearLibrary();
			((HomeViewModel)this.DataContext).Refresh();
		}

		private void ButtonLoadSample_Click(object sender, RoutedEventArgs e)
		{
			var book1 = new Scorebook("Big Sticks 2014 Season", "Big Sticks");
			var s1 = new Scorecard();
			s1.Team = "Big Sticks";
			s1.Score = "5 - 3";
			s1.Opponent = "Beanflickers";
			s1.Location = "Home";
			book1.AddScorecard(s1);
			var s2 = new Scorecard();
			s2.Team = "Big Sticks";
			s2.Score = "12 - 27";
			s2.Opponent = "The bad guys";
			s2.Location = "Away";
			book1.AddScorecard(s2);
			TopLevelViewModel.Instance.Library.AddBook(book1);

			var book2 = new Scorebook("Milwaukee Brewers 2014 Season", "Milwaukee Brewers");
			var s3 = new Scorecard();
			s3.Team = "Milwaukee Brewers";
			s3.Score = "15 - 3";
			s3.Opponent = "Chicago Cubs";
			s3.Location = "Away";
			book2.AddScorecard(s3);
			var s4 = new Scorecard();
			s4.Team = "Milwaukee Brewers";
			s4.Score = "12 - 4";
			s4.Opponent = "St Louis Cardinals";
			s4.Location = "Away";
			s4.Players[0].Name = "Carlos Gomez";
			s4.Players[0].Number = "27";
			s4.Players[0].Position = "CF";
			s4.Players[1].Name = "Scooter Gennett";
			s4.Players[1].Number = "2";
			s4.Players[1].Position = "2B";
			s4.Players[2].Name = "Ryan Braun";
			s4.Players[2].Number = "8";
			s4.Players[2].Position = "RF";
			s4.Players[3].Name = "Aramis Ramirez";
			s4.Players[3].Number = "16";
			s4.Players[3].Position = "3B";
			s4.Players[4].Name = "Jonathan Lucroy";
			s4.Players[4].Number = "20";
			s4.Players[4].Position = "C";
			s4.Players[5].Name = "Mark Reynolds";
			s4.Players[5].Number = "7";
			s4.Players[5].Position = "1B";
			s4.Players[6].Name = "Khris Davis";
			s4.Players[6].Number = "18";
			s4.Players[6].Position = "LF";
			s4.Players[7].Name = "Jean Segura";
			s4.Players[7].Number = "9";
			s4.Players[7].Position = "SS";
			s4.Players[8].Name = "Wily Peralta";
			s4.Players[8].Number = "38";
			s4.Players[8].Position = "P";
		



			book2.AddScorecard(s4);
			TopLevelViewModel.Instance.Library.AddBook(book2);

			((HomeViewModel)this.DataContext).Refresh();
		}


		private async void ButtonSave_Click(object sender, RoutedEventArgs e)
		{

			var library = TopLevelViewModel.Instance.Library;

			MemoryStream sessionData = new MemoryStream();
			DataContractSerializer serializer = new DataContractSerializer(library.GetType());
			serializer.WriteObject(sessionData, library);


			StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("ScorecardSavedData.xml", CreationCollisionOption.ReplaceExisting);
			using (Stream fileStream = await file.OpenStreamForWriteAsync())
			{
				sessionData.Seek(0, SeekOrigin.Begin);
				await sessionData.CopyToAsync(fileStream);
				await fileStream.FlushAsync();
			}		
		}

		private async void ButtonOpen_Click(object sender, RoutedEventArgs e)
		{
			StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("ScorecardSavedData.xml");
			using (IInputStream inStream = await file.OpenSequentialReadAsync())
			{
				DataContractSerializer serializer = new DataContractSerializer(TopLevelViewModel.Instance.Library.GetType());
				var data = (ScorebookLibrary)serializer.ReadObject(inStream.AsStreamForRead());

				TopLevelViewModel.Instance.SetLibrary(data);
				((HomeViewModel)this.DataContext).Refresh();
			}
		}
	}
}
