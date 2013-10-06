using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Xml;
//using System.Xml.Serialization;

namespace SiriusSudoku
{
	public partial class SiriusSudokuForm : Form
	{
		private const string PLAYERS_FILE = "Players.bin";
		private const string HIGH_SCORES_FILE = "SiriusSudoku.bin";

		private bool m_gameActive = false;
		private bool m_gamePaused = false;
		private bool m_firstMoveMade = false;
		private bool m_enteringPuzzle = false;
		private int m_gameDurationSeconds = 0;
		private Player m_gamePlayer = null;
		private Difficulty m_gameDifficulty = Difficulty.Unknown;
		private SudokuGenerator m_generator = null;
		private List<Player> m_players = new List<Player>();
		private List<GameHelper> m_gameHelpers = new List<GameHelper>();
		private Dictionary<Difficulty, List<HighScoreEntry>> m_highScores = new Dictionary<Difficulty, List<HighScoreEntry>>();

		public SiriusSudokuForm()
		{
			InitializeComponent();

			LoadLocation();

			m_generator = new SudokuGenerator(TheGameBoard.GridSize);

			PauseToolStripButton.Enabled = false;
			RestartGameButton.Enabled = false;
		}

		private void SiriusSudokuForm_Load(object sender, EventArgs e)
		{
			ReadPlayers();
			ReadHighScores();

			NumberSelectionPanel.SetNumberCountLimit(TheGameBoard.GridSize);
			NumberSelectionPanel.OnNumberSelected += NumberSelectionPanel_OnNumberSelected;
			NumberSelectionPanel.OnEraseToggled += NumberSelectionPanel_OnEraseToggled;
			NumberSelectionPanel.OnPencilInToggled += NumberSelectionPanel_OnPencilInToggled;

			TheGameBoard.OnCellTapped += TheGameBoard_OnCellTapped;
			TheGameBoard.OnCellCleared += TheGameBoard_OnCellCleared;
			TheGameBoard.OnGridSelectedNumber += new SudokuGameBoard.GridSelectedNumberHandler(TheGameBoard_OnGridSelectedNumber);
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

			WritePlayers();
			WriteHighScores();
			SaveLocation();
		}
		
