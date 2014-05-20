using System;
using System.Collections.Generic;
using System.Text;
using GlobalResources;
using Models;
using Windows.Foundation;

namespace ScoreBook.ViewModels
{
	public class ScoringWidgetViewModel : PropertyChangedViewModel
	{
		private AtBat _atBat;
		public ScoringWidgetViewModel(AtBat atBat)
		{
			_atBat = atBat;
		}

		public Point HitPoint { get; set; }
		public Base FurthestBase { get; set; }
		public Base CaughtStealing { get; set; }

		#region Balls and Strikes

		private bool _strikeOne;
		public bool StrikeOne
		{
			get { return _strikeOne; }
			set
			{
				_strikeOne = value;
				_strikeTwo = false;
				RefreshBallsAndStrikes();
			}
		}

		private bool _strikeTwo;
		public bool StrikeTwo
		{
			get { return _strikeTwo; }
			set
			{
				_strikeOne = true;
				_strikeTwo = value;
				RefreshBallsAndStrikes();
			}
		}

		private bool _ballOne;
		public bool BallOne
		{
			get { return _ballOne; }
			set
			{
				_ballOne = value;
				_ballTwo = false;
				_ballThree = false;
				RefreshBallsAndStrikes();
			}
		}

		private bool _ballTwo;
		public bool BallTwo
		{
			get { return _ballTwo; }
			set
			{
				_ballOne = true;
				_ballTwo = value;
				_ballThree = false;
				RefreshBallsAndStrikes();
			}
		}

		private bool _ballThree;
		public bool BallThree
		{
			get { return _ballThree; }
			set
			{
				_ballOne = true;
				_ballTwo = true;
				_ballThree = value;
				RefreshBallsAndStrikes();
			}
		}

		private void RefreshBallsAndStrikes()
		{
			NotifyPropertyChanged("BallOne");
			NotifyPropertyChanged("BallTwo");
			NotifyPropertyChanged("BallThree");
			NotifyPropertyChanged("StrikeOne");
			NotifyPropertyChanged("StrikeTwo");
		}

		#endregion

		public int RBIs { get; set; }
		public AtBatEvent Outcome { get; set; }
		public OutType Out { get; set; }
	}

	public enum Base
	{
		First,
		Second,
		Third,
		Home,
		NotApplicable,
	}

	public enum AtBatEvent
	{
		Single,
		Double,
		Triple,
		HomeRun,
		BaseOnBalls,
		HitByPitch,
		StrikeOutLooking,
		StrikeoutSwinging,
		SacFly,
		OutInPlay
	}

	public enum OutType
	{
		NotOut,
		First,
		Second, 
		Third	
	}
}
