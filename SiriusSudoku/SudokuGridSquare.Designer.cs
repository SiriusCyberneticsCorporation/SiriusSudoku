namespace SiriusSudoku
{
	partial class SudokuGridSquare
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
			this.SuspendLayout();
			// 
			// SudokuGridSquare
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.MaximumSize = new System.Drawing.Size(60, 60);
			this.MinimumSize = new System.Drawing.Size(60, 60);
			this.Name = "SudokuGridSquare";
			this.Size = new System.Drawing.Size(60, 60);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.SudokuGridSquare_Paint);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SudokuGridSquare_MouseClick);
			this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SudokuGridSquare_MouseDoubleClick);
			this.ResumeLayout(false);

		}

		#endregion
	}
}
