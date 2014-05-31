using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalResources
{
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
