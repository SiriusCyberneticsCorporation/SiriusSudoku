namespace SiriusSudoku
{
	partial class SudokuGameBoard
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.GameBoardTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.Grid00 = new SiriusSudoku.SudokuThreeByThreeGrid();
			this.Grid01 = new SiriusSudoku.SudokuThreeByThreeGrid();
			this.Grid02 = new SiriusSudoku.SudokuThreeByThreeGrid();
			this.Grid10 = new SiriusSudoku.SudokuThreeByThreeGrid();
			this.Grid11 = new SiriusSudoku.SudokuThreeByThreeGrid();
			this.Grid12 = new SiriusSudoku.SudokuThreeByThreeGrid();
			this.Grid20 = new SiriusSudoku.SudokuThreeByThreeGrid();
			this.Grid21 = new SiriusSudoku.SudokuThreeByThreeGrid();
			this.Grid22 = new SiriusSudoku.SudokuThreeByThreeGrid();
			this.GameBoardTableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// GameBoardTableLayoutPanel
			// 
			this.GameBoardTableLayoutPanel.BackColor = System.Drawing.Color.Gray;
			this.GameBoardTableLayoutPanel.ColumnCount = 3;
			this.GameBoardTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.GameBoardTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.GameBoardTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.GameBoardTableLayoutPanel.Controls.Add(this.Grid00, 0, 0);
			this.GameBoardTableLayoutPanel.Controls.Add(this.Grid01, 1, 0);
			this.GameBoardTableLayoutPanel.Controls.Add(this.Grid02, 2, 0);
			this.GameBoardTableLayoutPanel.Controls.Add(this.Grid10, 0, 1);
			this.GameBoardTableLayoutPanel.Controls.Add(this.Grid11, 1, 1);
			this.GameBoardTableLayoutPanel.Controls.Add(this.Grid12, 2, 1);
			this.GameBoardTableLayoutPanel.Controls.Add(this.Grid20, 0, 2);
			this.GameBoardTableLayoutPanel.Controls.Add(this.Grid21, 1, 2);
			this.GameBoardTableLayoutPanel.Controls.Add(this.Grid22, 2, 2);
			this.GameBoardTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GameBoardTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.GameBoardTableLayoutPanel.Name = "GameBoardTableLayoutPanel";
			this.GameBoardTableLayoutPanel.Padding = new System.Windows.Forms.Padding(2);
			this.GameBoardTableLayoutPanel.RowCount = 3;
			this.GameBoardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.GameBoardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.GameBoardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.GameBoardTableLayoutPanel.Size = new System.Drawing.Size(571, 546);
			this.GameBoardTableLayoutPanel.TabIndex = 0;
			// 
			// Grid00
			// 
			this.Grid00.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Grid00.Location = new System.Drawing.Point(3, 3);
			this.Grid00.Margin = new System.Windows.Forms.Padding(1);
			this.Grid00.Name = "Grid00";
			this.Grid00.Size = new System.Drawing.Size(187, 178);
			this.Grid00.TabIndex = 0;
			// 
			// Grid01
			// 
			this.Grid01.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Grid01.Location = new System.Drawing.Point(192, 3);
			this.Grid01.Margin = new System.Windows.Forms.Padding(1);
			this.Grid01.Name = "Grid01";
			this.Grid01.Size = new System.Drawing.Size(187, 178);
			this.Grid01.TabIndex = 1;
			// 
			// Grid02
			// 
			this.Grid02.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Grid02.Location = new System.Drawing.Point(381, 3);
			this.Grid02.Margin = new System.Windows.Forms.Padding(1);
			this.Grid02.Name = "Grid02";
			this.Grid02.Size = new System.Drawing.Size(187, 178);
			this.Grid02.TabIndex = 2;
			// 
			// Grid10
			// 
			this.Grid10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Grid10.Location = new System.Drawing.Point(3, 183);
			this.Grid10.Margin = new System.Windows.Forms.Padding(1);
			this.Grid10.Name = "Grid10";
			this.Grid10.Size = new System.Drawing.Size(187, 178);
			this.Grid10.TabIndex = 3;
			// 
			// Grid11
			// 
			this.Grid11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Grid11.Location = new System.Drawing.Point(192, 183);
			this.Grid11.Margin = new System.Windows.Forms.Padding(1);
			this.Grid11.Name = "Grid11";
			this.Grid11.Size = new System.Drawing.Size(187, 178);
			this.Grid11.TabIndex = 4;
			// 
			// Grid12
			// 
			this.Grid12.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Grid12.Location = new System.Drawing.Point(381, 183);
			this.Grid12.Margin = new System.Windows.Forms.Padding(1);
			this.Grid12.Name = "Grid12";
			this.Grid12.Size = new System.Drawing.Size(187, 178);
			this.Grid12.TabIndex = 5;
			// 
			// Grid20
			// 
			this.Grid20.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Grid20.Location = new System.Drawing.Point(3, 363);
			this.Grid20.Margin = new System.Windows.Forms.Padding(1);
			this.Grid20.Name = "Grid20";
			this.Grid20.Size = new System.Drawing.Size(187, 180);
			this.Grid20.TabIndex = 6;
			// 
			// Grid21
			// 
			this.Grid21.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Grid21.Location = new System.Drawing.Point(192, 363);
			this.Grid21.Margin = new System.Windows.Forms.Padding(1);
			this.Grid21.Name = "Grid21";
			this.Grid21.Size = new System.Drawing.Size(187, 180);
			this.Grid21.TabIndex = 7;
			// 
			// Grid22
			// 
			this.Grid22.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Grid22.Location = new System.Drawing.Point(381, 363);
			this.Grid22.Margin = new System.Windows.Forms.Padding(1);
			this.Grid22.Name = "Grid22";
			this.Grid22.Size = new System.Drawing.Size(187, 180);
			this.Grid22.TabIndex = 8;
			// 
			// SudokuGameBoard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.GameBoardTableLayoutPanel);
			this.DoubleBuffered = true;
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "SudokuGameBoard";
			this.Size = new System.Drawing.Size(571, 546);
			this.Load += new System.EventHandler(this.SudokuGameBoard_Load);
			this.GameBoardTableLayoutPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel GameBoardTableLayoutPanel;
		private SudokuThreeByThreeGrid Grid00;
		private SudokuThreeByThreeGrid Grid01;
		private SudokuThreeByThreeGrid Grid02;
		private SudokuThreeByThreeGrid Grid10;
		private SudokuThreeByThreeGrid Grid11;
		private SudokuThreeByThreeGrid Grid12;
		private SudokuThreeByThreeGrid Grid20;
		private SudokuThreeByThreeGrid Grid21;
		private SudokuThreeByThreeGrid Grid22;
	}
}
