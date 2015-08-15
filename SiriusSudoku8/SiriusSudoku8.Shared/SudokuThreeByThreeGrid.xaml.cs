using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace SiriusSudoku8
{
    public sealed partial class SudokuThreeByThreeGrid : UserControl
    {
		public delegate void CellTapHandler(Position gridPosition, Position cellPosition, int currentNumber);
		public event CellTapHandler OnCellTapped;
		public event CellTapHandler OnCellRightTapped;
		//		public event CellTapHandler OnCellDoubleTapped;

		public delegate void CellClearedHandler(int number, Position gridPosition, Position cellPosition);
		public event CellClearedHandler OnCellCleared;

		public Position GridPosition { set { m_gridPosition = value; } }

		private Position m_gridPosition = null;
		private SudokuGridSquare[,] m_gridSquares = new SudokuGridSquare[3, 3];

		public SudokuThreeByThreeGrid()
		{
			this.InitializeComponent();

			m_gridSquares[0, 0] = Row0Column0;
			m_gridSquares[0, 1] = Row0Column1;
			m_gridSquares[0, 2] = Row0Column2;
			m_gridSquares[1, 0] = Row1Column0;
			m_gridSquares[1, 1] = Row1Column1;
			m_gridSquares[1, 2] = Row1Column2;
			m_gridSquares[2, 0] = Row2Column0;
			m_gridSquares[2, 1] = Row2Column1;
			m_gridSquares[2, 2] = Row2Column2;

			for (int row = 0; row < 3; row++)
			{
				for (int column = 0; column < 3; column++)
				{
					m_gridSquares[row, column].CellPosition = new Position(row, column);
					m_gridSquares[row, column].OnCellTapped += GridCellTapped;
					//m_gridSquares[row, column].OnCellRightTapped += GridCellRightTapped;
					m_gridSquares[row, column].OnCellCleared += GridCellCleared;
				}
			}
		}


		private void SudokuThreeByThreeGrid_Load(object sender, EventArgs e)
		{
		}

		void GridCellTapped(Position cellPosition, int currentNumber)
		{
			if (OnCellTapped != null)
			{
				OnCellTapped(m_gridPosition, cellPosition, currentNumber);
			}
		}

		void GridCellRightTapped(Position cellPosition, int currentNumber)
		{
			if (OnCellRightTapped != null)
			{
				OnCellRightTapped(m_gridPosition, cellPosition, currentNumber);
			}
		}

		void GridCellCleared(int number, Position cellPosition)
		{
			if (OnCellCleared != null)
			{
				OnCellCleared(number, m_gridPosition, cellPosition);
			}
		}

		public void ClearGrid()
		{
			for (int row = 0; row < 3; row++)
			{
				for (int column = 0; column < 3; column++)
				{
					m_gridSquares[row, column].ClearCell();
				}
			}
		}

		public int NumberSelected
		{
			set
			{
				for (int row = 0; row < 3; row++)
				{
					for (int column = 0; column < 3; column++)
					{
						m_gridSquares[row, column].NumberSelected = value;
					}
				}
			}
		}

		public void ShowErrors(Position cellPosition, bool showErrors)
		{
			if (cellPosition.Row < 0 || cellPosition.Row > 2)
			{
				throw new Exception("ShowErrors() - Row index out of range.");
			}
			else if (cellPosition.Column < 0 || cellPosition.Column > 2)
			{
				throw new Exception("ShowErrors() - Column index out of range.");
			}
			else
			{
				m_gridSquares[cellPosition.Row, cellPosition.Column].ShowErrors = showErrors;
			}
		}

		public void HighlightPencilMarks(Position cellPosition, bool highlight)
		{
			if (cellPosition.Row < 0 || cellPosition.Row > 2)
			{
				throw new Exception("highlightPencilMarks() - Row index out of range.");
			}
			else if (cellPosition.Column < 0 || cellPosition.Column > 2)
			{
				throw new Exception("highlightPencilMarks() - Column index out of range.");
			}
			else
			{
				m_gridSquares[cellPosition.Row, cellPosition.Column].HighlightPencils = highlight;
			}
		}

		public int CellValue(Position cellPosition)
		{
			if (cellPosition.Row < 0 || cellPosition.Row > 2)
			{
				throw new Exception("CellValue() - Row index out of range.");
			}
			else if (cellPosition.Column < 0 || cellPosition.Column > 2)
			{
				throw new Exception("CellValue() - Column index out of range.");
			}
			else
			{
				return m_gridSquares[cellPosition.Row, cellPosition.Column].Number;
			}
		}

		public void ClearNumber(Position cellPosition)
		{
			if (cellPosition.Row < 0 || cellPosition.Row > 2)
			{
				throw new Exception("ClearNumber() - Row index out of range.");
			}
			else if (cellPosition.Column < 0 || cellPosition.Column > 2)
			{
				throw new Exception("ClearNumber() - Column index out of range.");
			}
			else
			{
				m_gridSquares[cellPosition.Row, cellPosition.Column].ClearCell();
			}
		}

		public bool SetGivenNumber(Position cellPosition, int number)
		{
			if (number < 1 || number > 9)
			{
				throw new Exception("SetGivenNumber() - Number out of range.");
			}
			else if (cellPosition.Row < 0 || cellPosition.Row > 2)
			{
				throw new Exception("SetGivenNumber() - Row index out of range.");
			}
			else if (cellPosition.Column < 0 || cellPosition.Column > 2)
			{
				throw new Exception("SetGivenNumber() - Column index out of range.");
			}
			else
			{
				return m_gridSquares[cellPosition.Row, cellPosition.Column].SetGivenNumber(number);
			}
		}

		public bool SetUserNumber(Position cellPosition, int number, bool numberIsCorrect)
		{
			if (number < 1 || number > 9)
			{
				throw new Exception("SetUserNumber() - Number out of range.");
			}
			else if (cellPosition.Row < 0 || cellPosition.Row > 2)
			{
				throw new Exception("SetUserNumber() - Row index out of range.");
			}
			else if (cellPosition.Column < 0 || cellPosition.Column > 2)
			{
				throw new Exception("SetUserNumber() - Column index out of range.");
			}
			else
			{
				return m_gridSquares[cellPosition.Row, cellPosition.Column].SetUserNumber(number, numberIsCorrect);
			}
		}

		public void TogglePencilledInNumber(int number, Position cellPosition)
		{
			if (number < 1 || number > 9)
			{
				throw new Exception("TogglePencilledInNumber() - Number out of range.");
			}
			else if (cellPosition.Row < 0 || cellPosition.Row > 2)
			{
				throw new Exception("TogglePencilledInNumber() - Row index out of range.");
			}
			else if (cellPosition.Column < 0 || cellPosition.Column > 2)
			{
				throw new Exception("TogglePencilledInNumber() - Column index out of range.");
			}
			else
			{
				m_gridSquares[cellPosition.Row, cellPosition.Column].TogglePencilledInNumber(number);
			}
		}
    }
}