		private void LoadLocation()
		{
			if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.InitialLocation))
			{
				string[] parts = Properties.Settings.Default.InitialLocation.Split(',');
				if (parts.Length >= 2)
				{
					Location = new Point(int.Parse(parts[0]), int.Parse(parts[1]));
				}
				if (parts.Length >= 4)
				{
					Size = new Size(int.Parse(parts[2]), int.Parse(parts[3]));
				}
			}
		}

		private void SaveLocation()
		{
			Point currentLocation = Location;
			Size currentSize = Size;
	
			if (WindowState != FormWindowState.Normal)
			{
				currentLocation = RestoreBounds.Location;
				currentSize = RestoreBounds.Size;
			}

			Properties.Settings.Default.InitialLocation = string.Join(",", currentLocation.X, currentLocation.Y, currentSize.Width, currentSize.Height);
			Properties.Settings.Default.Save();
		}

		private void ReadPlayers()
		{
			if (File.Exists(PLAYERS_FILE))
			{
				using (Stream stream = File.Open(PLAYERS_FILE, FileMode.Open))
				{
					BinaryFormatter bin = new BinaryFormatter();
					m_players = (List<Player>)bin.Deserialize(stream);

					foreach (Player savedPlayer in m_players)
					{
						PlayersToolStripComboBox.Items.Add(savedPlayer);
					}

					PlayersToolStripComboBox.Text = Properties.Settings.Default.LastPlayer;
					m_gamePlayer = (Player)PlayersToolStripComboBox.SelectedItem;
				}
			}

			PlayersToolStripComboBox.Items.Insert(0, "New Player");
		}

		private void ReadHighScores()
		{
			if (File.Exists(HIGH_SCORES_FILE))
			{
				using (Stream stream = File.Open(HIGH_SCORES_FILE, FileMode.Open))
				{
					BinaryFormatter bin = new BinaryFormatter();
					m_highScores = (Dictionary<Difficulty, List<HighScoreEntry>>)bin.Deserialize(stream);
				}
			}			
		}

		private void WritePlayers()
		{
			if (PlayersToolStripComboBox.SelectedIndex > 0)
			{
				Properties.Settings.Default.LastPlayer = PlayersToolStripComboBox.SelectedItem.ToString();
				Properties.Settings.Default.Save();
			}

			using (Stream stream = File.Open(PLAYERS_FILE, FileMode.Create))
			{
				BinaryFormatter bin = new BinaryFormatter();
				bin.Serialize(stream, m_players);
			}
		}

		private void WriteHighScores()
		{
			using (Stream stream = File.Open(HIGH_SCORES_FILE, FileMode.Create))
			{
				BinaryFormatter bin = new BinaryFormatter();
				bin.Serialize(stream, m_highScores);
			}
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

					SaveHallOfFameEntry();
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

		private bool GetPlayerName()
		{
			NewPlayerForm iNewPlayerForm = new NewPlayerForm();

			if (iNewPlayerForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK && 
				iNewPlayerForm.PlayerName.Length > 0)
			{
				Player newPlayer = new Player();
				newPlayer.PlayerName = iNewPlayerForm.PlayerName;
				m_players.Add(newPlayer);
				PlayersToolStripComboBox.Items.Add(newPlayer);
				
				PlayersToolStripComboBox.Text = newPlayer.PlayerName;
				m_gamePlayer = (Player)PlayersToolStripComboBox.SelectedItem;
				return true;
			}
			else
			{
				return false;
			}
		}

		private void StartNewGame(Difficulty gameDifficulty)
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
					return;
				}
			}

			bool startGame = true;

			if (PlayersToolStripComboBox.SelectedIndex < 1)
			{
				startGame = GetPlayerName();
			}

			if (startGame)
			{
				Cursor = Cursors.WaitCursor;

				m_generator.GenerateSudokuGrid(gameDifficulty);

				StartGame(gameDifficulty);

				Cursor = Cursors.Default;
			}
		}

		private void StartGame(Difficulty gameDifficulty)
		{
			TheGameBoard.ClearGrid();
			TheGameBoard.SolutionGrid = m_generator.SolutionGrid;
			TheGameBoard.DisplayGrid(m_generator.DisplayGrid);

			m_gameDurationSeconds = 0;
			m_gameActive = true;
			m_gamePaused = false;
			m_firstMoveMade = false;

			if (gameDifficulty != Difficulty.Restarting)
			{
				m_gameDifficulty = gameDifficulty;
			}

			InitialiseGameHelpers(gameDifficulty);

			TheGameBoard.ShowErrors = ShowErrorsCheckBox.Checked;
			NumberSelectionPanel.ShowNumberCount(ShowNumberCountCheckBox.Checked);
			TheGameBoard.HighlightPencilMarks = HighlightPencilMarksCheckBox.Checked;

			NumberSelectionPanel.UpdateNumberCount(TheGameBoard.SuppliedNumberCount);
	
			EasyToolStripButton.Enabled = true;
			MediumToolStripButton.Enabled = true;
			HardToolStripButton.Enabled = true;
			ExtremeToolStripButton.Enabled = true;
			PauseToolStripButton.Enabled = true;
			RestartGameButton.Enabled = true;
		}

		private void InitialiseGameHelpers(Difficulty gameDifficulty)
		{
			switch(gameDifficulty)
			{
				case Difficulty.SillyHard:
				case Difficulty.Extreme:
				case Difficulty.Hard:
					ShowErrorsCheckBox.Checked = false;
					ShowNumberCountCheckBox.Checked = false;
					HighlightPencilMarksCheckBox.Checked = false;
					break;
				case Difficulty.Medium:
					ShowErrorsCheckBox.Checked = false;
					HighlightPencilMarksCheckBox.Checked = false;
					break;
			}

			CollectGameHelpers();
		}

		private void CollectGameHelpers()
		{
			if (!m_firstMoveMade)
			{
				m_gameHelpers.Clear();
			}

			if (ShowErrorsCheckBox.Checked)
			{
				m_gameHelpers.Add(GameHelper.ShowErrors);
			}
			if (ShowNumberCountCheckBox.Checked)
			{
				m_gameHelpers.Add(GameHelper.ShowNumberCount);
			}
			if (HighlightPencilMarksCheckBox.Checked)
			{
				m_gameHelpers.Add(GameHelper.HighlightPencilMarks);
			}
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

		private void SillyHardToolStripButton_Click(object sender, EventArgs e)
		{
			StartNewGame(Difficulty.SillyHard);
		}

		private void ShowErrorsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			TheGameBoard.ShowErrors = ShowErrorsCheckBox.Checked;
			CollectGameHelpers();
		}

		private void ShowNumberCountCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			NumberSelectionPanel.ShowNumberCount(ShowNumberCountCheckBox.Checked);
			CollectGameHelpers();
		}

		private void HighlightPencilMarksCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			TheGameBoard.HighlightPencilMarks = HighlightPencilMarksCheckBox.Checked;
			CollectGameHelpers();
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

			int[,] grid = m_generator.CreateBlankGrid();

			// Make a copy of the information entered by the user.
			Buffer.BlockCopy(TheGameBoard.SolutionGrid, 0, grid, 0, TheGameBoard.SolutionGrid.Length * sizeof(int));
			// Put the entered grid into the display slot.
			m_generator.DisplayGrid = TheGameBoard.SolutionGrid;
			// Find the solution to the entered grid.
			m_generator.SolveGrid(ref grid);
			// Save the solution for later verification.
			m_generator.SolutionGrid = grid;

			StartGame(Difficulty.UserSupplied);
		}

		private void savePuzzleToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void HallOfFameToolStripButton_Click(object sender, EventArgs e)
		{
			HighScoresForm iHighScoresForm = new HighScoresForm(m_highScores);
			iHighScoresForm.ShowDialog(this);
		}

		private void SaveHallOfFameEntry()
		{
			int score = m_gameDurationSeconds;
			int scoreAdditions = 0;
			int previousBestTime = m_gamePlayer.BestTime(m_gameDifficulty);
			int previousGamesPayed = m_gamePlayer.NumberOfGamesPlayed(m_gameDifficulty);
			float newAverageTime = 0;
			float previousAverageTime = m_gamePlayer.AverageTime(m_gameDifficulty);
			string message = string.Empty;

			foreach (GameHelper helper in m_gameHelpers)
			{
				scoreAdditions += m_gameDurationSeconds * ((int)helper / 100);
			}

			int finalScore = score + scoreAdditions;

			if (m_gameDifficulty != Difficulty.Unknown && m_gameDifficulty != Difficulty.Restarting && m_gameDifficulty != Difficulty.UserSupplied)
			{
				if (m_gameDurationSeconds < previousBestTime || previousBestTime == 0)
				{
					m_gamePlayer.SetBestTime(m_gameDifficulty, m_gameDurationSeconds);
				}
				if (previousGamesPayed == 0)
				{
					newAverageTime = m_gameDurationSeconds;
					m_gamePlayer.SetNumberOfGamesPlayed(m_gameDifficulty, 1);
					m_gamePlayer.SetAverageTime(m_gameDifficulty, m_gameDurationSeconds);
				}
				else
				{
					newAverageTime = ((previousAverageTime * previousGamesPayed) + m_gameDurationSeconds) / (previousGamesPayed + 1);
					m_gamePlayer.SetAverageTime(m_gameDifficulty, newAverageTime);
					m_gamePlayer.SetNumberOfGamesPlayed(m_gameDifficulty, previousGamesPayed + 1);
				}
			}


			HighScoreEntry newHighScoreEntry = new HighScoreEntry();
			newHighScoreEntry.GameTime = DateTime.Now;
			newHighScoreEntry.PlayerName = m_gamePlayer.PlayerName;
			newHighScoreEntry.GameDifficulty = m_gameDifficulty;
			newHighScoreEntry.DurationSeconds = m_gameDurationSeconds;
			newHighScoreEntry.FinalScore = finalScore;

			if(m_highScores.ContainsKey(m_gameDifficulty))
			{
				m_highScores[m_gameDifficulty].Add(newHighScoreEntry);
			}
			else
			{
				List<HighScoreEntry> highSocreList = new List<HighScoreEntry>(10);
				highSocreList.Add(newHighScoreEntry);
				m_highScores.Add(m_gameDifficulty, highSocreList);
			}

			WriteHighScores();


			message = string.Format("Congratulations, you have solved the puzzle in {0} with a score of {1}.",
									 GetTimeText(m_gameDurationSeconds), finalScore.ToString());

			if (m_gameDurationSeconds < previousBestTime)
			{
				message += string.Format("\r\nBeating your previous best time of {0}.", GetTimeText(previousBestTime));
			}

			if (newAverageTime < previousAverageTime)
			{
				message += string.Format("\r\nImproving your average time from {0} to {1}.", 
										GetTimeText((int)previousAverageTime), GetTimeText((int)newAverageTime));
				
			}
			else
			{
				message += string.Format("\r\nYour average time is {0}.", GetTimeText((int)newAverageTime));
			}

			MessageBox.Show(message);
		}

		public static string GetTimeText(int seconds)
		{
			string timeText = string.Empty;

			if ((seconds / 3600) > 0)
			{
				timeText = (seconds / 3600).ToString("00") + ":" +
						   ((seconds / 60) % 60).ToString("00") + ":" +
						   (seconds % 60).ToString("00");
			}
			else
			{
				timeText = "   " +
						   ((seconds / 60) % 60).ToString("00") + ":" +
						   (seconds % 60).ToString("00");
			}

			return timeText;
		}

		private void SavePuzzle()
		{
		}

		private void LoadPuzzle()
		{
		}

		private void RestartGameButton_Click(object sender, EventArgs e)
		{
			StartGame(Difficulty.Restarting);
		}

		private void GameBoardPanel_Resize(object sender, EventArgs e)
		{
			if (GameBoardPanel.ClientSize.Width > GameBoardPanel.ClientSize.Height - 4)
			{
				TheGameBoard.Width = GameBoardPanel.DisplayRectangle.Height - 4;
				TheGameBoard.Height = GameBoardPanel.ClientSize.Height - 4;
			}
			else
			{
				TheGameBoard.Width = GameBoardPanel.ClientSize.Width;
				TheGameBoard.Height = GameBoardPanel.ClientSize.Width;
			}
			TheGameBoard.Left = (int)(((float)GameBoardPanel.ClientSize.Width / 2.0f) - ((float)TheGameBoard.Width / 2.0f));
		}

		private void PlayersToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (PlayersToolStripComboBox.SelectedItem.ToString() == "New Player")
			{
				GetPlayerName();
			}
			else
			{
				m_gamePlayer = (Player)PlayersToolStripComboBox.SelectedItem;
			}
		}


		/*

//			GeometryFromString(Properties.Settings.Default.WindowGeometry, this);
		
			// persist our geometry string.
//			Properties.Settings.Default.WindowGeometry = GeometryToString(this);
//			Properties.Settings.Default.Save();

		public static void GeometryFromString(string thisWindowGeometry, Form formIn)
		{
			if (string.IsNullOrEmpty(thisWindowGeometry) == true)
			{
				return;
			}
			string[] numbers = thisWindowGeometry.Split('|');
			string windowString = numbers[4];
			if (windowString == "Normal")
			{
				Point windowPoint = new Point(int.Parse(numbers[0]),
					int.Parse(numbers[1]));
				Size windowSize = new Size(int.Parse(numbers[2]),
					int.Parse(numbers[3]));

				bool locOkay = GeometryIsBizarreLocation(windowPoint, windowSize);
				bool sizeOkay = GeometryIsBizarreSize(windowSize);

				if (locOkay == true && sizeOkay == true)
				{
					formIn.Location = windowPoint;
					formIn.Size = windowSize;
					formIn.StartPosition = FormStartPosition.Manual;
					formIn.WindowState = FormWindowState.Normal;
				}
				else if (sizeOkay == true)
				{
					formIn.Size = windowSize;
				}
			}
			else if (windowString == "Maximized")
			{
				formIn.Location = new Point(100, 100);
				formIn.StartPosition = FormStartPosition.Manual;
				formIn.WindowState = FormWindowState.Maximized;
			}
		}

		private static bool GeometryIsBizarreLocation(Point loc, Size size)
		{
			bool locOkay;
			if (loc.X < 0 || loc.Y < 0)
			{
				locOkay = false;
			}
			else if (loc.X + size.Width > Screen.PrimaryScreen.WorkingArea.Width)
			{
				locOkay = false;
			}
			else if (loc.Y + size.Height > Screen.PrimaryScreen.WorkingArea.Height)
			{
				locOkay = false;
			}
			else
			{
				locOkay = true;
			}
			return locOkay;
		}

		private static bool GeometryIsBizarreSize(Size size)
		{
			return (size.Height <= Screen.PrimaryScreen.WorkingArea.Height &&
				size.Width <= Screen.PrimaryScreen.WorkingArea.Width);
		}

		public static string GeometryToString(Form mainForm)
		{
			return mainForm.Location.X.ToString() + "|" +
				mainForm.Location.Y.ToString() + "|" +
				mainForm.Size.Width.ToString() + "|" +
				mainForm.Size.Height.ToString() + "|" +
				mainForm.WindowState.ToString();
		}
		*/
	}
}
