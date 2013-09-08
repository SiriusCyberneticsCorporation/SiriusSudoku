using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiriusSudoku
{
	public partial class SiriusSudokuForm : Form
	{
		private bool m_gameActive = false;
		private bool m_gamePaused = false;
		private bool m_saveToHallOfFame = false;
		private bool m_enteringPuzzle = false;
		private DateTime m_gameStartTime = DateTime.Now;
		SudokuGenerator m_generator = null;

		public SiriusSudokuForm()
		{
			InitializeComponent();

			m_generator = new SudokuGenerator(TheGameBoard.GridSize);

			PauseToolStripButton.Enabled = false;
		}

		private void SiriusSudokuForm_Load(object sender, EventArgs e)
		{
			NumberSelectionPanel.SetNumberCountLimit(TheGameBoard.GridSize);
			NumberSelectionPanel.OnNumberSelected += NumberSelectionPanel_OnNumberSelected;
			NumberSelectionPanel.OnEraseToggled += NumberSelectionPanel_OnEraseToggled;
			NumberSelectionPanel.OnPencilInToggled += NumberSelectionPanel_OnPencilInToggled;

			TheGameBoard.OnCellTapped += TheGameBoard_OnCellTapped;
			TheGameBoard.OnCellCleared += TheGameBoard_OnCellCleared;
		}

		private void TheGameBoard_OnCellTapped(Position gridPosition, Position cellPosition)
		{
			if (m_enteringPuzzle)
			{
				int row = gridPosition.Row * 3 + cellPosition.Row;
				int column = gridPosition.Column * 3 + cellPosition.Column;
				
				TheGameBoard.SolutionGrid[row, column] = TheGameBoard.NumberSelected;
			}
			else
			{
				NumberSelectionPanel.UpdateNumberCount(TheGameBoard.SuppliedNumberCount);

				if (IsSolutionCorrect())
				{
					m_gameActive = false;
					PauseToolStripButton.Enabled = false;
					MessageBox.Show("Congratulations, you have solved the puzzle.");

					if (m_saveToHallOfFame)
					{
						// Save to Hall of Fame.
					}
				}
			}
		}

		void TheGameBoard_OnCellCleared(int number, Position gridPosition, Position cellPosition)
		{
			if (m_enteringPuzzle)
			{
				int row = gridPosition.Row * 3 + cellPosition.Row;
				int column = gridPosition.Column * 3 + cellPosition.Column;
				
				TheGameBoard.SolutionGrid[row, column] = 0;
			}

			NumberSelectionPanel.UpdateNumberCount(TheGameBoard.SuppliedNumberCount);
		}

		void NumberSelectionPanel_OnNumberSelected(int number)
		{
			TheGameBoard.NumberSelected = number;
		}

		void NumberSelectionPanel_OnEraseToggled(bool value)
		{
			TheGameBoard.Erasing = value;
		}

		void NumberSelectionPanel_OnPencilInToggled(bool value)
		{
			TheGameBoard.PencillingIn = value;
		}

		private bool IsSolutionCorrect()
		{
			return TheGameBoard.IsSolutionCorrect();
		}

		private void StartNewGame(Difficulty gameDifficulty)
		{
			TheGameBoard.ClearGrid();
			TheGameBoard.SolutionGrid = m_generator.GenerateGrid();

			if (!m_generator.IsUnique())
			{
				MessageBox.Show("NON-Unique solution generated!");
			}

			TheGameBoard.DisplayGrid(gameDifficulty);
			NumberSelectionPanel.UpdateNumberCount(TheGameBoard.SuppliedNumberCount);
			NumberSelectionPanel.ShowNumberCount(ShowNumberCountCheckBox.Checked);
			m_gameStartTime = DateTime.Now;
			m_gameActive = true;
			m_gamePaused = false;
			m_saveToHallOfFame = !ShowErrorsCheckBox.Checked;
			PauseToolStripButton.Enabled = true;
		}		

		private void EasyToolStripButton_Click(object sender, EventArgs e)
		{
			StartNewGame(Difficulty.Easy);
		}

		private void MediumToolStripButton_Click(object sender, EventArgs e)
		{
			StartNewGame(Difficulty.Medium);
		}

		private void HardToolStripButton_Click(object sender, EventArgs e)
		{
			StartNewGame(Difficulty.Hard);
		}

		private void ExtremeToolStripButton_Click(object sender, EventArgs e)
		{
			StartNewGame(Difficulty.Extreme);
		}

		private void ShowErrorsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			TheGameBoard.ShowErrors = ShowErrorsCheckBox.Checked;

			if (ShowErrorsCheckBox.Checked)
			{
				m_saveToHallOfFame = true;
			}
		}

		private void ShowNumberCountCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			NumberSelectionPanel.ShowNumberCount(ShowNumberCountCheckBox.Checked);
		}

		private void SecondTimer_Tick(object sender, EventArgs e)
		{
			if (m_gameActive && !m_gamePaused)
			{
				TimeSpan duration = (DateTime.Now - m_gameStartTime);
				if (duration.Hours > 0)
				{
					TimerToolStripTextBox.Text = duration.ToString("hh':'mm':'ss");
				}
				else
				{
					TimerToolStripTextBox.Text = duration.ToString("mm':'ss");
				}
			}
		}

		private void SiriusSudokuForm_Resize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{
				if (m_gameActive)
				{
					m_gamePaused = true;
				}
			}
			else
			{
				if (m_gameActive)
				{
					m_gamePaused = false;
				}
			}
		}

		private void PauseToolStripButton_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}

		private void SiriusSudokuForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (m_gameActive)
			{
				DialogResult answer = MessageBox.Show("A game is currently in progress. Do you want to save the current game?", 
														"Save Game", MessageBoxButtons.YesNoCancel);

				if (answer == System.Windows.Forms.DialogResult.Yes)
				{
					// Save current game.
				}
				else if (answer == System.Windows.Forms.DialogResult.Cancel)
				{
					DialogResult = System.Windows.Forms.DialogResult.None;
				}
			}
		}

		private void enterPuzzleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EasyToolStripButton.Enabled = false;
			MediumToolStripButton.Enabled = false;
			HardToolStripButton.Enabled = false;
			ExtremeToolStripButton.Enabled = false;
			m_enteringPuzzle = true;

			TheGameBoard.ClearGrid();
			TheGameBoard.SolutionGrid = m_generator.CreateBlankGrid();
			NumberSelectionPanel.UpdateNumberCount(TheGameBoard.SuppliedNumberCount);
		}

		private void beginSolvingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			m_enteringPuzzle = false;
			TheGameBoard.ClearGrid();
			TheGameBoard.DisplayGrid(Difficulty.UserSupplied);
			TheGameBoard.SolutionGrid = m_generator.SolveGrid(TheGameBoard.SolutionGrid);
			NumberSelectionPanel.UpdateNumberCount(TheGameBoard.SuppliedNumberCount);
			NumberSelectionPanel.ShowNumberCount(ShowNumberCountCheckBox.Checked);
			m_gameStartTime = DateTime.Now;
			m_gameActive = true;
			m_gamePaused = false;
			m_saveToHallOfFame = !ShowErrorsCheckBox.Checked;
			PauseToolStripButton.Enabled = true;

			EasyToolStripButton.Enabled = true;
			MediumToolStripButton.Enabled = true;
			HardToolStripButton.Enabled = true;
			ExtremeToolStripButton.Enabled = true;
		}

		private void savePuzzleToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}
	}
}
