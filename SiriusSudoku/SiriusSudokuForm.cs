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
		private int m_gameDurationSeconds = 0;
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
			TheGameBoard.OnGridSelectedNumber += new SudokuGameBoard.GridSelectedNumberHandler(TheGameBoard_OnGridSelectedNumber);
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

		void TheGameBoard_OnGridSelectedNumber(int number)
		{
			NumberSelectionPanel.SelectNumber(number);
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
			Cursor = Cursors.WaitCursor;

			m_generator.GenerateSudokuGrid(gameDifficulty);

			TheGameBoard.ClearGrid();
			TheGameBoard.SolutionGrid = m_generator.SolutionGrid;
			TheGameBoard.DisplayGrid(m_generator.DisplayGrid);
			TheGameBoard.ShowErrors = ShowErrorsCheckBox.Checked;
			TheGameBoard.HighlightPencilMarks = HighlightPencilMarksCheckBox.Checked;
			NumberSelectionPanel.UpdateNumberCount(TheGameBoard.SuppliedNumberCount);
			NumberSelectionPanel.ShowNumberCount(ShowNumberCountCheckBox.Checked);
			m_gameDurationSeconds = 0;
			m_gameActive = true;
			m_gamePaused = false;
			m_saveToHallOfFame = !ShowErrorsCheckBox.Checked;
			PauseToolStripButton.Enabled = true;

			Cursor = Cursors.Default;
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
				m_saveToHallOfFame = false;
			}
		}

		private void HighlightPencilMarksCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			TheGameBoard.HighlightPencilMarks = HighlightPencilMarksCheckBox.Checked;

			if (HighlightPencilMarksCheckBox.Checked)
			{
				m_saveToHallOfFame = false;
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
				m_gameDurationSeconds++;
				if ((m_gameDurationSeconds/3600) > 0)
				{
					TimerToolStripTextBox.Text = (m_gameDurationSeconds / 3600).ToString("00") + ":" +
												 ((m_gameDurationSeconds / 60) % 60).ToString("00") + ":" +
												 (m_gameDurationSeconds % 60).ToString("00");
				}
				else
				{
					TimerToolStripTextBox.Text = ((m_gameDurationSeconds / 60) % 60).ToString("00") + ":" +
												 (m_gameDurationSeconds % 60).ToString("00");
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

			int[,] grid = m_generator.CreateBlankGrid();
			Buffer.BlockCopy(TheGameBoard.SolutionGrid, 0, grid, 0, TheGameBoard.SolutionGrid.Length * sizeof(int));
			
			m_generator.DisplayGrid = TheGameBoard.SolutionGrid;
			m_generator.SolveGrid(ref grid);
			m_generator.SolutionGrid = grid;
			TheGameBoard.SolutionGrid = m_generator.SolutionGrid;
			TheGameBoard.DisplayGrid(m_generator.DisplayGrid);

//			TheGameBoard.DisplayGrid(Difficulty.UserSupplied);
//			TheGameBoard.SolutionGrid = 
			NumberSelectionPanel.UpdateNumberCount(TheGameBoard.SuppliedNumberCount);
			NumberSelectionPanel.ShowNumberCount(ShowNumberCountCheckBox.Checked);
			m_gameDurationSeconds = 0;
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

		private void HallOfFameToolStripButton_Click(object sender, EventArgs e)
		{

		}

		private void SavePuzzle()
		{
		}

		private void LoadPuzzle()
		{
		}
	}
}
