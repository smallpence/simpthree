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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Workspace));
			this.displayBox = new System.Windows.Forms.PictureBox();
			this.heartbeat = new System.Windows.Forms.Timer(this.components);
			this.barZoom = new System.Windows.Forms.TrackBar();
			this.barHorizontal = new System.Windows.Forms.HScrollBar();
			this.barVertical = new System.Windows.Forms.VScrollBar();
			this.panTools = new System.Windows.Forms.Panel();
			this.panToolProperties = new System.Windows.Forms.Panel();
			this.toolBar = new System.Windows.Forms.ToolStrip();
			this.btnUndo = new System.Windows.Forms.ToolStripButton();
			this.btnRedo = new System.Windows.Forms.ToolStripButton();
			this.panLayers = new System.Windows.Forms.Panel();
			this.panLayerSelector = new System.Windows.Forms.Panel();
			this.panLayerButtons = new System.Windows.Forms.Panel();
			this.btnNewLayer = new System.Windows.Forms.Button();
			this.btnRemoveLayer = new System.Windows.Forms.Button();
			this.btnLayerUp = new System.Windows.Forms.Button();
			this.btnLayerDown = new System.Windows.Forms.Button();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.displayBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barZoom)).BeginInit();
			this.toolBar.SuspendLayout();
			this.panLayers.SuspendLayout();
			this.panLayerButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// displayBox
			// 
			this.displayBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.displayBox.Location = new System.Drawing.Point(230, 48);
			this.displayBox.Name = "displayBox";
			this.displayBox.Size = new System.Drawing.Size(198, 209);
			this.displayBox.TabIndex = 0;
			this.displayBox.TabStop = false;
			this.displayBox.Click += new System.EventHandler(this.DisplayBoxClick);
			this.displayBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DisplayBoxMouseDown);
			this.displayBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DisplayBoxMouseMove);
			this.displayBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DisplayBoxMouseUp);
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
			this.barZoom.Location = new System.Drawing.Point(0, 291);
			this.barZoom.Maximum = 100;
			this.barZoom.Minimum = 1;
			this.barZoom.Name = "barZoom";
			this.barZoom.Size = new System.Drawing.Size(451, 20);
			this.barZoom.TabIndex = 1;
			this.barZoom.Value = 1;
			this.barZoom.Scroll += new System.EventHandler(this.BarZoomScroll);
			// 
			// barHorizontal
			// 
			this.barHorizontal.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barHorizontal.Enabled = false;
			this.barHorizontal.LargeChange = 1;
			this.barHorizontal.Location = new System.Drawing.Point(0, 271);
			this.barHorizontal.Maximum = 1;
			this.barHorizontal.Name = "barHorizontal";
			this.barHorizontal.Size = new System.Drawing.Size(451, 20);
			this.barHorizontal.TabIndex = 2;
			this.barHorizontal.ValueChanged += new System.EventHandler(this.BarHorizontalValueChanged);
			// 
			// barVertical
			// 
			this.barVertical.Dock = System.Windows.Forms.DockStyle.Right;
			this.barVertical.Location = new System.Drawing.Point(431, 25);
			this.barVertical.Name = "barVertical";
			this.barVertical.Size = new System.Drawing.Size(20, 246);
			this.barVertical.TabIndex = 3;
			this.barVertical.ValueChanged += new System.EventHandler(this.BarVerticalValueChanged);
			// 
			// panTools
			// 
			this.panTools.BackColor = System.Drawing.SystemColors.Control;
			this.panTools.Dock = System.Windows.Forms.DockStyle.Left;
			this.panTools.Location = new System.Drawing.Point(0, 25);
			this.panTools.Name = "panTools";
			this.panTools.Size = new System.Drawing.Size(24, 246);
			this.panTools.TabIndex = 4;
			// 
			// panToolProperties
			// 
			this.panToolProperties.BackColor = System.Drawing.SystemColors.Info;
			this.panToolProperties.Dock = System.Windows.Forms.DockStyle.Left;
			this.panToolProperties.Location = new System.Drawing.Point(24, 25);
			this.panToolProperties.Name = "panToolProperties";
			this.panToolProperties.Size = new System.Drawing.Size(200, 246);
			this.panToolProperties.TabIndex = 0;
			// 
			// toolBar
			// 
			this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.btnUndo,
									this.btnRedo});
			this.toolBar.Location = new System.Drawing.Point(0, 0);
			this.toolBar.Name = "toolBar";
			this.toolBar.Size = new System.Drawing.Size(651, 25);
			this.toolBar.TabIndex = 0;
			// 
			// btnUndo
			// 
			this.btnUndo.Enabled = false;
			this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
			this.btnUndo.Name = "btnUndo";
			this.btnUndo.Size = new System.Drawing.Size(23, 22);
			this.btnUndo.Click += new System.EventHandler(this.BtnUndoClick);
			// 
			// btnRedo
			// 
			this.btnRedo.Enabled = false;
			this.btnRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
			this.btnRedo.Name = "btnRedo";
			this.btnRedo.Size = new System.Drawing.Size(23, 22);
			this.btnRedo.Click += new System.EventHandler(this.BtnRedoClick);
			// 
			// panLayers
			// 
			this.panLayers.Controls.Add(this.panLayerSelector);
			this.panLayers.Controls.Add(this.panLayerButtons);
			this.panLayers.Dock = System.Windows.Forms.DockStyle.Right;
			this.panLayers.Location = new System.Drawing.Point(451, 25);
			this.panLayers.Name = "panLayers";
			this.panLayers.Size = new System.Drawing.Size(200, 286);
			this.panLayers.TabIndex = 0;
			// 
			// panLayerSelector
			// 
			this.panLayerSelector.AutoScroll = true;
			this.panLayerSelector.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.panLayerSelector.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panLayerSelector.Location = new System.Drawing.Point(0, 0);
			this.panLayerSelector.Name = "panLayerSelector";
			this.panLayerSelector.Size = new System.Drawing.Size(200, 230);
			this.panLayerSelector.TabIndex = 0;
			// 
			// panLayerButtons
			// 
			this.panLayerButtons.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.panLayerButtons.Controls.Add(this.btnNewLayer);
			this.panLayerButtons.Controls.Add(this.btnRemoveLayer);
			this.panLayerButtons.Controls.Add(this.btnLayerUp);
			this.panLayerButtons.Controls.Add(this.btnLayerDown);
			this.panLayerButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panLayerButtons.Location = new System.Drawing.Point(0, 230);
			this.panLayerButtons.Name = "panLayerButtons";
			this.panLayerButtons.Size = new System.Drawing.Size(200, 56);
			this.panLayerButtons.TabIndex = 0;
			// 
			// btnNewLayer
			// 
			this.btnNewLayer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNewLayer.BackgroundImage")));
			this.btnNewLayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnNewLayer.Location = new System.Drawing.Point(10, 9);
			this.btnNewLayer.Name = "btnNewLayer";
			this.btnNewLayer.Size = new System.Drawing.Size(40, 40);
			this.btnNewLayer.TabIndex = 0;
			this.btnNewLayer.Click += new System.EventHandler(this.BtnNewLayerClick);
			// 
			// btnRemoveLayer
			// 
			this.btnRemoveLayer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveLayer.BackgroundImage")));
			this.btnRemoveLayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnRemoveLayer.Location = new System.Drawing.Point(56, 9);
			this.btnRemoveLayer.Name = "btnRemoveLayer";
			this.btnRemoveLayer.Size = new System.Drawing.Size(40, 40);
			this.btnRemoveLayer.TabIndex = 0;
			this.btnRemoveLayer.Click += new System.EventHandler(this.BtnRemoveLayerClick);
			// 
			// btnLayerUp
			// 
			this.btnLayerUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLayerUp.BackgroundImage")));
			this.btnLayerUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnLayerUp.Location = new System.Drawing.Point(102, 9);
			this.btnLayerUp.Name = "btnLayerUp";
			this.btnLayerUp.Size = new System.Drawing.Size(40, 40);
			this.btnLayerUp.TabIndex = 0;
			this.btnLayerUp.Click += new System.EventHandler(this.BtnLayerUpClick);
			// 
			// btnLayerDown
			// 
			this.btnLayerDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLayerDown.BackgroundImage")));
			this.btnLayerDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnLayerDown.Location = new System.Drawing.Point(148, 9);
			this.btnLayerDown.Name = "btnLayerDown";
			this.btnLayerDown.Size = new System.Drawing.Size(40, 40);
			this.btnLayerDown.TabIndex = 0;
			this.btnLayerDown.Click += new System.EventHandler(this.BtnLayerDownClick);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "toolStripButton1";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// Workspace
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(651, 311);
			this.Controls.Add(this.panToolProperties);
			this.Controls.Add(this.panTools);
			this.Controls.Add(this.barVertical);
			this.Controls.Add(this.barHorizontal);
			this.Controls.Add(this.barZoom);
			this.Controls.Add(this.displayBox);
			this.Controls.Add(this.panLayers);
			this.Controls.Add(this.toolBar);
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(98, 94);
			this.Name = "Workspace";
			this.Text = "WorkSpace";
			this.ResizeEnd += new System.EventHandler(this.WorkspaceResizeEnd);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WorkspaceKeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WorkspaceKeyUp);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WorkspaceMouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WorkspaceMouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WorkspaceMouseUp);
			((System.ComponentModel.ISupportInitialize)(this.displayBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barZoom)).EndInit();
			this.toolBar.ResumeLayout(false);
			this.toolBar.PerformLayout();
			this.panLayers.ResumeLayout(false);
			this.panLayerButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.Panel panLayerSelector;
		private System.Windows.Forms.Button btnNewLayer;
		private System.Windows.Forms.Button btnRemoveLayer;
		private System.Windows.Forms.Button btnLayerUp;
		private System.Windows.Forms.Button btnLayerDown;
		private System.Windows.Forms.Panel panLayerButtons;
		private System.Windows.Forms.Panel panLayers;
		private System.Windows.Forms.ToolStripButton btnRedo;
		private System.Windows.Forms.ToolStripButton btnUndo;
		private System.Windows.Forms.ToolStrip toolBar;
		private System.Windows.Forms.Panel panToolProperties;
		private System.Windows.Forms.Panel panTools;
		private System.Windows.Forms.VScrollBar barVertical;
		private System.Windows.Forms.HScrollBar barHorizontal;
		private System.Windows.Forms.TrackBar barZoom;
		private System.Windows.Forms.Timer heartbeat;
	}
}
