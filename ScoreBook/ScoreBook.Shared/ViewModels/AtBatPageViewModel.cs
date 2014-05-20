using System;
using System.Collections.Generic;
using System.Text;
using GlobalResources;
using Models;

namespace ScoreBook.ViewModels
{
	public class AtBatPageViewModel : PropertyChangedViewModel
	{
		public ScoringWidgetViewModel ScoringWidgetViewModel { get; private set; }
		public AtBat AtBat { get; private set; }
		public AtBatPageViewModel(AtBat atBat)
		{
			AtBat = atBat;
			ScoringWidgetViewModel = new ScoringWidgetViewModel(atBat);
		}
	}
}
