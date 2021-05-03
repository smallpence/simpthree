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
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnImport = new System.Windows.Forms.Button();
			this.diaOpen = new System.Windows.Forms.OpenFileDialog();
			this.diaImport = new System.Windows.Forms.OpenFileDialog();
			this.lblTitle = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(42, 176);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(120, 31);
			this.btnCreate.TabIndex = 0;
			this.btnCreate.Text = "Create New Image";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.BtnCreateClick);
			// 
			// numWidth
			// 
			this.numWidth.Location = new System.Drawing.Point(42, 109);
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
			this.numHeight.Location = new System.Drawing.Point(42, 150);
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
			this.lblWidth.Location = new System.Drawing.Point(42, 92);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(100, 14);
			this.lblWidth.TabIndex = 3;
			this.lblWidth.Text = "Width";
			// 
			// lblHeight
			// 
			this.lblHeight.Location = new System.Drawing.Point(42, 133);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new System.Drawing.Size(100, 14);
			this.lblHeight.TabIndex = 4;
			this.lblHeight.Text = "Height";
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(42, 231);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(120, 31);
			this.btnOpen.TabIndex = 5;
			this.btnOpen.Text = "Open SIMP File";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.BtnOpenClick);
			// 
			// btnImport
			// 
			this.btnImport.Location = new System.Drawing.Point(42, 268);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(120, 31);
			this.btnImport.TabIndex = 6;
			this.btnImport.Text = "Import Image";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.BtnImportClick);
			// 
			// diaOpen
			// 
			this.diaOpen.Filter = "SIMP Files|*.simp";
			// 
			// diaImport
			// 
			this.diaImport.Filter = "Image Files|*.bmp;*.jpg;*.png";
			// 
			// lblTitle
			// 
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(12, 9);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(182, 83);
			this.lblTitle.TabIndex = 7;
			this.lblTitle.Text = "SIMP Launcher";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(205, 324);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.btnImport);
			this.Controls.Add(this.btnOpen);
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
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.OpenFileDialog diaImport;
		private System.Windows.Forms.OpenFileDialog diaOpen;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.NumericUpDown numHeight;
		private System.Windows.Forms.NumericUpDown numWidth;
		private System.Windows.Forms.Button btnCreate;
	}
}
