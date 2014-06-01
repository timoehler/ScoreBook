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

	public class PlayersViewModel : PropertyChangedViewModel
	{
		Player _player;
		public PlayersViewModel(UserControl view, Player player)
		{
			_player = player;

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

		public string Name
		{
			get { return _player.Name; }
			set 
			{ 
				_player.Name = value; 
				NotifyPropertyChanged();
			}
		}

		public string Number
		{
			get { return _player.Number; }
			set
			{
				_player.Number = value;
				NotifyPropertyChanged();
			}
		}

		public string Position
		{
			get { return _player.Position; }
			set
			{
				_player.Position = value;
				NotifyPropertyChanged();
			}
		}
	}
}
