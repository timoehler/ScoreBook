using System;
using System.Collections.Generic;
using System.Text;
using GlobalResources;
using Models;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace ScoreBook.ViewModels
{
	public class ScoreCellViewModel : PropertyChangedViewModel
	{
		private AtBat _atBat;
		private UserControl _backView;
		ScorecardViewModel _scorecardViewModel;
		public ScoreCellViewModel(AtBat atBat, UserControl backView, ScorecardViewModel scorecardViewModel)
		{
			_atBat = atBat;
			_backView = backView;
			LoadFromModel();
			RefreshControls();
			_scorecardViewModel = scorecardViewModel;

			scorecardViewModel.CellViewChanged += scorecardViewModel_CellViewChanged;
		}

		void scorecardViewModel_CellViewChanged(object sender, EventArgs e)
		{
			IsEditable = false;
		}

		private void LoadFromModel()
		{
			_strikeOne = _atBat.StrikeOne;
			_strikeTwo = _atBat.StrikeTwo;
			_ballOne = _atBat.BallOne;
			_ballTwo = _atBat.BallTwo;
			_ballThree = _atBat.BallThree;
			_single = _atBat.Single;
			_double = _atBat.Double;
			_triple = _atBat.Triple;
			_homeRun = _atBat.HomeRun;
			_baseOnBalls = _atBat.BaseOnBalls;
			_hitByPitch = _atBat.HitByPitch;
		}

		public Point HitPoint { get; set; }
		private Base _furthestBase = Base.NotApplicable;
		public Base FurthestBase
		{
			get { return _furthestBase; }
			set
			{
				_furthestBase = value;
				NotifyPropertyChanged();
			}
		}

		public Base CaughtStealing { get; set; }

		#region Balls and Strikes

		private bool _strikeOne;
		public bool StrikeOne
		{
			get { return _strikeOne; }
			set
			{
				if (_strikeOne == value)
				{
					return;
				}
				_strikeOne = value;
				_atBat.StrikeOne = value;
				_strikeTwo = false;
				_atBat.StrikeTwo = false;
				RefreshControls();
			}
		}

		private bool _strikeTwo;
		public bool StrikeTwo
		{
			get { return _strikeTwo; }
			set
			{
				if (_strikeTwo == value)
				{ 
					return;
				}
				_strikeOne = true;
				_atBat.StrikeOne = true;
				_strikeTwo = value;
				_atBat.StrikeTwo = value;
				RefreshControls();
			}
		}

		private bool _ballOne;
		public bool BallOne
		{
			get { return _ballOne; }
			set
			{
				if (_ballOne == value)
				{
					return;
				}
				_ballOne = value;
				_atBat.BallOne = value;
				_ballTwo = false;
				_atBat.BallTwo = false;
				_ballThree = false;
				_atBat.BallThree = false;
				RefreshControls();
			}
		}

		private bool _ballTwo;
		public bool BallTwo
		{
			get { return _ballTwo; }
			set
			{
				if (_ballTwo == value)
				{
					return;
				}
				_ballOne = true;
				_atBat.BallOne = true;
				_ballTwo = value;
				_atBat.BallTwo = value;
				_ballThree = false;
				_atBat.BallThree = false;
				RefreshControls();
			}
		}

		private bool _ballThree;
		public bool BallThree
		{
			get { return _ballThree; }
			set
			{
				if (_ballThree == value)
				{
					return;
				}
				_ballOne = true;
				_atBat.BallOne = true;
				_ballTwo = true;
				_atBat.BallTwo = true;
				_ballThree = value;
				_atBat.BallThree = value;
				RefreshControls();
			}
		}

		#endregion

		#region Hit Types

		private bool _single;
		public bool Single
		{
			get { return _single; }
			set
			{
				ClearOtherHitTypes(AtBatEvent.Single);
				_single = value;
				_atBat.Single = value;
				RefreshControls();
			}
		}

		private bool _double;
		public bool Double
		{
			get { return _double; }
			set
			{
				ClearOtherHitTypes(AtBatEvent.Double);
				_double = value;
				_atBat.Double = value;
				RefreshControls();
			}
		}

		private bool _triple;
		public bool Triple
		{
			get { return _triple; }
			set
			{
				ClearOtherHitTypes(AtBatEvent.Triple);
				_triple = value;
				_atBat.Triple = value;
				RefreshControls();
			}
		}

		private bool _homeRun;
		public bool HomeRun
		{
			get { return _homeRun; }
			set
			{
				ClearOtherHitTypes(AtBatEvent.HomeRun);
				_homeRun = value;
				_atBat.HomeRun = value;
				RefreshControls();
			}
		}

		private bool _baseOnBalls;
		public bool BaseOnBalls
		{
			get { return _baseOnBalls; }
			set
			{
				ClearOtherHitTypes(AtBatEvent.BaseOnBalls);
				_baseOnBalls = value;
				_atBat.BaseOnBalls = value;
				RefreshControls();
			}
		}

		private bool _hitByPitch;
		public bool HitByPitch
		{
			get { return _hitByPitch; }
			set
			{
				ClearOtherHitTypes(AtBatEvent.HitByPitch);
				_hitByPitch = value;
				_atBat.HitByPitch = value;
				RefreshControls();
			}
		}

		public string Text
		{
			get
			{
				if (Single) return "1B";
				if (Double) return "2B";
				if (Triple) return "3B";
				if (HomeRun) return "HR";
				if (BaseOnBalls) return "BB";
				if (HitByPitch) return "HBP";

				return string.Empty;
			}
		}

		private void ClearOtherHitTypes(AtBatEvent atBatEvent)
		{
			if (atBatEvent != AtBatEvent.Single)
			{
				_single = false;
				_atBat.Single = false;
			}
			if (atBatEvent != AtBatEvent.Double)
			{
				_double = false;
				_atBat.Double = false;
			}
			if (atBatEvent != AtBatEvent.Triple)
			{
				_triple = false;
				_atBat.Triple = false;
			}
			if (atBatEvent != AtBatEvent.HomeRun)
			{
				_homeRun = false;
				_atBat.HomeRun = false;
			}
			if (atBatEvent != AtBatEvent.BaseOnBalls)
			{
				_baseOnBalls = false;
				_atBat.BaseOnBalls = false;
			}
			if (atBatEvent != AtBatEvent.HitByPitch)
			{
				_hitByPitch = false;
				_atBat.HitByPitch = false;
			}
		}

		#endregion

		public int RBIs { get; set; }

		public OutType Out { get; set; }

		private void RefreshControls()
		{
			NotifyPropertyChanged("");
		}

		public void GoBack()
		{
			TopLevelViewModel.Instance.NavigateToView(_backView);
		}

		public int Inning { get { return _atBat.Inning; } }
		public int BattingOrder { get { return _atBat.BattingOrder; } }

		private bool _isEditable;
		public bool IsEditable
		{
			get { return _isEditable; }
			set
			{
				_isEditable = value;
				NotifyPropertyChanged();
			}
		}
	}

	
}
