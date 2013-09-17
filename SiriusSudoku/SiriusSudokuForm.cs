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
using System.Xml;
using System.Xml.Serialization;

namespace SiriusSudoku
{
	public partial class SiriusSudokuForm : Form
	{
		private const string PLAYERS_FILE = "Players.xml";
		private const string SETTINGS_FILE = "SiriusSudoku.txt";

		private bool m_gameActive = false;
		private bool m_gamePaused = false;
		private bool m_firstMoveMade = false;
		private bool m_enteringPuzzle = false;
		private int m_gameDurationSeconds = 0;
		SudokuGenerator m_generator = null;
		List<Player> m_players = new List<Player>();
		List<GameHelper> m_gameHelpers = new List<GameHelper>();

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
			/*
			if (File.Exists(PLAYERS_FILE))
			{
				FileStream playersFileStream = new FileStream(PLAYERS_FILE, FileMode.Open);
				XmlSerializer playerListSerialiser = new XmlSerializer(typeof(List<Player>));

				m_players = (List<Player>)playerListSerialiser.Deserialize(playersFileStream);
			}
			else
			{
				Player p1 = new Player();
				p1.PlayerName = "Richard";
				p1.AverageTimes.Add(Difficulty.Easy, 1);
				p1.AverageTimes.Add(Difficulty.Medium, 2);
				p1.AverageTimes.Add(Difficulty.Hard, 3);
				p1.AverageTimes.Add(Difficulty.Extreme, 4);
				
				m_players.Add(p1);

				Player p2 = new Player();
				p2.PlayerName = "Blake";
				p2.AverageTimes.Add(Difficulty.Easy, 10);
				p2.AverageTimes.Add(Difficulty.Medium, 20);
				p2.AverageTimes.Add(Difficulty.Hard, 30);
				p2.AverageTimes.Add(Difficulty.Extreme, 40);

				m_players.Add(p2);
			}
			*/
		}

		private void WritePlayers()
		{
			/*
			TextWriter writer = new StreamWriter(PLAYERS_FILE, false);
			XmlSerializer playerListSerialiser = new XmlSerializer(typeof(List<Player>));

			playerListSerialiser.Serialize(writer, m_players);
			*/
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

		private void StartNewGame(Difficulty gameDifficulty)
		{
			Cursor = Cursors.WaitCursor;

			m_generator.GenerateSudokuGrid(gameDifficulty);

			StartGame(gameDifficulty);

			Cursor = Cursors.Default;
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

		}

		private void SaveHallOfFameEntry()
		{
			int score = m_gameDurationSeconds;
			int scoreAdditions = 0;

			foreach (GameHelper helper in m_gameHelpers)
			{
				scoreAdditions += m_gameDurationSeconds * ((int)helper / 100);
			}
						
			int finalScore = score + scoreAdditions;


			/*
			Book introToVCS = new Book();
			System.Xml.Serialization.XmlSerializer reader = new
			   System.Xml.Serialization.XmlSerializer(introToVCS.GetType());

			// Read the XML file.
			System.IO.StreamReader file =
			   new System.IO.StreamReader("c:\\IntroToVCS.xml");

			// Deserialize the content of the file into a Book object.
			introToVCS = (Book)reader.Deserialize(file);
			System.Windows.Forms.MessageBox.Show(introToVCS.title,
			   "Book Title");
			*/

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
