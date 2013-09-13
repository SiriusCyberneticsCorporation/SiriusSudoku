using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiriusSudoku
{
	class CellWithChoices
	{
		public int Row;
		public int Column;
		public List<int> Choices = new List<int>();
		public int Count { get { return Choices.Count; } }
	}

	class SudokuGenerator
	{
		int m_gameSize = -1;
		bool m_doneIterating = false;
		int[] m_possibleChoices = null;
		int[,] m_solutionGrid = null;
		int[,] m_displayGrid = null;
		Random m_randomiser = null;

		public int[,] SolutionGrid { get { return m_solutionGrid; } set { m_solutionGrid = value; } }
		public int[,] DisplayGrid { get { return m_displayGrid; } set { m_displayGrid = value; } }

		public SudokuGenerator(int gameSize)
		{
			if ((gameSize % 3) != 0)
			{
				throw new Exception("GenerateGrid(int gameSize) - gameSize is not a multiple of three.");
			}

			m_gameSize = gameSize;
			m_randomiser = new Random(DateTime.Now.Millisecond);
			m_possibleChoices = new int[m_gameSize];

			// Initialise the array of possible values.
			for (int i = 0; i < m_gameSize; i++)
			{
				m_possibleChoices[i] = i + 1;
			}
		}

		public int[,] CreateBlankGrid()
		{
			return new int[m_gameSize, m_gameSize];
		}
		
		public void GenerateSudokuGrid(Difficulty gameDifficulty)
		{
			m_solutionGrid = GenerateSolution();
			m_displayGrid = CreateBlankGrid();

			Buffer.BlockCopy(m_solutionGrid, 0, m_displayGrid, 0, m_solutionGrid.Length * sizeof(int));
			GenerateDisplayGrid(gameDifficulty, ref m_displayGrid);
		}

		public void SolveGrid(ref int[,] grid)
		{
			int[,] temporaryGrid = null;
			
			m_doneIterating = false;
			
			for(int i = 0; i < 100; i++)
			{
				temporaryGrid = new int[m_gameSize, m_gameSize];
				Buffer.BlockCopy(grid, 0, temporaryGrid, 0, grid.Length * sizeof(int));
				
				if (IterativelyFillGrid(temporaryGrid) || m_doneIterating)
				{
					Buffer.BlockCopy(temporaryGrid, 0, grid, 0, grid.Length * sizeof(int));
					break;
				}
			}
		}

		private int[,] GenerateSolution()
		{
			int[,] grid = CreateBlankGrid();

			// The grid is empty so all choices are possible.
			List<int> choices = new List<int>(m_possibleChoices);

			// Start by filling in the top row of the grid - all squares chosen at random.
			for (int column = 0; column < m_gameSize; column++)
			{
				int index = m_randomiser.Next(0, choices.Count);
				FillGridSpot(grid, 0, column, choices[index]);
				choices.RemoveAt(index);
			}

			// Now fill in the left most column, skipping the first row.
			for (int row = 1; row < m_gameSize; row++)
			{
				choices = PossibleChoices(grid, row, 0);
				int index = m_randomiser.Next(0, choices.Count);
				FillGridSpot(grid, row, 0, choices[index]);
				choices.RemoveAt(index);
			}

			SolveGrid(ref grid);

			return grid;
		}

		private void GenerateDisplayGrid(Difficulty gameDifficulty, ref int[,] grid)
		{
			int numberOfBlanks = 0;
			int minimumNumbersPerRowColumn = 0;

			switch (gameDifficulty)
			{
				case Difficulty.TooEasy:
					numberOfBlanks = m_randomiser.Next(26, 32);
					minimumNumbersPerRowColumn = 5;
					break;
				case Difficulty.Easy:
					numberOfBlanks = m_randomiser.Next(32, 46);
					minimumNumbersPerRowColumn = 4;
					break;
				case Difficulty.Medium:
					numberOfBlanks = m_randomiser.Next(46, 50);
					minimumNumbersPerRowColumn = 3;
					break;
				case Difficulty.Hard:
					numberOfBlanks = m_randomiser.Next(50, 54);
					minimumNumbersPerRowColumn = 2;
					break;
				case Difficulty.Extreme:
					numberOfBlanks = m_randomiser.Next(54, 59);
					minimumNumbersPerRowColumn = 0;
					break;
				default:
					numberOfBlanks = m_randomiser.Next(26, 32);
					minimumNumbersPerRowColumn = 5;
					break;
			}

			int[,] workingGrid = CreateBlankGrid();

			do
			{
				// Make a working copy of the grid.
				Buffer.BlockCopy(grid, 0, workingGrid, 0, workingGrid.Length * sizeof(int));

				List<Position> allPositions = new List<Position>();
				for (int row = 0; row < 9; row++)
				{
					for (int column = 0; column < 9; column++)
					{
						allPositions.Add(new Position(row, column));
					}
				}

				int blanksCount = 0;
				while (blanksCount < numberOfBlanks)
				{
					int index = m_randomiser.Next(allPositions.Count);

					if (index >= allPositions.Count)
					{
						break;
					}
					int row = allPositions[index].Row;
					int column = allPositions[index].Column;

					if (RowCount(row, workingGrid) > minimumNumbersPerRowColumn && ColumnCount(column, workingGrid) > minimumNumbersPerRowColumn)
					{
						int gridValue = workingGrid[row, column];

						workingGrid[row, column] = 0;

						if (IsUnique(workingGrid))
						{
							blanksCount++;
						}
						else
						{
							workingGrid[row, column] = gridValue;
						}
					}
					allPositions.RemoveAt(index);
				}
			} while (!IsUnique(workingGrid));

			Buffer.BlockCopy(workingGrid, 0, grid, 0, grid.Length * sizeof(int));
		}

		private int RowCount(int row, int[,] grid)
		{
			int rowCount = 0;

			for (int column = 0; column < 9; column++)
			{
				if (grid[row, column] > 0)
				{
					rowCount++;
				}
			}

			return rowCount;
		}

		private int ColumnCount(int column, int[,] grid)
		{
			int columnCount = 0;

			for (int row = 0; row < 9; row++)
			{
				if (grid[row, column] > 0)
				{
					columnCount++;
				}
			}

			return columnCount;
		}

		private bool IterativelyFillGrid(int[,] solutionGrid)
		{
			bool gridFilled = true;
			bool exitLoop = false;
			int shortestList = int.MaxValue;
			CellWithChoices bestCell = null;

			for (int row = 0; row < m_gameSize; row++)
			{
				for (int column = 0; column < m_gameSize; column++)
				{
					if (solutionGrid[row, column] == 0)
					{
						gridFilled = false;
						List<int> choices = PossibleChoices(solutionGrid, row, column);
						if (choices.Count == 0)
						{
							// No Solution
							exitLoop = true;
							break;
						}
						else if (choices.Count == 1)
						{
							// Not going to get much shorter that one!
							bestCell = new CellWithChoices();
							bestCell.Row = row;
							bestCell.Column = column;
							bestCell.Choices = choices;
							exitLoop = true;
							break;
						}
						else if (choices.Count < shortestList)
						{
							shortestList = choices.Count;
							bestCell = new CellWithChoices();
							bestCell.Row = row;
							bestCell.Column = column;
							bestCell.Choices = choices;
						}
					}
				}
				if (exitLoop)
				{
					break;
				}
			}

			if (bestCell != null)
			{
				foreach (int possibleValue in bestCell.Choices)
				{
					FillGridSpot(solutionGrid, bestCell.Row, bestCell.Column, possibleValue);

					if (IsFull(solutionGrid))
					{
						m_doneIterating = true;
						break;
					}
					IterativelyFillGrid(solutionGrid);
					if (!m_doneIterating)
					{
						FillGridSpot(solutionGrid, bestCell.Row, bestCell.Column, 0);
					}
					else
					{
						break;
					}
				}
			}

			return gridFilled;
		}

		public bool IsFull(int[,] solutionGrid)
		{
			bool result = true;
			for (int row = 0; row < 9; row++)
			{
				for (int col = 0; col < 9; col++)
				{
					if (solutionGrid[row,col] == 0)
					{
						return false;
					}
				}
			}
			return result;
		}

		private void FillGridSpot(int [,] grid, int row, int column, int value)
		{
			grid[row, column] = value;
		}

		private List<int> PossibleChoices(int[,] grid, int row, int column)
		{
			int sqRow = ((int)row / 3) * 3;
			int sqCol = ((int)column / 3) * 3;
			List<int> existingValues = new List<int>();
			List<int> choices = new List<int>();

			for(int i = 0; i < m_gameSize; i++)
			{
				// Add all non-zero row values. 
				if(grid[row,i] > 0)
				{
					existingValues.Add(grid[row,i]);
				}
				// Add all non-zero column values. 
				if(grid[i, column] > 0)
				{
					existingValues.Add(grid[i, column]);
				}
			}

			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (grid[i + sqRow, j + sqCol] > 0)
					{
						existingValues.Add(grid[i + sqRow, j + sqCol]);
					}
				}
			}

			foreach (int choice in m_possibleChoices)
			{
				if (!existingValues.Contains(choice))
				{
					choices.Add(choice);
				}
			}
			
			return choices;
		}

		private enum Ret { Unique, NotUnique, NoSolution };

		internal struct EntryPoint
		{
			public int x, y;
			public EntryPoint(int x, int y)
			{
				this.x = x;
				this.y = y;
			}
		}

		// Maps sub square index to m_sudoku
		private readonly EntryPoint[,] m_subIndex =
			new EntryPoint[,]
			{
				{ new EntryPoint(0,0),new EntryPoint(0,1),new EntryPoint(0,2),new EntryPoint(1,0),new EntryPoint(1,1),new EntryPoint(1,2),new EntryPoint(2,0),new EntryPoint(2,1),new EntryPoint(2,2)},
				{ new EntryPoint(0,3),new EntryPoint(0,4),new EntryPoint(0,5),new EntryPoint(1,3),new EntryPoint(1,4),new EntryPoint(1,5),new EntryPoint(2,3),new EntryPoint(2,4),new EntryPoint(2,5)},
				{ new EntryPoint(0,6),new EntryPoint(0,7),new EntryPoint(0,8),new EntryPoint(1,6),new EntryPoint(1,7),new EntryPoint(1,8),new EntryPoint(2,6),new EntryPoint(2,7),new EntryPoint(2,8)},
				{ new EntryPoint(3,0),new EntryPoint(3,1),new EntryPoint(3,2),new EntryPoint(4,0),new EntryPoint(4,1),new EntryPoint(4,2),new EntryPoint(5,0),new EntryPoint(5,1),new EntryPoint(5,2)},
				{ new EntryPoint(3,3),new EntryPoint(3,4),new EntryPoint(3,5),new EntryPoint(4,3),new EntryPoint(4,4),new EntryPoint(4,5),new EntryPoint(5,3),new EntryPoint(5,4),new EntryPoint(5,5)},
				{ new EntryPoint(3,6),new EntryPoint(3,7),new EntryPoint(3,8),new EntryPoint(4,6),new EntryPoint(4,7),new EntryPoint(4,8),new EntryPoint(5,6),new EntryPoint(5,7),new EntryPoint(5,8)},
				{ new EntryPoint(6,0),new EntryPoint(6,1),new EntryPoint(6,2),new EntryPoint(7,0),new EntryPoint(7,1),new EntryPoint(7,2),new EntryPoint(8,0),new EntryPoint(8,1),new EntryPoint(8,2)},
				{ new EntryPoint(6,3),new EntryPoint(6,4),new EntryPoint(6,5),new EntryPoint(7,3),new EntryPoint(7,4),new EntryPoint(7,5),new EntryPoint(8,3),new EntryPoint(8,4),new EntryPoint(8,5)},
				{ new EntryPoint(6,6),new EntryPoint(6,7),new EntryPoint(6,8),new EntryPoint(7,6),new EntryPoint(7,7),new EntryPoint(7,8),new EntryPoint(8,6),new EntryPoint(8,7),new EntryPoint(8,8)}
		};

		// Maps sub square to index
		private readonly byte[,] m_subSquare =
			new byte[,]
			{
				{0,0,0,1,1,1,2,2,2},
				{0,0,0,1,1,1,2,2,2},
				{0,0,0,1,1,1,2,2,2},
				{3,3,3,4,4,4,5,5,5},
				{3,3,3,4,4,4,5,5,5},
				{3,3,3,4,4,4,5,5,5},
				{6,6,6,7,7,7,8,8,8},
				{6,6,6,7,7,7,8,8,8},
				{6,6,6,7,7,7,8,8,8}
		};

		public bool IsUnique(int[,] grid)
		{
			return TestUniqueness(grid) == Ret.Unique;
		}

		// Is there one and only one solution?
		private Ret TestUniqueness(int[,] grid)
		{
			// Find untouched location with most information
			int xp = 0;
			int yp = 0;
			byte[] Mp = null;
			int cMp = 10;

			for (int row = 0; row < 9; row++)
			{
				for (int column = 0; column < 9; column++)
				{
					// Is this spot unused?
					if (grid[row, column] == 0)
					{
						// Set M of possible solutions
						byte[] M = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

						// Remove used numbers in the vertical direction
						for (int a = 0; a < 9; a++)
						{
							M[grid[a, column]] = 0;
						}

						// Remove used numbers in the horizontal direction
						for (int b = 0; b < 9; b++)
						{
							M[grid[row, b]] = 0;
						}

						// Remove used numbers in the sub square.
						int squareIndex = m_subSquare[row, column];
						for (int c = 0; c < 9; c++)
						{
							EntryPoint p = m_subIndex[squareIndex, c];
							M[grid[p.x, p.y]] = 0;
						}

						int cM = 0;
						// Calculate cardinality of M
						for (int d = 1; d < 10; d++)
						{
							cM += M[d] == 0 ? 0 : 1;
						}

						// Is there more information in this spot than in the best yet?
						if (cM < cMp)
						{
							cMp = cM;
							Mp = M;
							xp = column;
							yp = row;
						}
					}
				}
			}

			// Finished?
			if (cMp == 10)
			{
				return Ret.Unique;
			}

			// Couldn't find a solution?
			if (cMp == 0)
			{
				return Ret.NoSolution;
			}

			// Try elements
			int success = 0;
			for (int i = 1; i < 10; i++)
			{
				if (Mp[i] != 0)
				{
					grid[yp, xp] = Mp[i];

					switch (TestUniqueness(grid))
					{
						case Ret.Unique:
							success++;
							break;

						case Ret.NotUnique:
							grid[yp, xp] = 0;
							return Ret.NotUnique;

						case Ret.NoSolution:
							grid[yp, xp] = 0;
							break;
					}

					// More than one solution found?
					if (success > 1)
					{
						grid[yp, xp] = 0;
						return Ret.NotUnique;
					}
				}
			}

			// Restore to original state.
			grid[yp, xp] = 0;

			switch (success)
			{
				case 0:
					return Ret.NoSolution;

				case 1:
					return Ret.Unique;

				default:
					// Won't happen.
					return Ret.NotUnique;
			}
		}
	}

}
