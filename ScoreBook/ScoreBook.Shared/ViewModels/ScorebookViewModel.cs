using System;
using System.Collections.Generic;
using System.Text;
using GlobalResources;
using Models;

namespace ScoreBook.ViewModels
{
	public class ScorebookViewModel : PropertyChangedViewModel
	{
		Scorebook _scorebook;
		public ScorebookViewModel(Scorebook scorebook)
		{
			_scorebook = scorebook;
		}

		public List<Scorecard> Cards { get { return _scorebook.GetAllScorecards(); } }
	}
}
