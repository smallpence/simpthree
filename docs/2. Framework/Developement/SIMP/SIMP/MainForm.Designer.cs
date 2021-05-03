/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 18/09/2019
 * Time: 15:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SIMP
{
	partial class MainForm
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
			this.btnCreate = new System.Windows.Forms.Button();
			this.numWidth = new System.Windows.Forms.NumericUpDown();
			this.numHeight = new System.Windows.Forms.NumericUpDown();
			this.lblWidth = new System.Windows.Forms.Label();
			this.lblHeight = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(74, 109);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(120, 31);
			this.btnCreate.TabIndex = 0;
			this.btnCreate.Text = "Create New Image";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.BtnCreateClick);
			// 
			// numWidth
			// 
			this.numWidth.Location = new System.Drawing.Point(74, 42);
			this.numWidth.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.numWidth.Name = "numWidth";
			this.numWidth.Size = new System.Drawing.Size(120, 20);
			this.numWidth.TabIndex = 1;
			this.numWidth.Value = new decimal(new int[] {
									25,
									0,
									0,
									0});
			// 
			// numHeight
			// 
			this.numHeight.Location = new System.Drawing.Point(74, 83);
			this.numHeight.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.numHeight.Name = "numHeight";
			this.numHeight.Size = new System.Drawing.Size(120, 20);
			this.numHeight.TabIndex = 2;
			this.numHeight.Value = new decimal(new int[] {
									25,
									0,
									0,
									0});
			// 
			// lblWidth
			// 
			this.lblWidth.Location = new System.Drawing.Point(74, 25);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(100, 14);
			this.lblWidth.TabIndex = 3;
			this.lblWidth.Text = "Width";
			// 
			// lblHeight
			// 
			this.lblHeight.Location = new System.Drawing.Point(74, 66);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new System.Drawing.Size(100, 14);
			this.lblHeight.TabIndex = 4;
			this.lblHeight.Text = "Height";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(267, 261);
			this.Controls.Add(this.lblHeight);
			this.Controls.Add(this.lblWidth);
			this.Controls.Add(this.numHeight);
			this.Controls.Add(this.numWidth);
			this.Controls.Add(this.btnCreate);
			this.Name = "MainForm";
			this.Text = "SIMP";
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.NumericUpDown numHeight;
		private System.Windows.Forms.NumericUpDown numWidth;
		private System.Windows.Forms.Button btnCreate;
	}
}
