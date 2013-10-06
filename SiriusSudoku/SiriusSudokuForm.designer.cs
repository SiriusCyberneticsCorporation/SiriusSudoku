namespace SiriusSudoku
{
	partial class SiriusSudokuForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiriusSudokuForm));
			this.SudokuToolStrip = new System.Windows.Forms.ToolStrip();
			this.EasyToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.MediumToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.HardToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ExtremeToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.SillyHardToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.TimerToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
			this.PauseToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.EnterPuzzleToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.enterPuzzleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.beginSolvingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.savePuzzleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.HallOfFameToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.PlayerToolStripLabel = new System.Windows.Forms.ToolStripLabel();
			this.PlayersToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.ShowErrorsCheckBox = new System.Windows.Forms.CheckBox();
			this.SecondTimer = new System.Windows.Forms.Timer(this.components);
			this.ShowNumberCountCheckBox = new System.Windows.Forms.CheckBox();
			this.HighlightPencilMarksCheckBox = new System.Windows.Forms.CheckBox();
			this.RestartGameButton = new System.Windows.Forms.Button();
			this.GameBoardPanel = new System.Windows.Forms.Panel();
			this.TheGameBoard = new SiriusSudoku.SudokuGameBoard();
			this.NumberSelectionPanel = new SiriusSudoku.NumberSelectionUserControl();
			this.SudokuToolStrip.SuspendLayout();
			this.GameBoardPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// SudokuToolStrip
			// 
			this.SudokuToolStrip.AutoSize = false;
			this.SudokuToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EasyToolStripButton,
            this.MediumToolStripButton,
            this.HardToolStripButton,
            this.ExtremeToolStripButton,
            this.SillyHardToolStripButton,
            this.TimerToolStripTextBox,
            this.PauseToolStripButton,
            this.toolStripSeparator1,
            this.EnterPuzzleToolStripDropDownButton,
            this.toolStripSeparator2,
            this.HallOfFameToolStripButton,
            this.toolStripSeparator3,
            this.PlayerToolStripLabel,
            this.PlayersToolStripComboBox});
			this.SudokuToolStrip.Location = new System.Drawing.Point(0, 0);
			this.SudokuToolStrip.Name = "SudokuToolStrip";
			this.SudokuToolStrip.Size = new System.Drawing.Size(1087, 35);
			this.SudokuToolStrip.TabIndex = 3;
			this.SudokuToolStrip.Text = "toolStrip1";
			// 
			// EasyToolStripButton
			// 
			this.EasyToolStripButton.AutoSize = false;
			this.EasyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EasyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EasyToolStripButton.Image")));
			this.EasyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EasyToolStripButton.Name = "EasyToolStripButton";
			this.EasyToolStripButton.Size = new System.Drawing.Size(90, 30);
			this.EasyToolStripButton.Text = "Easy";
			this.EasyToolStripButton.Click += new System.EventHandler(this.EasyToolStripButton_Click);
			// 
			// MediumToolStripButton
			// 
			this.MediumToolStripButton.AutoSize = false;
			this.MediumToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.MediumToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("MediumToolStripButton.Image")));
			this.MediumToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MediumToolStripButton.Name = "MediumToolStripButton";
			this.MediumToolStripButton.Size = new System.Drawing.Size(90, 30);
			this.MediumToolStripButton.Text = "Medium";
			this.MediumToolStripButton.Click += new System.EventHandler(this.MediumToolStripButton_Click);
			// 
			// HardToolStripButton
			// 
			this.HardToolStripButton.AutoSize = false;
			this.HardToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.HardToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("HardToolStripButton.Image")));
			this.HardToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.HardToolStripButton.Name = "HardToolStripButton";
			this.HardToolStripButton.Size = new System.Drawing.Size(90, 30);
			this.HardToolStripButton.Text = "Hard";
			this.HardToolStripButton.Click += new System.EventHandler(this.HardToolStripButton_Click);
			// 
			// ExtremeToolStripButton
			// 
			this.ExtremeToolStripButton.AutoSize = false;
			this.ExtremeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ExtremeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ExtremeToolStripButton.Image")));
			this.ExtremeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ExtremeToolStripButton.Name = "ExtremeToolStripButton";
			this.ExtremeToolStripButton.Size = new System.Drawing.Size(90, 30);
			this.ExtremeToolStripButton.Text = "Extreme";
			this.ExtremeToolStripButton.Click += new System.EventHandler(this.ExtremeToolStripButton_Click);
			// 
			// SillyHardToolStripButton
			// 
			this.SillyHardToolStripButton.AutoSize = false;
			this.SillyHardToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SillyHardToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SillyHardToolStripButton.Image")));
			this.SillyHardToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SillyHardToolStripButton.Name = "SillyHardToolStripButton";
			this.SillyHardToolStripButton.Size = new System.Drawing.Size(90, 30);
			this.SillyHardToolStripButton.Text = "Silly Hard";
			this.SillyHardToolStripButton.Click += new System.EventHandler(this.SillyHardToolStripButton_Click);
			// 
			// TimerToolStripTextBox
			// 
			this.TimerToolStripTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.TimerToolStripTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.TimerToolStripTextBox.Name = "TimerToolStripTextBox";
			this.TimerToolStripTextBox.ReadOnly = true;
			this.TimerToolStripTextBox.Size = new System.Drawing.Size(50, 35);
			this.TimerToolStripTextBox.Text = "00:00";
			this.TimerToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// PauseToolStripButton
			// 
			this.PauseToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.PauseToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PauseToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("PauseToolStripButton.Image")));
			this.PauseToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PauseToolStripButton.Name = "PauseToolStripButton";
			this.PauseToolStripButton.Size = new System.Drawing.Size(42, 32);
			this.PauseToolStripButton.Text = "Pause";
			this.PauseToolStripButton.Click += new System.EventHandler(this.PauseToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
			// 
			// EnterPuzzleToolStripDropDownButton
			// 
			this.EnterPuzzleToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EnterPuzzleToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enterPuzzleToolStripMenuItem,
            this.beginSolvingToolStripMenuItem,
            this.savePuzzleToolStripMenuItem});
			this.EnterPuzzleToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("EnterPuzzleToolStripDropDownButton.Image")));
			this.EnterPuzzleToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EnterPuzzleToolStripDropDownButton.Name = "EnterPuzzleToolStripDropDownButton";
			this.EnterPuzzleToolStripDropDownButton.Size = new System.Drawing.Size(139, 32);
			this.EnterPuzzleToolStripDropDownButton.Text = "Enter Your Own Puzzle";
			// 
			// enterPuzzleToolStripMenuItem
			// 
			this.enterPuzzleToolStripMenuItem.Name = "enterPuzzleToolStripMenuItem";
			this.enterPuzzleToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.enterPuzzleToolStripMenuItem.Text = "Enter Puzzle";
			this.enterPuzzleToolStripMenuItem.Click += new System.EventHandler(this.enterPuzzleToolStripMenuItem_Click);
			// 
			// beginSolvingToolStripMenuItem
			// 
			this.beginSolvingToolStripMenuItem.Name = "beginSolvingToolStripMenuItem";
			this.beginSolvingToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.beginSolvingToolStripMenuItem.Text = "Begin Solving";
			this.beginSolvingToolStripMenuItem.Click += new System.EventHandler(this.beginSolvingToolStripMenuItem_Click);
			// 
			// savePuzzleToolStripMenuItem
			// 
			this.savePuzzleToolStripMenuItem.Name = "savePuzzleToolStripMenuItem";
			this.savePuzzleToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.savePuzzleToolStripMenuItem.Text = "Save Puzzle";
			this.savePuzzleToolStripMenuItem.Click += new System.EventHandler(this.savePuzzleToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
			// 
			// HallOfFameToolStripButton
			// 
			this.HallOfFameToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.HallOfFameToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("HallOfFameToolStripButton.Image")));
			this.HallOfFameToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.HallOfFameToolStripButton.Name = "HallOfFameToolStripButton";
			this.HallOfFameToolStripButton.Size = new System.Drawing.Size(78, 32);
			this.HallOfFameToolStripButton.Text = "Hall of Fame";
			this.HallOfFameToolStripButton.Click += new System.EventHandler(this.HallOfFameToolStripButton_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
			// 
			// PlayerToolStripLabel
			// 
			this.PlayerToolStripLabel.Name = "PlayerToolStripLabel";
			this.PlayerToolStripLabel.Size = new System.Drawing.Size(39, 32);
			this.PlayerToolStripLabel.Text = "Player";
			// 
			// PlayersToolStripComboBox
			// 
			this.PlayersToolStripComboBox.Name = "PlayersToolStripComboBox";
			this.PlayersToolStripComboBox.Size = new System.Drawing.Size(121, 35);
			this.PlayersToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.PlayersToolStripComboBox_SelectedIndexChanged);
			// 
			// ShowErrorsCheckBox
			// 
			this.ShowErrorsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ShowErrorsCheckBox.AutoSize = true;
			this.ShowErrorsCheckBox.Location = new System.Drawing.Point(942, 450);
			this.ShowErrorsCheckBox.Name = "ShowErrorsCheckBox";
			this.ShowErrorsCheckBox.Size = new System.Drawing.Size(83, 17);
			this.ShowErrorsCheckBox.TabIndex = 4;
			this.ShowErrorsCheckBox.Text = "Show Errors";
			this.ShowErrorsCheckBox.UseVisualStyleBackColor = true;
			this.ShowErrorsCheckBox.CheckedChanged += new System.EventHandler(this.ShowErrorsCheckBox_CheckedChanged);
			// 
			// SecondTimer
			// 
			this.SecondTimer.Enabled = true;
			this.SecondTimer.Interval = 1000;
			this.SecondTimer.Tick += new System.EventHandler(this.SecondTimer_Tick);
			// 
			// ShowNumberCountCheckBox
			// 
			this.ShowNumberCountCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ShowNumberCountCheckBox.AutoSize = true;
			this.ShowNumberCountCheckBox.Checked = true;
			this.ShowNumberCountCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ShowNumberCountCheckBox.Location = new System.Drawing.Point(942, 473);
			this.ShowNumberCountCheckBox.Name = "ShowNumberCountCheckBox";
			this.ShowNumberCountCheckBox.Size = new System.Drawing.Size(124, 17);
			this.ShowNumberCountCheckBox.TabIndex = 5;
			this.ShowNumberCountCheckBox.Text = "Show Number Count";
			this.ShowNumberCountCheckBox.UseVisualStyleBackColor = true;
			this.ShowNumberCountCheckBox.CheckedChanged += new System.EventHandler(this.ShowNumberCountCheckBox_CheckedChanged);
			// 
			// HighlightPencilMarksCheckBox
			// 
			this.HighlightPencilMarksCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.HighlightPencilMarksCheckBox.AutoSize = true;
			this.HighlightPencilMarksCheckBox.Location = new System.Drawing.Point(942, 496);
			this.HighlightPencilMarksCheckBox.Name = "HighlightPencilMarksCheckBox";
			this.HighlightPencilMarksCheckBox.Size = new System.Drawing.Size(131, 17);
			this.HighlightPencilMarksCheckBox.TabIndex = 6;
			this.HighlightPencilMarksCheckBox.Text = "Highlight Pencil Marks";
			this.HighlightPencilMarksCheckBox.UseVisualStyleBackColor = true;
			this.HighlightPencilMarksCheckBox.CheckedChanged += new System.EventHandler(this.HighlightPencilMarksCheckBox_CheckedChanged);
			// 
			// RestartGameButton
			// 
			this.RestartGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.RestartGameButton.Location = new System.Drawing.Point(942, 580);
			this.RestartGameButton.Name = "RestartGameButton";
			this.RestartGameButton.Size = new System.Drawing.Size(133, 31);
			this.RestartGameButton.TabIndex = 7;
			this.RestartGameButton.Text = "Restart Current Game";
			this.RestartGameButton.UseVisualStyleBackColor = true;
			this.RestartGameButton.Click += new System.EventHandler(this.RestartGameButton_Click);
			// 
			// GameBoardPanel
			// 
			this.GameBoardPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GameBoardPanel.Controls.Add(this.TheGameBoard);
			this.GameBoardPanel.Location = new System.Drawing.Point(12, 42);
			this.GameBoardPanel.Margin = new System.Windows.Forms.Padding(0);
			this.GameBoardPanel.Name = "GameBoardPanel";
			this.GameBoardPanel.Size = new System.Drawing.Size(924, 568);
			this.GameBoardPanel.TabIndex = 8;
			this.GameBoardPanel.Resize += new System.EventHandler(this.GameBoardPanel_Resize);
			// 
			// TheGameBoard
			// 
			this.TheGameBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TheGameBoard.GridSize = 9;
			this.TheGameBoard.HighlightPencilMarks = false;
			this.TheGameBoard.Location = new System.Drawing.Point(3, 3);
			this.TheGameBoard.Margin = new System.Windows.Forms.Padding(0);
			this.TheGameBoard.Name = "TheGameBoard";
			this.TheGameBoard.NumberSelected = -1;
			this.TheGameBoard.ShowErrors = false;
			this.TheGameBoard.Size = new System.Drawing.Size(918, 562);
			this.TheGameBoard.SolutionGrid = null;
			this.TheGameBoard.TabIndex = 0;
			// 
			// NumberSelectionPanel
			// 
			this.NumberSelectionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NumberSelectionPanel.Location = new System.Drawing.Point(942, 42);
			this.NumberSelectionPanel.Name = "NumberSelectionPanel";
			this.NumberSelectionPanel.Size = new System.Drawing.Size(133, 399);
			this.NumberSelectionPanel.TabIndex = 1;
			// 
			// SiriusSudokuForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1087, 621);
			this.Controls.Add(this.GameBoardPanel);
			this.Controls.Add(this.RestartGameButton);
			this.Controls.Add(this.HighlightPencilMarksCheckBox);
			this.Controls.Add(this.ShowNumberCountCheckBox);
			this.Controls.Add(this.ShowErrorsCheckBox);
			this.Controls.Add(this.SudokuToolStrip);
			this.Controls.Add(this.NumberSelectionPanel);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(685, 598);
			this.Name = "SiriusSudokuForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Sirius Sudoku";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SiriusSudokuForm_FormClosing);
			this.Load += new System.EventHandler(this.SiriusSudokuForm_Load);
			this.Resize += new System.EventHandler(this.SiriusSudokuForm_Resize);
			this.SudokuToolStrip.ResumeLayout(false);
			this.SudokuToolStrip.PerformLayout();
			this.GameBoardPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private SudokuGameBoard TheGameBoard;
		private NumberSelectionUserControl NumberSelectionPanel;
		private System.Windows.Forms.ToolStrip SudokuToolStrip;
		private System.Windows.Forms.ToolStripButton EasyToolStripButton;
		private System.Windows.Forms.ToolStripButton MediumToolStripButton;
		private System.Windows.Forms.ToolStripButton HardToolStripButton;
		private System.Windows.Forms.ToolStripButton ExtremeToolStripButton;
		private System.Windows.Forms.CheckBox ShowErrorsCheckBox;
		private System.Windows.Forms.ToolStripTextBox TimerToolStripTextBox;
		private System.Windows.Forms.ToolStripButton PauseToolStripButton;
		private System.Windows.Forms.Timer SecondTimer;
		private System.Windows.Forms.CheckBox ShowNumberCountCheckBox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripDropDownButton EnterPuzzleToolStripDropDownButton;
		private System.Windows.Forms.ToolStripMenuItem enterPuzzleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem beginSolvingToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem savePuzzleToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton HallOfFameToolStripButton;
		private System.Windows.Forms.CheckBox HighlightPencilMarksCheckBox;
		private System.Windows.Forms.Button RestartGameButton;
		private System.Windows.Forms.Panel GameBoardPanel;
		private System.Windows.Forms.ToolStripButton SillyHardToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripLabel PlayerToolStripLabel;
		private System.Windows.Forms.ToolStripComboBox PlayersToolStripComboBox;

	}
}

