using System;
using System.Collections.Generic;
using System.Text;
using GlobalResources;

namespace ScoreBook
{
	public class MessageBoxViewModel : PropertyChangedViewModel
	{
		public string Text { get; set; }
		public string Result { get; set; }

		public Action OnOk { get; set; }

		public void ExecuteOk()
		{
			OnOk();
			TopLevelViewModel.Instance.HideMessage();
		}
	}
}
