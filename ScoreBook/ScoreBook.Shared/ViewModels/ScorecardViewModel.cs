using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace ScoreBook.ViewModels
{
	public class ScorecardViewModel
	{
		private Scorecard _scorecard;
		public ScorecardViewModel(Scorecard scorecard)
		{
			_scorecard = scorecard;
		}
	}
}
