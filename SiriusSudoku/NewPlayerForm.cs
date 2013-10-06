using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SiriusSudoku
{
	public partial class NewPlayerForm : Form
	{
		public string PlayerName { get { return PlayerNameTextBox.Text; } }

		public NewPlayerForm()
		{
			InitializeComponent();
		}
	}
}
