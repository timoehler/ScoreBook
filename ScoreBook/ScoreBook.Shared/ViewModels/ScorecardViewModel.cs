using System;
using System.Collections.Generic;
using System.Text;
using GlobalResources;
using Models;

namespace ScoreBook.ViewModels
{
	public class ScorecardViewModel : PropertyChangedViewModel
	{
		private Scorecard _scorecard;
		public ScorecardViewModel(Scorecard scorecard)
		{
			_scorecard = scorecard;
			HomeTeam = scorecard.Team;
			AwayTeam = scorecard.Opponent;
			Date = DateTime.Now.ToString("MM/dd/yyyy");
			NotifyPropertyChanged("Players");
		}

		public string HomeTeam { get; set; }
		public string AwayTeam { get; set; }
		public string Date { get; set; }

		public List<Player> Players 
		{ 
			get 
			{ 
				return _scorecard.Players; 
			} 
		}
	}
}
