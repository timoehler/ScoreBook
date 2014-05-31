using System;
using System.Collections.Generic;
using System.Text;
using GlobalResources;
using Models;
using Windows.UI.Xaml.Controls;

namespace ScoreBook.ViewModels
{
	public class ScorecardViewModel : PropertyChangedViewModel
	{
		private Scorecard _scorecard;
		public ScorecardViewModel(Scorecard scorecard, UserControl backView)
		{
			_scorecard = scorecard;
			HomeTeam = scorecard.Team;
			AwayTeam = scorecard.Opponent;
			Date = DateTime.Now.ToString("MM/dd/yyyy");
			NotifyPropertyChanged("Players");
			PlayersViewModel = new List<PlayersViewModel>();
			PlayersViewModel.Add(new PlayersViewModel(backView));
			PlayersViewModel.Add(new PlayersViewModel(backView));
			PlayersViewModel.Add(new PlayersViewModel(backView));
			PlayersViewModel.Add(new PlayersViewModel(backView));
			PlayersViewModel.Add(new PlayersViewModel(backView));
			PlayersViewModel.Add(new PlayersViewModel(backView));
			PlayersViewModel.Add(new PlayersViewModel(backView));
			PlayersViewModel.Add(new PlayersViewModel(backView));
			PlayersViewModel.Add(new PlayersViewModel(backView));
		}

		public string HomeTeam { get; set; }
		public string AwayTeam { get; set; }
		public string Date { get; set; }


		public List<PlayersViewModel> PlayersViewModel { get; set; }
	}

	public class PlayersViewModel
	{
		public PlayersViewModel(UserControl view)
		{
			AtBatsViewModel = new List<ScoringWidgetViewModel>();
			AtBatsViewModel.Add(new ScoringWidgetViewModel(new AtBat(1), view));
			AtBatsViewModel.Add(new ScoringWidgetViewModel(new AtBat(2), view));
			AtBatsViewModel.Add(new ScoringWidgetViewModel(new AtBat(3), view));
			AtBatsViewModel.Add(new ScoringWidgetViewModel(new AtBat(4), view));
			AtBatsViewModel.Add(new ScoringWidgetViewModel(new AtBat(5), view));
			AtBatsViewModel.Add(new ScoringWidgetViewModel(new AtBat(6), view));
			AtBatsViewModel.Add(new ScoringWidgetViewModel(new AtBat(7), view));
			AtBatsViewModel.Add(new ScoringWidgetViewModel(new AtBat(8), view));
			AtBatsViewModel.Add(new ScoringWidgetViewModel(new AtBat(9), view));
		}
		public List<ScoringWidgetViewModel> AtBatsViewModel { get; set; }
	}
}
