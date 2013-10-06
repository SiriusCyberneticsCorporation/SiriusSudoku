namespace SiriusSudoku
{
	partial class NewPlayerForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.PlayerNameTextBox = new System.Windows.Forms.TextBox();
			this.OKButton = new System.Windows.Forms.Button();
			this.TheCancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(179, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "New player, please enter your name.";
			// 
			// PlayerNameTextBox
			// 
			this.PlayerNameTextBox.Location = new System.Drawing.Point(12, 25);
			this.PlayerNameTextBox.Name = "PlayerNameTextBox";
			this.PlayerNameTextBox.Size = new System.Drawing.Size(179, 20);
			this.PlayerNameTextBox.TabIndex = 1;
			// 
			// OKButton
			// 
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Location = new System.Drawing.Point(12, 51);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 2;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			// 
			// TheCancelButton
			// 
			this.TheCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.TheCancelButton.Location = new System.Drawing.Point(116, 51);
			this.TheCancelButton.Name = "TheCancelButton";
			this.TheCancelButton.Size = new System.Drawing.Size(75, 23);
			this.TheCancelButton.TabIndex = 3;
			this.TheCancelButton.Text = "Cancel";
			this.TheCancelButton.UseVisualStyleBackColor = true;
			// 
			// NewPlayerForm
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.TheCancelButton;
			this.ClientSize = new System.Drawing.Size(203, 83);
			this.Controls.Add(this.TheCancelButton);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.PlayerNameTextBox);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewPlayerForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Player";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox PlayerNameTextBox;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button TheCancelButton;
	}
}