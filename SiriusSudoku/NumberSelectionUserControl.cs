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
	public partial class NumberSelectionUserControl : UserControl
	{		
		public delegate void NumberSelectedHandler(int number);
		public event NumberSelectedHandler OnNumberSelected;

		public delegate void BooleanToggleHandler(bool value);
		public event BooleanToggleHandler OnEraseToggled;
		public event BooleanToggleHandler OnPencilInToggled;

		private bool m_pencillingIn = false;
		private bool m_erasing = false;
		private NumberSelectionButton[] m_numberButtons = new NumberSelectionButton[9];
		
		public NumberSelectionUserControl()
		{
			InitializeComponent();
		}

		public void SelectNumber(int number)
		{
			OnNumberButtonTapped(number);
		}

		public void ShowNumberCount(bool show)
		{
			for (int i = 0; i < 9; i++)
			{
				m_numberButtons[i].ShowNumberCount = show;
			}
		}

		public void SetNumberCountLimit(int numberCountLimit)
		{
			for (int i = 0; i < 9; i++)
			{
				m_numberButtons[i].NumberCountLimit = numberCountLimit;
			}
		}

		public void UpdateNumberCount(int[] numberCounts)
		{
			for (int i = 0; i < 9; i++)
			{
				m_numberButtons[i].NumberCount = numberCounts[i];
			}
		}

		private void NumberSelectionUserControl_Load(object sender, EventArgs e)
		{
			m_numberButtons[0] = NumberButton1;
			m_numberButtons[1] = NumberButton2;
			m_numberButtons[2] = NumberButton3;
			m_numberButtons[3] = NumberButton4;
			m_numberButtons[4] = NumberButton5;
			m_numberButtons[5] = NumberButton6;
			m_numberButtons[6] = NumberButton7;
			m_numberButtons[7] = NumberButton8;
			m_numberButtons[8] = NumberButton9;

			for (int number = 0; number < 9; number++)
			{
				m_numberButtons[number].Number = number + 1;
				m_numberButtons[number].OnButtonTapped += OnNumberButtonTapped;
			}
		}

		void OnNumberButtonTapped(int number)
		{
			for (int button = 0; button < 9; button++)
			{
				m_numberButtons[button].Selected = (button + 1 == number);
			}

			if (OnNumberSelected != null)
			{
				OnNumberSelected(number);
			}
		}

		private void EraseButton_Click(object sender, EventArgs e)
		{
			if (m_pencillingIn)
			{
				PencilButton_Click(sender, e);
			}

			m_erasing = !m_erasing;

			if (m_erasing)
			{
				EraseButton.ImageIndex = 1;
			}
			else
			{
				EraseButton.ImageIndex = 0;
			}

			if (OnEraseToggled != null)
			{
				OnEraseToggled(m_erasing);
			}
		}

		private void PencilButton_Click(object sender, EventArgs e)
		{
			if (m_erasing)
			{
				EraseButton_Click(sender, e);
			}

			m_pencillingIn = !m_pencillingIn;

			if (m_pencillingIn)
			{
				PencilButton.ImageIndex = 3;
			}
			else
			{
				PencilButton.ImageIndex = 2;
			}

			if (OnPencilInToggled != null)
			{
				OnPencilInToggled(m_pencillingIn);
			}
		}


	}
}
