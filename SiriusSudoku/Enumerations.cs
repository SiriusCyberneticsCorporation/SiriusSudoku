using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiriusSudoku
{
	public enum GameHelper
	{
		ShowNumberCount = 10,
		HighlightPencilMarks = 30,
		ShowErrors = 50,
	}

	public enum Difficulty
	{
		Unknown,
		Restarting,
		UserSupplied,
		TooEasy,
		Easy,
		Medium,
		Hard,
		Extreme,
		SillyHard,
	}
}
