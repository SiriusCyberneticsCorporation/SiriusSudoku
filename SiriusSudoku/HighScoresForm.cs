using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SiriusSudoku
{
	public partial class HighScoresForm : Form
	{
		private Dictionary<Difficulty, List<HighScoreEntry>> m_highScores = null;

		public HighScoresForm(Dictionary<Difficulty, List<HighScoreEntry>> highScores)
		{
			InitializeComponent();

			m_highScores = highScores;
		}

		private void AddEntries(Difficulty difficultyLevel)
		{
			int counter = 0;

			HighScoresTextBox.Text = "                 High Scores - " + difficultyLevel.ToString();
			HighScoresTextBox.Text += "\r\n";
			HighScoresTextBox.Text += "\r\n   #       Date & Time         Duration        Score";
			HighScoresTextBox.Text += "\r\n   ---------------------------------------------";

			if (m_highScores.ContainsKey(difficultyLevel))
			{
				List<HighScoreEntry> scoreEntries = m_highScores[difficultyLevel];

				scoreEntries.Sort(CompareHighScores);

				foreach (HighScoreEntry highScore in scoreEntries)
				{
					counter++;
					HighScoresTextBox.Text += string.Format("\r\n  {0,2}   {1}   {2}     {3,10}",
															counter,
															highScore.GameTime.ToString("dd-MMM-yyyy HH:mm"),
															SiriusSudokuForm.GetTimeText(highScore.DurationSeconds),
															highScore.FinalScore.ToString());
				}
			}

			for (; counter < 11; counter++)
			{
				HighScoresTextBox.Text += string.Format("\r\n  {0,2}", counter);
			}
		}

		private static int CompareHighScores(HighScoreEntry x, HighScoreEntry y)
		{
			if (x == null)
			{
				if (y == null)
				{
					// If x is null and y is null, they're equal.  
					return 0;
				}
				else
				{
					// If x is null and y is not null, y is greater.  
					return -1;
				}
			}
			// If x is not null... 
			else
			{
				// ...and y is null, x is greater.
				if (y == null)
				{
					return 1;
				}
				// ...and y is not null, compare the sum of score and time.
				else
				{
					int xValue = x.DurationSeconds + x.FinalScore;
					int yValue = y.DurationSeconds + y.FinalScore;

					return xValue.CompareTo(yValue);
				}
			}
		}

		private void EasyButton_Click(object sender, EventArgs e)
		{
			AddEntries(Difficulty.Easy);
		}

		private void MediumButton_Click(object sender, EventArgs e)
		{
			AddEntries(Difficulty.Medium);
		}

		private void HardButton_Click(object sender, EventArgs e)
		{
			AddEntries(Difficulty.Hard);
		}

		private void ExtremeButton_Click(object sender, EventArgs e)
		{
			AddEntries(Difficulty.Extreme);
		}

		private void SillyHardButton_Click(object sender, EventArgs e)
		{
			AddEntries(Difficulty.SillyHard);
		}

		private void HighScoresForm_Shown(object sender, EventArgs e)
		{
			EasyButton_Click(null, null);
		}
	}
}
