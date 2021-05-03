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
	partial class Workspace
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
			this.components = new System.ComponentModel.Container();
			this.displayBox = new System.Windows.Forms.PictureBox();
			this.heartbeat = new System.Windows.Forms.Timer(this.components);
			this.barZoom = new System.Windows.Forms.TrackBar();
			this.barHorizontal = new System.Windows.Forms.HScrollBar();
			this.barVertical = new System.Windows.Forms.VScrollBar();
			((System.ComponentModel.ISupportInitialize)(this.displayBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barZoom)).BeginInit();
			this.SuspendLayout();
			// 
			// displayBox
			// 
			this.displayBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.displayBox.Location = new System.Drawing.Point(33, 44);
			this.displayBox.Margin = new System.Windows.Forms.Padding(4);
			this.displayBox.Name = "displayBox";
			this.displayBox.Size = new System.Drawing.Size(347, 292);
			this.displayBox.TabIndex = 0;
			this.displayBox.TabStop = false;
			this.displayBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DisplayBoxMouseDown);
			this.displayBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DisplayBoxMouseMove);
			// 
			// heartbeat
			// 
			this.heartbeat.Enabled = true;
			this.heartbeat.Interval = 10;
			this.heartbeat.Tick += new System.EventHandler(this.HeartbeatTick);
			// 
			// barZoom
			// 
			this.barZoom.AutoSize = false;
			this.barZoom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barZoom.Location = new System.Drawing.Point(0, 358);
			this.barZoom.Margin = new System.Windows.Forms.Padding(4);
			this.barZoom.Maximum = 100;
			this.barZoom.Minimum = 1;
			this.barZoom.Name = "barZoom";
			this.barZoom.Size = new System.Drawing.Size(417, 25);
			this.barZoom.TabIndex = 1;
			this.barZoom.Value = 1;
			this.barZoom.Scroll += new System.EventHandler(this.BarZoomScroll);
			// 
			// barHorizontal
			// 
			this.barHorizontal.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barHorizontal.Enabled = false;
			this.barHorizontal.LargeChange = 1;
			this.barHorizontal.Location = new System.Drawing.Point(0, 338);
			this.barHorizontal.Maximum = 1;
			this.barHorizontal.Name = "barHorizontal";
			this.barHorizontal.Size = new System.Drawing.Size(417, 20);
			this.barHorizontal.TabIndex = 2;
			this.barHorizontal.ValueChanged += new System.EventHandler(this.BarHorizontalValueChanged);
			// 
			// barVertical
			// 
			this.barVertical.Dock = System.Windows.Forms.DockStyle.Right;
			this.barVertical.Location = new System.Drawing.Point(397, 0);
			this.barVertical.Name = "barVertical";
			this.barVertical.Size = new System.Drawing.Size(20, 338);
			this.barVertical.TabIndex = 3;
			this.barVertical.ValueChanged += new System.EventHandler(this.BarVerticalValueChanged);
			// 
			// Workspace
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(417, 383);
			this.Controls.Add(this.barVertical);
			this.Controls.Add(this.barHorizontal);
			this.Controls.Add(this.barZoom);
			this.Controls.Add(this.displayBox);
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(127, 112);
			this.Name = "Workspace";
			this.Text = "WorkSpace";
			this.ResizeEnd += new System.EventHandler(this.WorkspaceResizeEnd);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WorkspaceKeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WorkspaceKeyUp);
			((System.ComponentModel.ISupportInitialize)(this.displayBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barZoom)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.VScrollBar barVertical;
		private System.Windows.Forms.HScrollBar barHorizontal;
		private System.Windows.Forms.TrackBar barZoom;
		private System.Windows.Forms.Timer heartbeat;
	}
}
