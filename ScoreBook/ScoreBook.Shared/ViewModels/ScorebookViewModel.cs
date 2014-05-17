using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace ScoreBook.ViewModels
{
	public class ScorebookViewModel
	{
		Scorebook _scorebook;
		public ScorebookViewModel(Scorebook scorebook)
		{
			_scorebook = scorebook;
		}
	}
}
