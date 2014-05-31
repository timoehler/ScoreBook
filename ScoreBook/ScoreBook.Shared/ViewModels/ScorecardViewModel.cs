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
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[0]));
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[1]));
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[2]));
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[3]));
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[4]));
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[5]));
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[6]));
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[7]));
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[8]));
		}

		public string HomeTeam { get; set; }
		public string AwayTeam { get; set; }
		public string Date { get; set; }


		public List<PlayersViewModel> PlayersViewModel { get; set; }
	}

	public class PlayersViewModel
	{
		public PlayersViewModel(UserControl view, Player player)
		{
			AtBatsViewModel = new List<ScoringWidgetViewModel>();
			AtBatsViewModel.Add(new ScoringWidgetViewModel(player.AtBats[0], view));
			AtBatsViewModel.Add(new ScoringWidgetViewModel(player.AtBats[1], view));
			AtBatsViewModel.Add(new ScoringWidgetViewModel(player.AtBats[2], view));
			AtBatsViewModel.Add(new ScoringWidgetViewModel(player.AtBats[3], view));
			AtBatsViewModel.Add(new ScoringWidgetViewModel(player.AtBats[4], view));
			AtBatsViewModel.Add(new ScoringWidgetViewModel(player.AtBats[5], view));
			AtBatsViewModel.Add(new ScoringWidgetViewModel(player.AtBats[6], view));
			AtBatsViewModel.Add(new ScoringWidgetViewModel(player.AtBats[7], view));
			AtBatsViewModel.Add(new ScoringWidgetViewModel(player.AtBats[8], view));
		}
		public List<ScoringWidgetViewModel> AtBatsViewModel { get; set; }
	}
}
