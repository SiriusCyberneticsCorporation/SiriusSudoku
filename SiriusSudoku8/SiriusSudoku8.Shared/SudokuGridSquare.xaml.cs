using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class SudokuGridSquare : UserControl
    {
        public SudokuGridSquare()
        {
            this.InitializeComponent();
		}

		public delegate void CellTapHandler(Position cellPosition, int currentNumber);
		public event CellTapHandler OnCellTapped;
//		public event CellTapHandler OnCellRightTapped;
		public event CellTapHandler OnCellDoubleTapped;

		public delegate void CellClearedHandler(int number, Position cellPosition);
		public event CellClearedHandler OnCellCleared;

		public int Number { get { return m_number; } }

		public int NumberSelected { set { m_numberSelected = value; UpdateLayout(); } }

		public Position CellPosition { set { m_cellPosition = value; } }

		public void ClearCell()
		{
			m_number = -1;
			m_numberSelected = -1;
			m_selected = false;
//			m_inLineWithSelected = false;
			m_sameNumberAsSelected = false;
			m_numberGiven = false;
			m_numberIsCorrect = true;
			m_numberProvidedByPlayer = false;
			m_numbersPencilled = new List<int>();

			UpdateLayout();
		}

		public bool SetGivenNumber(int number)
		{
			if (number < 1 || number > 9)
			{
				throw new Exception("SetGivenNumber() - Number out of range.");
			}
			else if (m_number <= 0)
			{
				m_number = number;
				m_numberGiven = true;
				UpdateLayout();
				return true;
			}
			return false;
		}

		public bool SetUserNumber(int number, bool numberIsCorrect)
		{
			if (number < 1 || number > 9)
			{
				throw new Exception("SetGivenNumber() - Number out of range.");
			}
			else if (m_numberGiven)
			{
				throw new Exception("SetUserNumber() - This square already has a given number.");
			}
			else if (m_number <= 0)
			{
				m_number = number;
				m_numberIsCorrect = numberIsCorrect;
				m_numberProvidedByPlayer = true;
				UpdateLayout();
				return true;
			}
			return false;
		}

		public void TogglePencilledInNumber(int number)
		{
			if (number < 1 || number > 9)
			{
				throw new Exception("PencilInNumber() - Number out of range.");
			}
			else if (m_numberGiven)
			{
				return;
				//throw new Exception("PencilInNumber() - This square has a given number.");
			}

			if (m_numbersPencilled.Contains(number))
			{
				m_numbersPencilled.Remove(number);
			}
			else
			{
				m_numbersPencilled.Add(number);
			}
			UpdateLayout();
		}

		public bool ShowErrors
		{
			get { return m_showErrors; }
			set
			{
				m_showErrors = value;
				UpdateLayout();
			}
		}

		public bool HighlightPencils
		{
			get { return m_highlightPencils; }
			set
			{
				m_highlightPencils = value;
				UpdateLayout();
			}
		}

		private int m_number = -1;
		private int m_numberSelected = -1;
		private bool m_selected = false;
//		private bool m_inLineWithSelected = false;
		private bool m_sameNumberAsSelected = false;
		private bool m_showErrors = false;
		private bool m_highlightPencils = false;
		private bool m_numberGiven = false;
		private bool m_numberIsCorrect = true;
		private bool m_numberProvidedByPlayer = false;
		private List<int> m_numbersPencilled = new List<int>();
		private Position m_cellPosition = null;

		private SolidColorBrush m_textBrush = new SolidColorBrush(Colors.Black);
		private SolidColorBrush m_givenTextBrush = new SolidColorBrush(Colors.Navy);
		private SolidColorBrush m_pencilTextBrush = new SolidColorBrush(Colors.DarkGray);
		private SolidColorBrush m_highlightedPencilTextBrush = new SolidColorBrush(Colors.Red);
		private SolidColorBrush m_borderBrush = new SolidColorBrush(Colors.DarkGray);
		private SolidColorBrush m_incorrectNumberBrush = new SolidColorBrush(Colors.Red);
		private SolidColorBrush m_defaultBackgroundBrush = new SolidColorBrush(Colors.White);
		private SolidColorBrush m_givenNumberBackgroundBrush = new SolidColorBrush(Color.FromArgb(20, 20, 20, 20));
		private SolidColorBrush m_numberProvidedByPlayerBackgroundBrush = new SolidColorBrush(Colors.White);
		private SolidColorBrush m_selectedBackgroundBrush = new SolidColorBrush(Colors.DeepSkyBlue);
		private SolidColorBrush m_sameNumberAsSelectedBackgroundBrush = new SolidColorBrush(Colors.DeepSkyBlue);
		private SolidColorBrush m_inLineWithSelectedBackgroundBrush = new SolidColorBrush(Color.FromArgb(100, 250, 250, 0));

		private void UserControl_LayoutUpdated(object sender, object e)
		{
			if (m_numberGiven)
			{
				NumberGrid.Background = m_givenNumberBackgroundBrush;
			}
			else if (m_numberProvidedByPlayer)
			{
				NumberGrid.Background = m_numberProvidedByPlayerBackgroundBrush;
			}
			else if (m_selected)
			{
				NumberGrid.Background = m_selectedBackgroundBrush;
			}
			else if (m_sameNumberAsSelected)
			{
				NumberGrid.Background = m_sameNumberAsSelectedBackgroundBrush;
			}
			else
			{
				NumberGrid.Background = m_defaultBackgroundBrush;
			}

			if (m_number > 0)
			{
				BigNumber.Text = m_number.ToString();
				if (!m_numberIsCorrect && m_showErrors)
				{
					BigNumber.Foreground = m_incorrectNumberBrush;
				}
				else if (m_numberGiven)
				{
					BigNumber.Foreground = m_givenTextBrush;
				}
				else
				{
					BigNumber.Foreground = m_textBrush;
				}
			}
			else
			{
				for (int pencilled = 1; pencilled < 10; pencilled++)
				{
						switch (pencilled)
						{
							case 1:
								DrawPencilledIn(Pencilled1, pencilled);
								break;
							case 2:
								DrawPencilledIn(Pencilled2, pencilled);
								break;
							case 3:
								DrawPencilledIn(Pencilled3, pencilled);
								break;
							case 4:
								DrawPencilledIn(Pencilled4, pencilled);
								break;
							case 5:
								DrawPencilledIn(Pencilled5, pencilled);
								break;
							case 6:
								DrawPencilledIn(Pencilled6, pencilled);
								break;
							case 7:
								DrawPencilledIn(Pencilled7, pencilled);
								break;
							case 8:
								DrawPencilledIn(Pencilled8, pencilled);
								break;
							case 9:
								DrawPencilledIn(Pencilled9, pencilled);
								break;
						}
					}
			}

			/*
			if (m_inLineWithSelected && !m_numberProvidedByPlayer)
			{
				g.FillRectangle(m_inLineWithSelectedBackgroundBrush, 0, 0, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height);
			}
			*/
		}

		private void DrawPencilledIn(TextBlock pencilledInTextBlock, int pencilled)
		{
			if (m_numbersPencilled.Contains(pencilled))
			{
				pencilledInTextBlock.Visibility = Windows.UI.Xaml.Visibility.Visible;
				if (m_highlightPencils && m_numberSelected == pencilled)
				{
					pencilledInTextBlock.Foreground = m_highlightedPencilTextBrush;
				}
				else
				{
					pencilledInTextBlock.Foreground = m_pencilTextBrush;
				}
			}
			else
			{
				pencilledInTextBlock.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
			}
		}


		private void NumberGrid_PointerPressed(object sender, PointerRoutedEventArgs e)
		{
		}

		private void NumberGrid_Tapped(object sender, TappedRoutedEventArgs e)
		{
			if (OnCellTapped != null)
			{
				OnCellTapped(m_cellPosition, m_number);
			}
		}

		private void NumberGrid_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
		{
			if (!m_numberGiven && m_number > 0)
			{
				if (OnCellCleared != null)
				{
					OnCellCleared(m_number, m_cellPosition);
				}
				m_number = -1;
				m_numberProvidedByPlayer = false;
				UpdateLayout();
			}
			if (OnCellDoubleTapped != null)
			{
				OnCellDoubleTapped(m_cellPosition, m_number);
			}
		}

    }
}
