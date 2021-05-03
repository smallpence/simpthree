/*
 * Created by SharpDevelop.
 * User: 13SYoung
 * Date: 09/11/2019
 * Time: 15:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SIMP
{
	partial class RGBPicker
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.picColourSquare = new System.Windows.Forms.PictureBox();
			this.picColourStrip = new System.Windows.Forms.PictureBox();
			this.picStartColour = new System.Windows.Forms.PictureBox();
			this.picCurrentColour = new System.Windows.Forms.PictureBox();
			this.numR = new System.Windows.Forms.NumericUpDown();
			this.numG = new System.Windows.Forms.NumericUpDown();
			this.numB = new System.Windows.Forms.NumericUpDown();
			this.txtRGB = new System.Windows.Forms.TextBox();
			this.picRecentColours = new System.Windows.Forms.PictureBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.picColourSquare)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picColourStrip)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picStartColour)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picCurrentColour)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numR)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numG)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picRecentColours)).BeginInit();
			this.SuspendLayout();
			// 
			// picColourSquare
			// 
			this.picColourSquare.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.picColourSquare.Cursor = System.Windows.Forms.Cursors.Cross;
			this.picColourSquare.Location = new System.Drawing.Point(12, 12);
			this.picColourSquare.Name = "picColourSquare";
			this.picColourSquare.Size = new System.Drawing.Size(100, 100);
			this.picColourSquare.TabIndex = 0;
			this.picColourSquare.TabStop = false;
			this.picColourSquare.Click += new System.EventHandler(this.PicColourSquareClick);
			this.picColourSquare.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicColourSquareMouseMove);
			// 
			// picColourStrip
			// 
			this.picColourStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.picColourStrip.Cursor = System.Windows.Forms.Cursors.Cross;
			this.picColourStrip.Location = new System.Drawing.Point(127, 12);
			this.picColourStrip.Name = "picColourStrip";
			this.picColourStrip.Size = new System.Drawing.Size(20, 100);
			this.picColourStrip.TabIndex = 1;
			this.picColourStrip.TabStop = false;
			this.picColourStrip.Click += new System.EventHandler(this.PicColourStripClick);
			this.picColourStrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicColourStripMouseMove);
			// 
			// picStartColour
			// 
			this.picStartColour.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.picStartColour.Location = new System.Drawing.Point(12, 127);
			this.picStartColour.Name = "picStartColour";
			this.picStartColour.Size = new System.Drawing.Size(135, 24);
			this.picStartColour.TabIndex = 2;
			this.picStartColour.TabStop = false;
			// 
			// picCurrentColour
			// 
			this.picCurrentColour.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.picCurrentColour.Location = new System.Drawing.Point(12, 157);
			this.picCurrentColour.Name = "picCurrentColour";
			this.picCurrentColour.Size = new System.Drawing.Size(135, 24);
			this.picCurrentColour.TabIndex = 3;
			this.picCurrentColour.TabStop = false;
			// 
			// numR
			// 
			this.numR.Location = new System.Drawing.Point(12, 195);
			this.numR.Maximum = new decimal(new int[] {
									255,
									0,
									0,
									0});
			this.numR.Name = "numR";
			this.numR.Size = new System.Drawing.Size(41, 20);
			this.numR.TabIndex = 4;
			this.numR.ValueChanged += new System.EventHandler(this.NumRValueChanged);
			// 
			// numG
			// 
			this.numG.Location = new System.Drawing.Point(59, 195);
			this.numG.Maximum = new decimal(new int[] {
									255,
									0,
									0,
									0});
			this.numG.Name = "numG";
			this.numG.Size = new System.Drawing.Size(41, 20);
			this.numG.TabIndex = 5;
			this.numG.ValueChanged += new System.EventHandler(this.NumGValueChanged);
			// 
			// numB
			// 
			this.numB.Location = new System.Drawing.Point(106, 195);
			this.numB.Maximum = new decimal(new int[] {
									255,
									0,
									0,
									0});
			this.numB.Name = "numB";
			this.numB.Size = new System.Drawing.Size(41, 20);
			this.numB.TabIndex = 6;
			this.numB.ValueChanged += new System.EventHandler(this.NumBValueChanged);
			// 
			// txtRGB
			// 
			this.txtRGB.Location = new System.Drawing.Point(12, 228);
			this.txtRGB.Name = "txtRGB";
			this.txtRGB.ReadOnly = true;
			this.txtRGB.Size = new System.Drawing.Size(135, 20);
			this.txtRGB.TabIndex = 7;
			// 
			// picRecentColours
			// 
			this.picRecentColours.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.picRecentColours.Location = new System.Drawing.Point(177, 12);
			this.picRecentColours.Name = "picRecentColours";
			this.picRecentColours.Size = new System.Drawing.Size(20, 236);
			this.picRecentColours.TabIndex = 8;
			this.picRecentColours.TabStop = false;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(12, 266);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(88, 23);
			this.btnSave.TabIndex = 9;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(106, 266);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(91, 23);
			this.btnClose.TabIndex = 10;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
			// 
			// RGBPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(209, 301);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.picRecentColours);
			this.Controls.Add(this.txtRGB);
			this.Controls.Add(this.numB);
			this.Controls.Add(this.numG);
			this.Controls.Add(this.numR);
			this.Controls.Add(this.picCurrentColour);
			this.Controls.Add(this.picStartColour);
			this.Controls.Add(this.picColourStrip);
			this.Controls.Add(this.picColourSquare);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "RGBPicker";
			this.Text = "RGBPicker";
			((System.ComponentModel.ISupportInitialize)(this.picColourSquare)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picColourStrip)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picStartColour)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picCurrentColour)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numR)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numG)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picRecentColours)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.PictureBox picRecentColours;
		private System.Windows.Forms.TextBox txtRGB;
		private System.Windows.Forms.NumericUpDown numB;
		private System.Windows.Forms.NumericUpDown numG;
		private System.Windows.Forms.NumericUpDown numR;
		private System.Windows.Forms.PictureBox picCurrentColour;
		private System.Windows.Forms.PictureBox picStartColour;
		private System.Windows.Forms.PictureBox picColourStrip;
		private System.Windows.Forms.PictureBox picColourSquare;
	}
}
