using System;
using System.Collections.Generic;
using System.Text;

namespace SiriusSudoku
{
	[Serializable()]
	public class Player
	{
		public string PlayerName = string.Empty;
		public Dictionary<Difficulty, int> AverageTimes = new Dictionary<Difficulty, int>();
	}
}
