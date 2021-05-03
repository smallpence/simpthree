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
			this.strpMenu = new System.Windows.Forms.MenuStrip();
			this.btnOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.btnImport = new System.Windows.Forms.ToolStripMenuItem();
			this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
			this.diaOpen = new System.Windows.Forms.OpenFileDialog();
			this.diaImport = new System.Windows.Forms.OpenFileDialog();
			this.diaSave = new System.Windows.Forms.SaveFileDialog();
			this.diaExport = new System.Windows.Forms.SaveFileDialog();
			this.btnPenIcon = new System.Windows.Forms.Button();
			this.btnPencilIcon = new System.Windows.Forms.Button();
			this.btnEraserIcon = new System.Windows.Forms.Button();
			this.btnLineIcon = new System.Windows.Forms.Button();
			this.btnRectangleIcon = new System.Windows.Forms.Button();
			this.btnCircleIcon = new System.Windows.Forms.Button();
			this.btnDiamondIcon = new System.Windows.Forms.Button();
			this.btnFillIcon = new System.Windows.Forms.Button();
			this.btnFXIcon = new System.Windows.Forms.Button();
			this.btnEyedropperIcon = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.displayBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barZoom)).BeginInit();
			this.toolBar.SuspendLayout();
			this.panLayers.SuspendLayout();
			this.panLayerButtons.SuspendLayout();
			this.strpMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// displayBox
			// 
			this.displayBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.displayBox.Location = new System.Drawing.Point(307, 59);
			this.displayBox.Margin = new System.Windows.Forms.Padding(4);
			this.displayBox.Name = "displayBox";
			this.displayBox.Size = new System.Drawing.Size(264, 257);
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
			this.barZoom.Location = new System.Drawing.Point(299, 358);
			this.barZoom.Margin = new System.Windows.Forms.Padding(4);
			this.barZoom.Maximum = 100;
			this.barZoom.Minimum = 1;
			this.barZoom.Name = "barZoom";
			this.barZoom.Size = new System.Drawing.Size(302, 25);
			this.barZoom.TabIndex = 1;
			this.barZoom.Value = 1;
			this.barZoom.Scroll += new System.EventHandler(this.BarZoomScroll);
			// 
			// barHorizontal
			// 
			this.barHorizontal.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barHorizontal.Enabled = false;
			this.barHorizontal.LargeChange = 1;
			this.barHorizontal.Location = new System.Drawing.Point(299, 338);
			this.barHorizontal.Maximum = 1;
			this.barHorizontal.Name = "barHorizontal";
			this.barHorizontal.Size = new System.Drawing.Size(302, 20);
			this.barHorizontal.TabIndex = 2;
			this.barHorizontal.ValueChanged += new System.EventHandler(this.BarHorizontalValueChanged);
			// 
			// barVertical
			// 
			this.barVertical.Dock = System.Windows.Forms.DockStyle.Right;
			this.barVertical.Location = new System.Drawing.Point(581, 53);
			this.barVertical.Name = "barVertical";
			this.barVertical.Size = new System.Drawing.Size(20, 285);
			this.barVertical.TabIndex = 3;
			this.barVertical.ValueChanged += new System.EventHandler(this.BarVerticalValueChanged);
			// 
			// panTools
			// 
			this.panTools.BackColor = System.Drawing.SystemColors.Control;
			this.panTools.Dock = System.Windows.Forms.DockStyle.Left;
			this.panTools.Location = new System.Drawing.Point(267, 53);
			this.panTools.Margin = new System.Windows.Forms.Padding(4);
			this.panTools.Name = "panTools";
			this.panTools.Size = new System.Drawing.Size(32, 330);
			this.panTools.TabIndex = 4;
			// 
			// panToolProperties
			// 
			this.panToolProperties.BackColor = System.Drawing.SystemColors.Info;
			this.panToolProperties.Dock = System.Windows.Forms.DockStyle.Left;
			this.panToolProperties.Location = new System.Drawing.Point(0, 53);
			this.panToolProperties.Margin = new System.Windows.Forms.Padding(4);
			this.panToolProperties.Name = "panToolProperties";
			this.panToolProperties.Size = new System.Drawing.Size(267, 330);
			this.panToolProperties.TabIndex = 0;
			// 
			// toolBar
			// 
			this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.btnUndo,
									this.btnRedo});
			this.toolBar.Location = new System.Drawing.Point(0, 0);
			this.toolBar.Name = "toolBar";
			this.toolBar.Size = new System.Drawing.Size(868, 25);
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
			this.panLayers.Location = new System.Drawing.Point(601, 53);
			this.panLayers.Margin = new System.Windows.Forms.Padding(4);
			this.panLayers.Name = "panLayers";
			this.panLayers.Size = new System.Drawing.Size(267, 330);
			this.panLayers.TabIndex = 0;
			// 
			// panLayerSelector
			// 
			this.panLayerSelector.AutoScroll = true;
			this.panLayerSelector.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.panLayerSelector.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panLayerSelector.Location = new System.Drawing.Point(0, 0);
			this.panLayerSelector.Margin = new System.Windows.Forms.Padding(4);
			this.panLayerSelector.Name = "panLayerSelector";
			this.panLayerSelector.Size = new System.Drawing.Size(267, 261);
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
			this.panLayerButtons.Location = new System.Drawing.Point(0, 261);
			this.panLayerButtons.Margin = new System.Windows.Forms.Padding(4);
			this.panLayerButtons.Name = "panLayerButtons";
			this.panLayerButtons.Size = new System.Drawing.Size(267, 69);
			this.panLayerButtons.TabIndex = 0;
			// 
			// btnNewLayer
			// 
			this.btnNewLayer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNewLayer.BackgroundImage")));
			this.btnNewLayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnNewLayer.Location = new System.Drawing.Point(13, 11);
			this.btnNewLayer.Margin = new System.Windows.Forms.Padding(4);
			this.btnNewLayer.Name = "btnNewLayer";
			this.btnNewLayer.Size = new System.Drawing.Size(53, 49);
			this.btnNewLayer.TabIndex = 0;
			this.btnNewLayer.Click += new System.EventHandler(this.BtnNewLayerClick);
			// 
			// btnRemoveLayer
			// 
			this.btnRemoveLayer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveLayer.BackgroundImage")));
			this.btnRemoveLayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnRemoveLayer.Location = new System.Drawing.Point(75, 11);
			this.btnRemoveLayer.Margin = new System.Windows.Forms.Padding(4);
			this.btnRemoveLayer.Name = "btnRemoveLayer";
			this.btnRemoveLayer.Size = new System.Drawing.Size(53, 49);
			this.btnRemoveLayer.TabIndex = 0;
			this.btnRemoveLayer.Click += new System.EventHandler(this.BtnRemoveLayerClick);
			// 
			// btnLayerUp
			// 
			this.btnLayerUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLayerUp.BackgroundImage")));
			this.btnLayerUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnLayerUp.Location = new System.Drawing.Point(136, 11);
			this.btnLayerUp.Margin = new System.Windows.Forms.Padding(4);
			this.btnLayerUp.Name = "btnLayerUp";
			this.btnLayerUp.Size = new System.Drawing.Size(53, 49);
			this.btnLayerUp.TabIndex = 0;
			this.btnLayerUp.Click += new System.EventHandler(this.BtnLayerUpClick);
			// 
			// btnLayerDown
			// 
			this.btnLayerDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLayerDown.BackgroundImage")));
			this.btnLayerDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnLayerDown.Location = new System.Drawing.Point(197, 11);
			this.btnLayerDown.Margin = new System.Windows.Forms.Padding(4);
			this.btnLayerDown.Name = "btnLayerDown";
			this.btnLayerDown.Size = new System.Drawing.Size(53, 49);
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
			// strpMenu
			// 
			this.strpMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.btnOpen,
									this.btnSave,
									this.btnSaveAs,
									this.btnImport,
									this.btnExport});
			this.strpMenu.Location = new System.Drawing.Point(0, 25);
			this.strpMenu.Name = "strpMenu";
			this.strpMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
			this.strpMenu.Size = new System.Drawing.Size(868, 28);
			this.strpMenu.TabIndex = 5;
			this.strpMenu.Text = "menuStrip1";
			// 
			// btnOpen
			// 
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(57, 24);
			this.btnOpen.Text = "Open";
			this.btnOpen.Click += new System.EventHandler(this.BtnOpenClick);
			// 
			// btnSave
			// 
			this.btnSave.Enabled = false;
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(52, 24);
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
			// 
			// btnSaveAs
			// 
			this.btnSaveAs.Name = "btnSaveAs";
			this.btnSaveAs.Size = new System.Drawing.Size(72, 24);
			this.btnSaveAs.Text = "Save As";
			this.btnSaveAs.Click += new System.EventHandler(this.BtnSaveAsClick);
			// 
			// btnImport
			// 
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(66, 24);
			this.btnImport.Text = "Import";
			this.btnImport.Click += new System.EventHandler(this.BtnImportClick);
			// 
			// btnExport
			// 
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(64, 24);
			this.btnExport.Text = "Export";
			this.btnExport.Click += new System.EventHandler(this.BtnExportClick);
			// 
			// diaOpen
			// 
			this.diaOpen.Filter = "SIMP Files|*.simp";
			// 
			// diaImport
			// 
			this.diaImport.Filter = "Image Files|*.bmp;*.jpg;*.png";
			// 
			// diaSave
			// 
			this.diaSave.Filter = "SIMP Files|*.simp";
			// 
			// diaExport
			// 
			this.diaExport.Filter = "Image Files|*.bmp;*.jpg;*.png";
			// 
			// btnPenIcon
			// 
			this.btnPenIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPenIcon.BackgroundImage")));
			this.btnPenIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnPenIcon.Location = new System.Drawing.Point(307, 59);
			this.btnPenIcon.Name = "btnPenIcon";
			this.btnPenIcon.Size = new System.Drawing.Size(24, 24);
			this.btnPenIcon.TabIndex = 6;
			this.btnPenIcon.UseVisualStyleBackColor = true;
			this.btnPenIcon.Visible = false;
			// 
			// btnPencilIcon
			// 
			this.btnPencilIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPencilIcon.BackgroundImage")));
			this.btnPencilIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnPencilIcon.Location = new System.Drawing.Point(307, 89);
			this.btnPencilIcon.Name = "btnPencilIcon";
			this.btnPencilIcon.Size = new System.Drawing.Size(24, 24);
			this.btnPencilIcon.TabIndex = 7;
			this.btnPencilIcon.UseVisualStyleBackColor = true;
			this.btnPencilIcon.Visible = false;
			// 
			// btnEraserIcon
			// 
			this.btnEraserIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEraserIcon.BackgroundImage")));
			this.btnEraserIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnEraserIcon.Location = new System.Drawing.Point(307, 119);
			this.btnEraserIcon.Name = "btnEraserIcon";
			this.btnEraserIcon.Size = new System.Drawing.Size(24, 24);
			this.btnEraserIcon.TabIndex = 8;
			this.btnEraserIcon.UseVisualStyleBackColor = true;
			this.btnEraserIcon.Visible = false;
			// 
			// btnLineIcon
			// 
			this.btnLineIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLineIcon.BackgroundImage")));
			this.btnLineIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnLineIcon.Location = new System.Drawing.Point(307, 149);
			this.btnLineIcon.Name = "btnLineIcon";
			this.btnLineIcon.Size = new System.Drawing.Size(24, 24);
			this.btnLineIcon.TabIndex = 9;
			this.btnLineIcon.UseVisualStyleBackColor = true;
			this.btnLineIcon.Visible = false;
			// 
			// btnRectangleIcon
			// 
			this.btnRectangleIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRectangleIcon.BackgroundImage")));
			this.btnRectangleIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnRectangleIcon.Location = new System.Drawing.Point(307, 179);
			this.btnRectangleIcon.Name = "btnRectangleIcon";
			this.btnRectangleIcon.Size = new System.Drawing.Size(24, 24);
			this.btnRectangleIcon.TabIndex = 10;
			this.btnRectangleIcon.UseVisualStyleBackColor = true;
			this.btnRectangleIcon.Visible = false;
			// 
			// btnCircleIcon
			// 
			this.btnCircleIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCircleIcon.BackgroundImage")));
			this.btnCircleIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnCircleIcon.Location = new System.Drawing.Point(307, 209);
			this.btnCircleIcon.Name = "btnCircleIcon";
			this.btnCircleIcon.Size = new System.Drawing.Size(24, 24);
			this.btnCircleIcon.TabIndex = 11;
			this.btnCircleIcon.UseVisualStyleBackColor = true;
			this.btnCircleIcon.Visible = false;
			// 
			// btnDiamondIcon
			// 
			this.btnDiamondIcon.BackColor = System.Drawing.Color.White;
			this.btnDiamondIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDiamondIcon.BackgroundImage")));
			this.btnDiamondIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnDiamondIcon.Location = new System.Drawing.Point(307, 239);
			this.btnDiamondIcon.Name = "btnDiamondIcon";
			this.btnDiamondIcon.Size = new System.Drawing.Size(24, 24);
			this.btnDiamondIcon.TabIndex = 12;
			this.btnDiamondIcon.UseVisualStyleBackColor = false;
			this.btnDiamondIcon.Visible = false;
			// 
			// btnFillIcon
			// 
			this.btnFillIcon.BackColor = System.Drawing.Color.White;
			this.btnFillIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFillIcon.BackgroundImage")));
			this.btnFillIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnFillIcon.Location = new System.Drawing.Point(307, 269);
			this.btnFillIcon.Name = "btnFillIcon";
			this.btnFillIcon.Size = new System.Drawing.Size(24, 24);
			this.btnFillIcon.TabIndex = 13;
			this.btnFillIcon.UseVisualStyleBackColor = false;
			this.btnFillIcon.Visible = false;
			// 
			// btnFXIcon
			// 
			this.btnFXIcon.BackColor = System.Drawing.Color.White;
			this.btnFXIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFXIcon.BackgroundImage")));
			this.btnFXIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnFXIcon.Location = new System.Drawing.Point(307, 299);
			this.btnFXIcon.Name = "btnFXIcon";
			this.btnFXIcon.Size = new System.Drawing.Size(24, 24);
			this.btnFXIcon.TabIndex = 14;
			this.btnFXIcon.UseVisualStyleBackColor = false;
			this.btnFXIcon.Visible = false;
			// 
			// btnEyedropperIcon
			// 
			this.btnEyedropperIcon.BackColor = System.Drawing.Color.White;
			this.btnEyedropperIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEyedropperIcon.BackgroundImage")));
			this.btnEyedropperIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnEyedropperIcon.Location = new System.Drawing.Point(306, 327);
			this.btnEyedropperIcon.Name = "btnEyedropperIcon";
			this.btnEyedropperIcon.Size = new System.Drawing.Size(24, 24);
			this.btnEyedropperIcon.TabIndex = 15;
			this.btnEyedropperIcon.UseVisualStyleBackColor = false;
			this.btnEyedropperIcon.Visible = false;
			// 
			// Workspace
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(868, 383);
			this.Controls.Add(this.btnEyedropperIcon);
			this.Controls.Add(this.btnFXIcon);
			this.Controls.Add(this.btnFillIcon);
			this.Controls.Add(this.btnDiamondIcon);
			this.Controls.Add(this.btnCircleIcon);
			this.Controls.Add(this.btnRectangleIcon);
			this.Controls.Add(this.btnLineIcon);
			this.Controls.Add(this.btnEraserIcon);
			this.Controls.Add(this.btnPencilIcon);
			this.Controls.Add(this.btnPenIcon);
			this.Controls.Add(this.barVertical);
			this.Controls.Add(this.barHorizontal);
			this.Controls.Add(this.barZoom);
			this.Controls.Add(this.displayBox);
			this.Controls.Add(this.panLayers);
			this.Controls.Add(this.panTools);
			this.Controls.Add(this.panToolProperties);
			this.Controls.Add(this.strpMenu);
			this.Controls.Add(this.toolBar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MainMenuStrip = this.strpMenu;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(125, 105);
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
			this.strpMenu.ResumeLayout(false);
			this.strpMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnEyedropperIcon;
		private System.Windows.Forms.Button btnFXIcon;
		private System.Windows.Forms.Button btnFillIcon;
		private System.Windows.Forms.Button btnDiamondIcon;
		private System.Windows.Forms.Button btnCircleIcon;
		private System.Windows.Forms.Button btnRectangleIcon;
		private System.Windows.Forms.Button btnLineIcon;
		private System.Windows.Forms.Button btnEraserIcon;
		private System.Windows.Forms.Button btnPencilIcon;
		private System.Windows.Forms.Button btnPenIcon;
		private System.Windows.Forms.ToolStripMenuItem btnSave;
		private System.Windows.Forms.SaveFileDialog diaExport;
		private System.Windows.Forms.SaveFileDialog diaSave;
		private System.Windows.Forms.OpenFileDialog diaImport;
		private System.Windows.Forms.OpenFileDialog diaOpen;
		private System.Windows.Forms.ToolStripMenuItem btnExport;
		private System.Windows.Forms.ToolStripMenuItem btnImport;
		private System.Windows.Forms.ToolStripMenuItem btnOpen;
		private System.Windows.Forms.ToolStripMenuItem btnSaveAs;
		private System.Windows.Forms.MenuStrip strpMenu;
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
