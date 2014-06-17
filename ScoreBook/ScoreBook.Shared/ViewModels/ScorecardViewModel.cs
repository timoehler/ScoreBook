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
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[0], this));
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[1], this));
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[2], this));
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[3], this));
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[4], this));
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[5], this));
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[6], this));
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[7], this));
			PlayersViewModel.Add(new PlayersViewModel(backView, scorecard.Players[8], this));
		}

		public string HomeTeam { get; set; }
		public string AwayTeam { get; set; }
		public string Date { get; set; }

		public event EventHandler CellViewChanged;

		public void FireCellViewChanged()
		{
			if (CellViewChanged != null)
			{
				CellViewChanged(this, null);
			}
		}


		public List<PlayersViewModel> PlayersViewModel { get; set; }
	}

	public class PlayersViewModel : PropertyChangedViewModel
	{
		Player _player;
		public PlayersViewModel(UserControl view, Player player, ScorecardViewModel scorecardViewModel)
		{
			_player = player;

			AtBatsViewModel = new List<ScoreCellViewModel>();
			AtBatsViewModel.Add(new ScoreCellViewModel(player.AtBats[0], view, scorecardViewModel));
			AtBatsViewModel.Add(new ScoreCellViewModel(player.AtBats[1], view, scorecardViewModel));
			AtBatsViewModel.Add(new ScoreCellViewModel(player.AtBats[2], view, scorecardViewModel));
			AtBatsViewModel.Add(new ScoreCellViewModel(player.AtBats[3], view, scorecardViewModel));
			AtBatsViewModel.Add(new ScoreCellViewModel(player.AtBats[4], view, scorecardViewModel));
			AtBatsViewModel.Add(new ScoreCellViewModel(player.AtBats[5], view, scorecardViewModel));
			AtBatsViewModel.Add(new ScoreCellViewModel(player.AtBats[6], view, scorecardViewModel));
			AtBatsViewModel.Add(new ScoreCellViewModel(player.AtBats[7], view, scorecardViewModel));
			AtBatsViewModel.Add(new ScoreCellViewModel(player.AtBats[8], view, scorecardViewModel));
		}
		public List<ScoreCellViewModel> AtBatsViewModel { get; set; }

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
