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
	public partial class NumberSelectionButton : UserControl
	{
		public delegate void ButtonTapHandler(int buttonNumber);
		public event ButtonTapHandler OnButtonTapped;

		public int Number
		{
			get { return m_number; }
			set
			{
				m_number = value;
				Invalidate();
			}
		}
		public int NumberCount
		{
			get { return m_numberCount; }
			set
			{
				m_numberCount = value;
				Invalidate();
			}
		}
		public int NumberCountLimit
		{
			get { return m_numberCountLimit; }
			set { m_numberCountLimit = value; }
		}
		public bool Selected
		{
			get { return m_selected; }
			set
			{
				m_selected = value;
				Invalidate();
			}
		}

		public bool ShowNumberCount
		{
			get { return m_showNumberCount; }
			set 
			{ 
				m_showNumberCount = value;
				Invalidate();
			}
		}

		private int m_number = -1;
		private int m_numberCount = -1;
		private int m_numberCountLimit = -1;
		private bool m_selected = false;
		private bool m_showNumberCount = false;

		private Font m_smallFont = null;
		private Font m_bigFont = null;
		private Font m_bigFontBold = null;
		private StringFormat m_stringFormat = new StringFormat();

		private Brush m_textBrush = new SolidBrush(Color.Black);
		private Brush m_borderBrush = new SolidBrush(Color.Silver);
		private Brush m_backgroundBrush = new SolidBrush(Color.White);
		private Brush m_selectedBackgroundBrush = new SolidBrush(Color.LightBlue);
		private Brush m_numberCountLimitBackgroundBrush = new SolidBrush(Color.LightGray);

		public NumberSelectionButton()
		{
			InitializeComponent();

			m_smallFont = this.Font;
			m_bigFont = new Font(this.Font.FontFamily, 36);
			m_bigFontBold = new Font(this.Font.FontFamily, 36, FontStyle.Bold);
			m_stringFormat.FormatFlags = StringFormatFlags.NoWrap;
			m_stringFormat.Alignment = StringAlignment.Center;
			m_stringFormat.LineAlignment = StringAlignment.Center;
		}

		private void NumberSelectionButton_Load(object sender, EventArgs e)
		{

		}

		private void NumberSelectionButton_Paint(object sender, PaintEventArgs e)
		{
			DrawTheSquare(e.Graphics);
		}

		private void NumberSelectionButton_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				if (OnButtonTapped != null)
				{
					OnButtonTapped(m_number);
				}
			}
		}

		private void DrawTheSquare(Graphics g)
		{
			float spaceSize = g.VisibleClipBounds.Width * 0.05f;
			float numberCountSize = g.VisibleClipBounds.Width * 0.2f;
			RectangleF bigNumberBox = new RectangleF(0, 10, 60, 50);

			if (m_showNumberCount && m_numberCount == m_numberCountLimit)
			{
				g.FillRectangle(m_numberCountLimitBackgroundBrush, 0, 0, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height);
			}
			else if (m_selected)
			{
				g.FillRectangle(m_selectedBackgroundBrush, 0, 0, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height);
			}
			else
			{
				g.FillRectangle(m_backgroundBrush, 0, 0, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height);
			}

			if (m_number > 0)
			{
				g.DrawString(m_number.ToString(), m_bigFont, m_textBrush, bigNumberBox, m_stringFormat);//, g.VisibleClipBounds.Width - spaceSize * 2, g.VisibleClipBounds.Height - spaceSize * 2);
			}

			if (m_showNumberCount && m_numberCount > 0)
			{
				g.DrawString(m_numberCount.ToString(), m_smallFont, m_textBrush,
										g.VisibleClipBounds.Width - numberCountSize - spaceSize, spaceSize); //, numberCountSize, numberCountSize);
			}

			g.DrawRectangle(Pens.Black, 0, 0, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height);
		}
	}
}
