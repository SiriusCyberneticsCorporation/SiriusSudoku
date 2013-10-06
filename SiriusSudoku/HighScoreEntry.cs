using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiriusSudoku
{
	[Serializable()]
	public class HighScoreEntry
	{
		public DateTime GameTime { get; set; }
		public Difficulty GameDifficulty { get; set; }
		public string PlayerName { get; set; }
		public int DurationSeconds { get; set; }
		public int FinalScore { get; set; }
	}
}
