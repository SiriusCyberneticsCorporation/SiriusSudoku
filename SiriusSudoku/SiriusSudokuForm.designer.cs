﻿namespace SiriusSudoku
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
			this.ExtremeToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.MediumToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.EasyToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.HardToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ShowErrorsCheckBox = new System.Windows.Forms.CheckBox();
			this.TimerToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
			this.PauseToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.SecondTimer = new System.Windows.Forms.Timer(this.components);
			this.ShowNumberCountCheckBox = new System.Windows.Forms.CheckBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.EnterPuzzleToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.enterPuzzleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.savePuzzleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.beginSolvingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NumberSelectionPanel = new SiriusSudoku.NumberSelectionUserControl();
			this.TheGameBoard = new SiriusSudoku.SudokuGameBoard();
			this.SudokuToolStrip.SuspendLayout();
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
            this.TimerToolStripTextBox,
            this.PauseToolStripButton,
            this.toolStripSeparator1,
            this.EnterPuzzleToolStripDropDownButton});
			this.SudokuToolStrip.Location = new System.Drawing.Point(0, 0);
			this.SudokuToolStrip.Name = "SudokuToolStrip";
			this.SudokuToolStrip.Size = new System.Drawing.Size(746, 35);
			this.SudokuToolStrip.TabIndex = 3;
			this.SudokuToolStrip.Text = "toolStrip1";
			// 
			// ExtremeToolStripButton
			// 
			this.ExtremeToolStripButton.AutoSize = false;
			this.ExtremeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ExtremeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ExtremeToolStripButton.Image")));
			this.ExtremeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ExtremeToolStripButton.Name = "ExtremeToolStripButton";
			this.ExtremeToolStripButton.Size = new System.Drawing.Size(90, 30);
			this.ExtremeToolStripButton.Text = "New Extreme";
			this.ExtremeToolStripButton.Click += new System.EventHandler(this.ExtremeToolStripButton_Click);
			// 
			// MediumToolStripButton
			// 
			this.MediumToolStripButton.AutoSize = false;
			this.MediumToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.MediumToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("MediumToolStripButton.Image")));
			this.MediumToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MediumToolStripButton.Name = "MediumToolStripButton";
			this.MediumToolStripButton.Size = new System.Drawing.Size(90, 30);
			this.MediumToolStripButton.Text = "New Medium";
			this.MediumToolStripButton.Click += new System.EventHandler(this.MediumToolStripButton_Click);
			// 
			// EasyToolStripButton
			// 
			this.EasyToolStripButton.AutoSize = false;
			this.EasyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EasyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EasyToolStripButton.Image")));
			this.EasyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EasyToolStripButton.Name = "EasyToolStripButton";
			this.EasyToolStripButton.Size = new System.Drawing.Size(90, 30);
			this.EasyToolStripButton.Text = "New Easy";
			this.EasyToolStripButton.Click += new System.EventHandler(this.EasyToolStripButton_Click);
			// 
			// HardToolStripButton
			// 
			this.HardToolStripButton.AutoSize = false;
			this.HardToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.HardToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("HardToolStripButton.Image")));
			this.HardToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.HardToolStripButton.Name = "HardToolStripButton";
			this.HardToolStripButton.Size = new System.Drawing.Size(90, 30);
			this.HardToolStripButton.Text = "New Hard";
			this.HardToolStripButton.Click += new System.EventHandler(this.HardToolStripButton_Click);
			// 
			// ShowErrorsCheckBox
			// 
			this.ShowErrorsCheckBox.AutoSize = true;
			this.ShowErrorsCheckBox.Location = new System.Drawing.Point(601, 478);
			this.ShowErrorsCheckBox.Name = "ShowErrorsCheckBox";
			this.ShowErrorsCheckBox.Size = new System.Drawing.Size(83, 17);
			this.ShowErrorsCheckBox.TabIndex = 4;
			this.ShowErrorsCheckBox.Text = "Show Errors";
			this.ShowErrorsCheckBox.UseVisualStyleBackColor = true;
			this.ShowErrorsCheckBox.CheckedChanged += new System.EventHandler(this.ShowErrorsCheckBox_CheckedChanged);
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
			// SecondTimer
			// 
			this.SecondTimer.Enabled = true;
			this.SecondTimer.Interval = 1000;
			this.SecondTimer.Tick += new System.EventHandler(this.SecondTimer_Tick);
			// 
			// ShowNumberCountCheckBox
			// 
			this.ShowNumberCountCheckBox.AutoSize = true;
			this.ShowNumberCountCheckBox.Checked = true;
			this.ShowNumberCountCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ShowNumberCountCheckBox.Location = new System.Drawing.Point(601, 501);
			this.ShowNumberCountCheckBox.Name = "ShowNumberCountCheckBox";
			this.ShowNumberCountCheckBox.Size = new System.Drawing.Size(124, 17);
			this.ShowNumberCountCheckBox.TabIndex = 5;
			this.ShowNumberCountCheckBox.Text = "Show Number Count";
			this.ShowNumberCountCheckBox.UseVisualStyleBackColor = true;
			this.ShowNumberCountCheckBox.CheckedChanged += new System.EventHandler(this.ShowNumberCountCheckBox_CheckedChanged);
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
			this.enterPuzzleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.enterPuzzleToolStripMenuItem.Text = "Enter Puzzle";
			this.enterPuzzleToolStripMenuItem.Click += new System.EventHandler(this.enterPuzzleToolStripMenuItem_Click);
			// 
			// savePuzzleToolStripMenuItem
			// 
			this.savePuzzleToolStripMenuItem.Name = "savePuzzleToolStripMenuItem";
			this.savePuzzleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.savePuzzleToolStripMenuItem.Text = "Save Puzzle";
			this.savePuzzleToolStripMenuItem.Click += new System.EventHandler(this.savePuzzleToolStripMenuItem_Click);
			// 
			// beginSolvingToolStripMenuItem
			// 
			this.beginSolvingToolStripMenuItem.Name = "beginSolvingToolStripMenuItem";
			this.beginSolvingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.beginSolvingToolStripMenuItem.Text = "Begin Solving";
			this.beginSolvingToolStripMenuItem.Click += new System.EventHandler(this.beginSolvingToolStripMenuItem_Click);
			// 
			// NumberSelectionPanel
			// 
			this.NumberSelectionPanel.Location = new System.Drawing.Point(601, 42);
			this.NumberSelectionPanel.Name = "NumberSelectionPanel";
			this.NumberSelectionPanel.Size = new System.Drawing.Size(133, 399);
			this.NumberSelectionPanel.TabIndex = 1;
			// 
			// TheGameBoard
			// 
			this.TheGameBoard.GridSize = 9;
			this.TheGameBoard.Location = new System.Drawing.Point(12, 42);
			this.TheGameBoard.MaximumSize = new System.Drawing.Size(569, 569);
			this.TheGameBoard.MinimumSize = new System.Drawing.Size(569, 569);
			this.TheGameBoard.Name = "TheGameBoard";
			this.TheGameBoard.ShowErrors = false;
			this.TheGameBoard.Size = new System.Drawing.Size(569, 569);
			this.TheGameBoard.SolutionGrid = null;
			this.TheGameBoard.TabIndex = 0;
			// 
			// SiriusSudokuForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(746, 621);
			this.Controls.Add(this.ShowNumberCountCheckBox);
			this.Controls.Add(this.ShowErrorsCheckBox);
			this.Controls.Add(this.SudokuToolStrip);
			this.Controls.Add(this.NumberSelectionPanel);
			this.Controls.Add(this.TheGameBoard);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "SiriusSudokuForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sirius Sudoku";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SiriusSudokuForm_FormClosing);
			this.Load += new System.EventHandler(this.SiriusSudokuForm_Load);
			this.Resize += new System.EventHandler(this.SiriusSudokuForm_Resize);
			this.SudokuToolStrip.ResumeLayout(false);
			this.SudokuToolStrip.PerformLayout();
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

	}
}
