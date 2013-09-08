using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SiriusSudoku
{
	public partial class SudokuGameBoard : UserControl
	{
		public delegate void CellTapHandler(Position gridPosition, Position cellPosition);
		public event CellTapHandler OnCellTapped;
		//		public event CellTapHandler OnCellDoubleTapped;

		public delegate void CellClearedHandler(int number, Position gridPosition, Position cellPosition);
		public event CellClearedHandler OnCellCleared;

		public int GridSize { get { return m_gridSize; } set { m_gridSize = value; } }
		public int NumberSelected { get { return m_numberSelected; } set { m_numberSelected = value; } }
		public bool PencillingIn { set { m_pencillingIn = value; } }
		public bool Erasing { set { m_erasing = value; } }
		public int[] SuppliedNumberCount { get { return m_suppliedNumberCount; } }
		public int[,] SolutionGrid { get { return m_solutionGrid; } set { m_solutionGrid = value; } }

		private static int m_gridSize = 9;

		private int m_numberSelected = -1;
		private int m_numberCountLimit = m_gridSize;
		private bool m_pencillingIn = false;
		private bool m_erasing = false;
		private bool m_showErrors = false;
		private int[] m_suppliedNumberCount = null;
		private int[,] m_solutionGrid = null;
		private Random m_randomiser = new Random(DateTime.Now.Millisecond);
		private SudokuThreeByThreeGrid[,] m_theGrids = new SudokuThreeByThreeGrid[3, 3];

		public SudokuGameBoard()
		{
			InitializeComponent();

			m_theGrids[0, 0] = Grid00;
			m_theGrids[0, 1] = Grid01;
			m_theGrids[0, 2] = Grid02;
			m_theGrids[1, 0] = Grid10;
			m_theGrids[1, 1] = Grid11;
			m_theGrids[1, 2] = Grid12;
			m_theGrids[2, 0] = Grid20;
			m_theGrids[2, 1] = Grid21;
			m_theGrids[2, 2] = Grid22;

			for (int row = 0; row < 3; row++)
			{
				for (int column = 0; column < 3; column++)
				{
					m_theGrids[row, column].GridPosition = new Position(row, column);
					m_theGrids[row, column].OnCellTapped += GridCellTapped;
					m_theGrids[row, column].OnCellRightTapped += GridCellRightTapped;
					m_theGrids[row, column].OnCellCleared += GridCellCleared;
				}
			}

			m_suppliedNumberCount = new int[m_gridSize];
		}

		public bool ShowErrors
		{
			get { return m_showErrors; }
			set
			{
				m_showErrors = value;
				for (int row = 0; row < m_gridSize; row++)
				{
					for (int column = 0; column < m_gridSize; column++)
					{
						int gridRow = row / 3;
						int gridColumn = column / 3;

						m_theGrids[gridRow, gridColumn].ShowErrors(new Position(row % 3, column % 3), m_showErrors);
					}
				}
			}
		}

		public bool IsSolutionCorrect()
		{
			if (m_solutionGrid != null)
			{
				for (int row = 0; row < m_gridSize; row++)
				{
					for (int column = 0; column < m_gridSize; column++)
					{
						int gridRow = row / 3;
						int gridColumn = column / 3;
						if (m_theGrids[gridRow, gridColumn].CellValue(new Position(row % 3, column % 3)) != m_solutionGrid[row, column])
						{
							return false;
						}
					}
				}
				return true;
			}
			return false;
		}

		public void DisplayGrid(Difficulty gameDifficulty)
		{
			if (gameDifficulty == Difficulty.UserSupplied)
			{
				for (int row = 0; row < 9; row++)
				{
					for (int column = 0; column < 9; column++)
					{
						int gridRow = row / 3;
						int gridColumn = column / 3;
						int value = m_solutionGrid[row, column];

						if (value > 0)
						{
							SetGivenNumber(new Position(gridRow, gridColumn), new Position(row % 3, column % 3), value);
						}
					}
				}
			}
			else
			{
				List<Position> allPositions = new List<Position>();
				for (int row = 0; row < m_gridSize; row++)
				{
					for (int column = 0; column < m_gridSize; column++)
					{
						allPositions.Add(new Position(row, column));
					}
				}

				for (int i = 0; i < (int)gameDifficulty; i++)
				{
					int index = m_randomiser.Next(allPositions.Count);

					int row = allPositions[index].Row;
					int column = allPositions[index].Column;
					int gridRow = row / 3;
					int gridColumn = column / 3;
					int value = m_solutionGrid[row, column];

					allPositions.RemoveAt(index);

					SetGivenNumber(new Position(gridRow, gridColumn), new Position(row % 3, column % 3), value);
				}
			}
		}

		private void SudokuGameBoard_Load(object sender, EventArgs e)
		{

		}


		void GridCellTapped(Position gridPosition, Position cellPosition)
		{
			if (m_solutionGrid != null && m_numberSelected > 0)
			{
				if (m_pencillingIn)
				{
					TogglePencilledInNumber(gridPosition, m_numberSelected, cellPosition);
				}
				else if (m_erasing)
				{
					ClearGridNumber(gridPosition, cellPosition);
				}
				else
				{
					SetUserNumber(gridPosition, cellPosition, m_numberSelected);
				}
				if (OnCellTapped != null)
				{
					OnCellTapped(gridPosition, cellPosition);
				}
			}
		}

		void GridCellRightTapped(Position gridPosition, Position cellPosition)
		{
			if (m_numberSelected > 0)
			{
				TogglePencilledInNumber(gridPosition, m_numberSelected, cellPosition);
			}
		}

		void GridCellCleared(int number, Position gridPosition, Position cellPosition)
		{
			if (m_suppliedNumberCount[number - 1] > 0)
			{
				m_suppliedNumberCount[number - 1]--;
			}
			if (OnCellCleared != null)
			{
				OnCellCleared(number, gridPosition, cellPosition);
			}
		}

		public void ClearGrid()
		{
			m_suppliedNumberCount = new int[m_gridSize];

			for (int row = 0; row < 3; row++)
			{
				for (int column = 0; column < 3; column++)
				{
					m_theGrids[row, column].ClearGrid();
				}
			}
		}

		public int GridCellValue(Position gridPosition, Position cellPosition)
		{
			if (gridPosition.Row < 0 || gridPosition.Row > 2)
			{
				throw new Exception("GridCellValue() - Row index out of range.");
			}
			else if (gridPosition.Column < 0 || gridPosition.Column > 2)
			{
				throw new Exception("GridCellValue() - Column index out of range.");
			}
			else
			{
				return m_theGrids[gridPosition.Row, gridPosition.Column].CellValue(cellPosition);
			}
		}


		public void ClearGridNumber(Position gridPosition, Position cellPosition)
		{
			if (gridPosition.Row < 0 || gridPosition.Row > 2)
			{
				throw new Exception("ClearGridNumber() - Row index out of range.");
			}
			else if (gridPosition.Column < 0 || gridPosition.Column > 2)
			{
				throw new Exception("ClearGridNumber() - Column index out of range.");
			}
			else
			{
				int cellNumber = GridCellValue(gridPosition, cellPosition);
				if (cellNumber > 0)
				{
					if (m_suppliedNumberCount[cellNumber - 1] > 0)
					{
						m_suppliedNumberCount[cellNumber - 1]--;
					}
					m_theGrids[gridPosition.Row, gridPosition.Column].ClearNumber(cellPosition);
					if (OnCellCleared != null)
					{
						OnCellCleared(cellNumber, gridPosition, cellPosition);
					}
				}
			}
		}

		public void SetGivenNumber(Position gridPosition, Position cellPosition, int number)
		{
			if (number < 1 || number > m_gridSize)
			{
				throw new Exception("SetGivenNumber() - Number out of range.");
			}
			else if (gridPosition.Row < 0 || gridPosition.Row > 2)
			{
				throw new Exception("SetGivenNumber() - Row index out of range.");
			}
			else if (gridPosition.Column < 0 || gridPosition.Column > 2)
			{
				throw new Exception("SetGivenNumber() - Column index out of range.");
			}
			else
			{
				if (m_suppliedNumberCount[number - 1] < m_numberCountLimit)
				{
					if (m_theGrids[gridPosition.Row, gridPosition.Column].SetGivenNumber(cellPosition, number))
					{
						m_suppliedNumberCount[number - 1]++;
					}
				}
			}
		}

		public void SetUserNumber(Position gridPosition, Position cellPosition, int number)
		{
			if (number < 1 || number > m_gridSize)
			{
				throw new Exception("SetUserNumber() - Number out of range.");
			}
			else if (gridPosition.Row < 0 || gridPosition.Row > 2)
			{
				throw new Exception("SetUserNumber() - Row index out of range.");
			}
			else if (gridPosition.Column < 0 || gridPosition.Column > 2)
			{
				throw new Exception("SetUserNumber() - Column index out of range.");
			}
			else
			{
				if (m_suppliedNumberCount[number - 1] < m_numberCountLimit)
				{
					int row = gridPosition.Row * 3 + cellPosition.Row;
					int column = gridPosition.Column * 3 + cellPosition.Column;
					bool numberIsCorrect = m_solutionGrid[row, column] == number;
					if (m_theGrids[gridPosition.Row, gridPosition.Column].SetUserNumber(cellPosition, number, numberIsCorrect))
					{
						m_suppliedNumberCount[number - 1]++;
					}
				}
			}
		}

		public void TogglePencilledInNumber(Position gridPosition, int number, Position cellPosition)
		{
			if (number < 1 || number > m_gridSize)
			{
				throw new Exception("TogglePencilledInNumber() - Number out of range.");
			}
			else if (gridPosition.Row < 0 || gridPosition.Row > 2)
			{
				throw new Exception("TogglePencilledInNumber() - Row index out of range.");
			}
			else if (gridPosition.Column < 0 || gridPosition.Column > 2)
			{
				throw new Exception("TogglePencilledInNumber() - Column index out of range.");
			}
			else
			{
				m_theGrids[gridPosition.Row, gridPosition.Column].TogglePencilledInNumber(number, cellPosition);
			}
		}
	}
}
