namespace SiriusSudoku
{
	partial class NumberSelectionButton
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
			// NumberSelectionButton
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.MaximumSize = new System.Drawing.Size(60, 60);
			this.MinimumSize = new System.Drawing.Size(60, 60);
			this.Name = "NumberSelectionButton";
			this.Size = new System.Drawing.Size(60, 60);
			this.Load += new System.EventHandler(this.NumberSelectionButton_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.NumberSelectionButton_Paint);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NumberSelectionButton_MouseClick);
			this.ResumeLayout(false);

		}

		#endregion
	}
}
