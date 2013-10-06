namespace SiriusSudoku
{
	partial class HighScoresForm
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.EasyButton = new System.Windows.Forms.Button();
			this.HardButton = new System.Windows.Forms.Button();
			this.MediumButton = new System.Windows.Forms.Button();
			this.ExtremeButton = new System.Windows.Forms.Button();
			this.SillyHardButton = new System.Windows.Forms.Button();
			this.HighScoresTextBox = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.EasyButton);
			this.flowLayoutPanel1.Controls.Add(this.MediumButton);
			this.flowLayoutPanel1.Controls.Add(this.HardButton);
			this.flowLayoutPanel1.Controls.Add(this.ExtremeButton);
			this.flowLayoutPanel1.Controls.Add(this.SillyHardButton);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(420, 52);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// EasyButton
			// 
			this.EasyButton.Location = new System.Drawing.Point(3, 3);
			this.EasyButton.Name = "EasyButton";
			this.EasyButton.Size = new System.Drawing.Size(78, 46);
			this.EasyButton.TabIndex = 1;
			this.EasyButton.Text = "Easy";
			this.EasyButton.UseVisualStyleBackColor = true;
			this.EasyButton.Click += new System.EventHandler(this.EasyButton_Click);
			// 
			// HardButton
			// 
			this.HardButton.Location = new System.Drawing.Point(171, 3);
			this.HardButton.Name = "HardButton";
			this.HardButton.Size = new System.Drawing.Size(78, 46);
			this.HardButton.TabIndex = 2;
			this.HardButton.Text = "Hard";
			this.HardButton.UseVisualStyleBackColor = true;
			this.HardButton.Click += new System.EventHandler(this.HardButton_Click);
			// 
			// MediumButton
			// 
			this.MediumButton.Location = new System.Drawing.Point(87, 3);
			this.MediumButton.Name = "MediumButton";
			this.MediumButton.Size = new System.Drawing.Size(78, 46);
			this.MediumButton.TabIndex = 3;
			this.MediumButton.Text = "Medium";
			this.MediumButton.UseVisualStyleBackColor = true;
			this.MediumButton.Click += new System.EventHandler(this.MediumButton_Click);
			// 
			// ExtremeButton
			// 
			this.ExtremeButton.Location = new System.Drawing.Point(255, 3);
			this.ExtremeButton.Name = "ExtremeButton";
			this.ExtremeButton.Size = new System.Drawing.Size(78, 46);
			this.ExtremeButton.TabIndex = 4;
			this.ExtremeButton.Text = "Extreme";
			this.ExtremeButton.UseVisualStyleBackColor = true;
			this.ExtremeButton.Click += new System.EventHandler(this.ExtremeButton_Click);
			// 
			// SillyHardButton
			// 
			this.SillyHardButton.Location = new System.Drawing.Point(339, 3);
			this.SillyHardButton.Name = "SillyHardButton";
			this.SillyHardButton.Size = new System.Drawing.Size(78, 46);
			this.SillyHardButton.TabIndex = 5;
			this.SillyHardButton.Text = "Silly Hard";
			this.SillyHardButton.UseVisualStyleBackColor = true;
			this.SillyHardButton.Click += new System.EventHandler(this.SillyHardButton_Click);
			// 
			// HighScoresTextBox
			// 
			this.HighScoresTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.HighScoresTextBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.HighScoresTextBox.Location = new System.Drawing.Point(12, 58);
			this.HighScoresTextBox.Multiline = true;
			this.HighScoresTextBox.Name = "HighScoresTextBox";
			this.HighScoresTextBox.Size = new System.Drawing.Size(396, 414);
			this.HighScoresTextBox.TabIndex = 1;
			// 
			// HighScoresForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(420, 484);
			this.Controls.Add(this.HighScoresTextBox);
			this.Controls.Add(this.flowLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HighScoresForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Sirius Sudoku High Scores";
			this.Shown += new System.EventHandler(this.HighScoresForm_Shown);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button EasyButton;
		private System.Windows.Forms.Button MediumButton;
		private System.Windows.Forms.Button HardButton;
		private System.Windows.Forms.Button ExtremeButton;
		private System.Windows.Forms.Button SillyHardButton;
		private System.Windows.Forms.TextBox HighScoresTextBox;
	}
}