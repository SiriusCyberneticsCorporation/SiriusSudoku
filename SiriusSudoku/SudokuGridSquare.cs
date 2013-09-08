﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiriusSudoku
{
	public partial class SudokuGridSquare : UserControl
	{
		public delegate void CellTapHandler(Position cellPosition);
		public event CellTapHandler OnCellTapped;
		public event CellTapHandler OnCellRightTapped;
		public event CellTapHandler OnCellDoubleTapped;

		public delegate void CellClearedHandler(int number, Position cellPosition);
		public event CellClearedHandler OnCellCleared;

		public int Number { get { return m_number; } }
		public Position CellPosition { set { m_cellPosition = value; } }

		public void ClearCell()
		{
			m_number = -1;
			m_selected = false;
			m_inLineWithSelected = false;
			m_sameNumberAsSelected = false;
			m_numberGiven = false;
			m_numberIsCorrect = true;
			m_numberProvidedByPlayer = false;
			m_numbersPencilled = new List<int>();
			Invalidate();
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
				Invalidate();
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
				Invalidate();
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
				throw new Exception("PencilInNumber() - This square has a given number.");
			}

			if (m_numbersPencilled.Contains(number))
			{
				m_numbersPencilled.Remove(number);
			}
			else
			{
				m_numbersPencilled.Add(number);
			}
			Invalidate();
		}

		public bool ShowErrors 
		{ 
			get { return m_showErrors; } 
			set 
			{ 
				m_showErrors = value;
				Invalidate();
			} 
		}

		private int m_number = -1;
		private bool m_selected = false;
		private bool m_inLineWithSelected = false;
		private bool m_sameNumberAsSelected = false;
		private bool m_showErrors = false;
		private bool m_numberGiven = false;
		private bool m_numberIsCorrect = true;
		private bool m_numberProvidedByPlayer = false;
		private List<int> m_numbersPencilled = new List<int>();
		private Position m_cellPosition = null;

		private Font m_smallFont = null;
		private Font m_bigFont = null;
		private Font m_bigFontBold = null;
		private StringFormat m_stringFormat = new StringFormat();

		private Brush m_textBrush = new SolidBrush(Color.Black);
		private Brush m_givenTextBrush = new SolidBrush(Color.Navy);
		private Brush m_pencilTextBrush = new SolidBrush(Color.Black);
		private Brush m_borderBrush = new SolidBrush(Color.DarkGray);
		private Brush m_incorrectNumberBrush = new SolidBrush(Color.Red);
		private Brush m_defaultBackgroundBrush = new SolidBrush(Color.White);
		private Brush m_givenNumberBackgroundBrush = new SolidBrush(Color.FromArgb(20, 20, 20, 20));
		private Brush m_numberProvidedByPlayerBackgroundBrush = new SolidBrush(Color.White);
		private Brush m_selectedBackgroundBrush = new SolidBrush(Color.DeepSkyBlue);
		private Brush m_sameNumberAsSelectedBackgroundBrush = new SolidBrush(Color.DeepSkyBlue);
		private Brush m_inLineWithSelectedBackgroundBrush = new SolidBrush(Color.FromArgb(100, 250, 250, 0));

		public SudokuGridSquare()
		{
			InitializeComponent();

			m_smallFont = this.Font;
			m_bigFont = new Font(this.Font.FontFamily, 36);
			m_bigFontBold = new Font(this.Font.FontFamily, 36, FontStyle.Bold);
			m_stringFormat.Alignment = StringAlignment.Center;
			m_stringFormat.LineAlignment = StringAlignment.Center;
		}

		private void SudokuGridSquare_Paint(object sender, PaintEventArgs e)
		{
			DrawTheSquare(e.Graphics);
		}

		private void DrawTheSquare(Graphics g)
		{
			int numberOfSpaces = 4;
			int numberOfPencilled = 3;
			float spaceSize = g.VisibleClipBounds.Width * 0.05f;
			float pencilledSize = (g.VisibleClipBounds.Width - (spaceSize * numberOfSpaces)) / (float)numberOfPencilled;
			RectangleF bigNumberBox = new RectangleF(0, 10, 60, 50);

			if (pencilledSize > 0)
			{
				g.Clear(Color.White);

				if (m_numberGiven)
				{
					g.FillRectangle(m_givenNumberBackgroundBrush, 0, 0, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height);
				}
				else if (m_numberProvidedByPlayer)
				{
					g.FillRectangle(m_numberProvidedByPlayerBackgroundBrush, 0, 0, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height);
				}
				else if (m_selected)
				{
					g.FillRectangle(m_selectedBackgroundBrush, 0, 0, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height);
				}
				else if (m_sameNumberAsSelected)
				{
					g.FillRectangle(m_sameNumberAsSelectedBackgroundBrush, 0, 0, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height);
				}
				else
				{
					g.FillRectangle(m_defaultBackgroundBrush, 0, 0, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height);
				}

				if (m_number > 0)
				{
					if (!m_numberIsCorrect && m_showErrors)
					{
						g.DrawString(m_number.ToString(), m_bigFont, m_incorrectNumberBrush, bigNumberBox, m_stringFormat);
					}
					else if (m_numberGiven)
					{
						g.DrawString(m_number.ToString(), m_bigFont, m_givenTextBrush, bigNumberBox, m_stringFormat);
					}
					else
					{
						g.DrawString(m_number.ToString(), m_bigFont, m_textBrush, bigNumberBox, m_stringFormat);
					}
				}
				else
				{
					foreach (int pencilled in m_numbersPencilled)
					{
						string letter = string.Empty;
						float left = 3;
						float top = 2;
						switch (pencilled)
						{
							case 1:
								letter = "1";
								left += spaceSize;
								top += spaceSize;
								break;
							case 2:
								letter = "2";
								left += spaceSize * 2 + pencilledSize;
								top += spaceSize;
								break;
							case 3:
								letter = "3";
								left += spaceSize * 3 + pencilledSize * 2;
								top += spaceSize;
								break;
							case 4:
								letter = "4";
								left += spaceSize;
								top += spaceSize * 2 + pencilledSize;
								break;
							case 5:
								letter = "5";
								left += spaceSize * 2 + pencilledSize;
								top += spaceSize * 2 + pencilledSize;
								break;
							case 6:
								letter = "6";
								left += spaceSize * 3 + pencilledSize * 2;
								top += spaceSize * 2 + pencilledSize;
								break;
							case 7:
								letter = "7";
								left += spaceSize;
								top += spaceSize * 3 + pencilledSize * 2;
								break;
							case 8:
								letter = "8";
								left += spaceSize * 2 + pencilledSize;
								top += spaceSize * 3 + pencilledSize * 2;
								break;
							case 9:
								letter = "9";
								left += spaceSize * 3 + pencilledSize * 2;
								top += spaceSize * 3 + pencilledSize * 2;
								break;
						}

						g.DrawString(letter, m_smallFont, m_pencilTextBrush, left, top);
					}
				}

				if (m_inLineWithSelected && !m_numberProvidedByPlayer)
				{
					g.FillRectangle(m_inLineWithSelectedBackgroundBrush, 0, 0, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height);
				}

				g.DrawRectangle(Pens.Black, 0, 0, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height);
			}
		}

		private void SudokuGridSquare_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				if (!m_numberGiven && OnCellTapped != null)
				{
					OnCellTapped(m_cellPosition);
				}
			}
			else if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				if (OnCellRightTapped != null)
				{
					OnCellRightTapped(m_cellPosition);
				}
			}
		}

		private void SudokuGridSquare_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!m_numberGiven && m_number > 0)
			{
				if (OnCellCleared != null)
				{
					OnCellCleared(m_number, m_cellPosition);
				}
				m_number = -1;
				m_numberProvidedByPlayer = false;
				Invalidate();
			}
			if (OnCellDoubleTapped != null)
			{
				OnCellDoubleTapped(m_cellPosition);
			}
		}
	}
}