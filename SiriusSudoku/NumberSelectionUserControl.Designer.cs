namespace SiriusSudoku
{
	partial class NumberSelectionUserControl
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NumberSelectionUserControl));
			this.NumberButtonsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.EraseButton = new System.Windows.Forms.Button();
			this.PencilButton = new System.Windows.Forms.Button();
			this.NumberButton8 = new SiriusSudoku.NumberSelectionButton();
			this.NumberButton7 = new SiriusSudoku.NumberSelectionButton();
			this.NumberButton6 = new SiriusSudoku.NumberSelectionButton();
			this.NumberButton5 = new SiriusSudoku.NumberSelectionButton();
			this.NumberButton4 = new SiriusSudoku.NumberSelectionButton();
			this.NumberButton3 = new SiriusSudoku.NumberSelectionButton();
			this.NumberButton1 = new SiriusSudoku.NumberSelectionButton();
			this.NumberButton2 = new SiriusSudoku.NumberSelectionButton();
			this.NumberButton9 = new SiriusSudoku.NumberSelectionButton();
			this.ButtonImageList = new System.Windows.Forms.ImageList(this.components);
			this.NumberButtonsTableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// NumberButtonsTableLayoutPanel
			// 
			this.NumberButtonsTableLayoutPanel.ColumnCount = 2;
			this.NumberButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.NumberButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.NumberButtonsTableLayoutPanel.Controls.Add(this.NumberButton8, 1, 3);
			this.NumberButtonsTableLayoutPanel.Controls.Add(this.NumberButton7, 0, 3);
			this.NumberButtonsTableLayoutPanel.Controls.Add(this.NumberButton6, 1, 2);
			this.NumberButtonsTableLayoutPanel.Controls.Add(this.NumberButton5, 0, 2);
			this.NumberButtonsTableLayoutPanel.Controls.Add(this.NumberButton4, 1, 1);
			this.NumberButtonsTableLayoutPanel.Controls.Add(this.NumberButton3, 0, 1);
			this.NumberButtonsTableLayoutPanel.Controls.Add(this.NumberButton1, 0, 0);
			this.NumberButtonsTableLayoutPanel.Controls.Add(this.NumberButton2, 1, 0);
			this.NumberButtonsTableLayoutPanel.Controls.Add(this.EraseButton, 1, 4);
			this.NumberButtonsTableLayoutPanel.Controls.Add(this.PencilButton, 1, 5);
			this.NumberButtonsTableLayoutPanel.Controls.Add(this.NumberButton9, 0, 4);
			this.NumberButtonsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NumberButtonsTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.NumberButtonsTableLayoutPanel.Name = "NumberButtonsTableLayoutPanel";
			this.NumberButtonsTableLayoutPanel.Padding = new System.Windows.Forms.Padding(2);
			this.NumberButtonsTableLayoutPanel.RowCount = 6;
			this.NumberButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.NumberButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.NumberButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.NumberButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.NumberButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.NumberButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.NumberButtonsTableLayoutPanel.Size = new System.Drawing.Size(136, 400);
			this.NumberButtonsTableLayoutPanel.TabIndex = 0;
			// 
			// EraseButton
			// 
			this.EraseButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EraseButton.ImageIndex = 0;
			this.EraseButton.ImageList = this.ButtonImageList;
			this.EraseButton.Location = new System.Drawing.Point(71, 269);
			this.EraseButton.MaximumSize = new System.Drawing.Size(60, 60);
			this.EraseButton.MinimumSize = new System.Drawing.Size(60, 60);
			this.EraseButton.Name = "EraseButton";
			this.EraseButton.Size = new System.Drawing.Size(60, 60);
			this.EraseButton.TabIndex = 9;
			this.EraseButton.UseVisualStyleBackColor = true;
			this.EraseButton.Click += new System.EventHandler(this.EraseButton_Click);
			// 
			// PencilButton
			// 
			this.PencilButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PencilButton.ImageKey = "Pencil 256x256.jpg";
			this.PencilButton.ImageList = this.ButtonImageList;
			this.PencilButton.Location = new System.Drawing.Point(71, 335);
			this.PencilButton.MaximumSize = new System.Drawing.Size(60, 60);
			this.PencilButton.MinimumSize = new System.Drawing.Size(60, 60);
			this.PencilButton.Name = "PencilButton";
			this.PencilButton.Size = new System.Drawing.Size(60, 60);
			this.PencilButton.TabIndex = 10;
			this.PencilButton.UseVisualStyleBackColor = true;
			this.PencilButton.Click += new System.EventHandler(this.PencilButton_Click);
			// 
			// NumberButton8
			// 
			this.NumberButton8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NumberButton8.Location = new System.Drawing.Point(71, 203);
			this.NumberButton8.MaximumSize = new System.Drawing.Size(60, 60);
			this.NumberButton8.MinimumSize = new System.Drawing.Size(60, 60);
			this.NumberButton8.Name = "NumberButton8";
			this.NumberButton8.Number = 8;
			this.NumberButton8.NumberCount = -1;
			this.NumberButton8.NumberCountLimit = -1;
			this.NumberButton8.Selected = false;
			this.NumberButton8.Size = new System.Drawing.Size(60, 60);
			this.NumberButton8.TabIndex = 7;
			// 
			// NumberButton7
			// 
			this.NumberButton7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NumberButton7.Location = new System.Drawing.Point(5, 203);
			this.NumberButton7.MaximumSize = new System.Drawing.Size(60, 60);
			this.NumberButton7.MinimumSize = new System.Drawing.Size(60, 60);
			this.NumberButton7.Name = "NumberButton7";
			this.NumberButton7.Number = 7;
			this.NumberButton7.NumberCount = -1;
			this.NumberButton7.NumberCountLimit = -1;
			this.NumberButton7.Selected = false;
			this.NumberButton7.Size = new System.Drawing.Size(60, 60);
			this.NumberButton7.TabIndex = 6;
			// 
			// NumberButton6
			// 
			this.NumberButton6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NumberButton6.Location = new System.Drawing.Point(71, 137);
			this.NumberButton6.MaximumSize = new System.Drawing.Size(60, 60);
			this.NumberButton6.MinimumSize = new System.Drawing.Size(60, 60);
			this.NumberButton6.Name = "NumberButton6";
			this.NumberButton6.Number = 6;
			this.NumberButton6.NumberCount = -1;
			this.NumberButton6.NumberCountLimit = -1;
			this.NumberButton6.Selected = false;
			this.NumberButton6.Size = new System.Drawing.Size(60, 60);
			this.NumberButton6.TabIndex = 5;
			// 
			// NumberButton5
			// 
			this.NumberButton5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NumberButton5.Location = new System.Drawing.Point(5, 137);
			this.NumberButton5.MaximumSize = new System.Drawing.Size(60, 60);
			this.NumberButton5.MinimumSize = new System.Drawing.Size(60, 60);
			this.NumberButton5.Name = "NumberButton5";
			this.NumberButton5.Number = 5;
			this.NumberButton5.NumberCount = -1;
			this.NumberButton5.NumberCountLimit = -1;
			this.NumberButton5.Selected = false;
			this.NumberButton5.Size = new System.Drawing.Size(60, 60);
			this.NumberButton5.TabIndex = 4;
			// 
			// NumberButton4
			// 
			this.NumberButton4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NumberButton4.Location = new System.Drawing.Point(71, 71);
			this.NumberButton4.MaximumSize = new System.Drawing.Size(60, 60);
			this.NumberButton4.MinimumSize = new System.Drawing.Size(60, 60);
			this.NumberButton4.Name = "NumberButton4";
			this.NumberButton4.Number = 4;
			this.NumberButton4.NumberCount = -1;
			this.NumberButton4.NumberCountLimit = -1;
			this.NumberButton4.Selected = false;
			this.NumberButton4.Size = new System.Drawing.Size(60, 60);
			this.NumberButton4.TabIndex = 3;
			// 
			// NumberButton3
			// 
			this.NumberButton3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NumberButton3.Location = new System.Drawing.Point(5, 71);
			this.NumberButton3.MaximumSize = new System.Drawing.Size(60, 60);
			this.NumberButton3.MinimumSize = new System.Drawing.Size(60, 60);
			this.NumberButton3.Name = "NumberButton3";
			this.NumberButton3.Number = 3;
			this.NumberButton3.NumberCount = -1;
			this.NumberButton3.NumberCountLimit = -1;
			this.NumberButton3.Selected = false;
			this.NumberButton3.Size = new System.Drawing.Size(60, 60);
			this.NumberButton3.TabIndex = 2;
			// 
			// NumberButton1
			// 
			this.NumberButton1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NumberButton1.Location = new System.Drawing.Point(5, 5);
			this.NumberButton1.MaximumSize = new System.Drawing.Size(60, 60);
			this.NumberButton1.MinimumSize = new System.Drawing.Size(60, 60);
			this.NumberButton1.Name = "NumberButton1";
			this.NumberButton1.Number = 1;
			this.NumberButton1.NumberCount = -1;
			this.NumberButton1.NumberCountLimit = -1;
			this.NumberButton1.Selected = false;
			this.NumberButton1.Size = new System.Drawing.Size(60, 60);
			this.NumberButton1.TabIndex = 0;
			// 
			// NumberButton2
			// 
			this.NumberButton2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NumberButton2.Location = new System.Drawing.Point(71, 5);
			this.NumberButton2.MaximumSize = new System.Drawing.Size(60, 60);
			this.NumberButton2.MinimumSize = new System.Drawing.Size(60, 60);
			this.NumberButton2.Name = "NumberButton2";
			this.NumberButton2.Number = 2;
			this.NumberButton2.NumberCount = -1;
			this.NumberButton2.NumberCountLimit = -1;
			this.NumberButton2.Selected = false;
			this.NumberButton2.Size = new System.Drawing.Size(60, 60);
			this.NumberButton2.TabIndex = 1;
			// 
			// NumberButton9
			// 
			this.NumberButton9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NumberButton9.Location = new System.Drawing.Point(5, 269);
			this.NumberButton9.MaximumSize = new System.Drawing.Size(60, 60);
			this.NumberButton9.MinimumSize = new System.Drawing.Size(60, 60);
			this.NumberButton9.Name = "NumberButton9";
			this.NumberButton9.Number = 9;
			this.NumberButton9.NumberCount = -1;
			this.NumberButton9.NumberCountLimit = -1;
			this.NumberButton9.Selected = false;
			this.NumberButton9.Size = new System.Drawing.Size(60, 60);
			this.NumberButton9.TabIndex = 8;
			// 
			// ButtonImageList
			// 
			this.ButtonImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonImageList.ImageStream")));
			this.ButtonImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.ButtonImageList.Images.SetKeyName(0, "Eraser 256x256.png");
			this.ButtonImageList.Images.SetKeyName(1, "NOT Eraser 256x256.png");
			this.ButtonImageList.Images.SetKeyName(2, "Pencil 256x256.jpg");
			this.ButtonImageList.Images.SetKeyName(3, "NOT Pencil 256x256.png");
			// 
			// NumberSelectionUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.NumberButtonsTableLayoutPanel);
			this.Name = "NumberSelectionUserControl";
			this.Size = new System.Drawing.Size(136, 400);
			this.Load += new System.EventHandler(this.NumberSelectionUserControl_Load);
			this.NumberButtonsTableLayoutPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel NumberButtonsTableLayoutPanel;
		private NumberSelectionButton NumberButton9;
		private NumberSelectionButton NumberButton8;
		private NumberSelectionButton NumberButton7;
		private NumberSelectionButton NumberButton6;
		private NumberSelectionButton NumberButton5;
		private NumberSelectionButton NumberButton4;
		private NumberSelectionButton NumberButton3;
		private NumberSelectionButton NumberButton1;
		private NumberSelectionButton NumberButton2;
		private System.Windows.Forms.Button EraseButton;
		private System.Windows.Forms.Button PencilButton;
		private System.Windows.Forms.ImageList ButtonImageList;
	}
}
