/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 18/09/2019
 * Time: 15:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SIMP.Tools;
using SIMP.Properties;
using SIMP.Actions;
using SIMP.Tools.ShapeTools;

namespace SIMP
{
	/// <summary>
	/// Description of WorkSpace.
	/// </summary>
	public partial class Workspace : Form
	{
		#region vars
		public SIMP.Image image;
		public int width, height;
		public Form attachedForm;
		public PictureBox displayBox;
		public bool shiftPressed = false, controlPressed = false;
		public List<ITool> tools;
		public ITool currentTool;
		
		private int _savedFormWidth, _savedFormHeight;
		private int _updateCount = 0;
		private int _leftPadding, _rightPadding, _topPadding, _bottomPadding;
		private Stack<IAction> pastActions;
		private Stack<IAction> futureActions;
		
		public int leftPadding {
			get {
				return _leftPadding;
			}
			set {
				_leftPadding = value;
				SetMinimumSize();
			}
		}
		public int rightPadding {
			get {
				return _rightPadding;
			}
			set {
				_rightPadding = value;
				SetMinimumSize();
			}
		}
		public int topPadding {
			get {
				return _topPadding;
			}
			set {
				_topPadding = value;
				SetMinimumSize();
			}
		}
		public int bottomPadding {
			get {
				return _bottomPadding;
			}
			set {
				_bottomPadding = value;
				SetMinimumSize();
			}
		}
		#endregion
		
		#region constructor
		public Workspace()
		{
			InitializeComponent();
			
			Constructor(
				SimpConstants.IMAGE_DEFAULT_WIDTH,
				SimpConstants.IMAGE_DEFAULT_HEIGHT
			);
		}
		
		public Workspace(int width, int height) {
			InitializeComponent();
			
			Constructor(width,height);
		}
		
		private void Constructor(int width, int height) {
			image = new SIMP.Image(width,height,this);
			
			// Stores itself casted as a form
			attachedForm = (Form)this;
			
			// Defines levels of padding
			leftPadding = SimpConstants.WORKSPACE_LEFT_PADDING;
			rightPadding = SimpConstants.WORKSPACE_RIGHT_PADDING;
			topPadding = SimpConstants.WORKSPACE_TOP_PADDING;
			bottomPadding = SimpConstants.WORKSPACE_BOTTOM_PADDING;
			
			// Needs to gen controls on layer selector
			GenLayersSelector();
			
			// Sets the dimensions of the workspace to the dimensions of the form
			CalculateDimensions();
			
			// Updates the form
			UpdateDisplayBox(true,true);
			
			// Adds scroll event
			this.MouseWheel += new MouseEventHandler(WorkspaceMouseWheel);
			
			AddTools();
			
			// Adds buttons
			int buttonY = 0;
			foreach (ITool tool in tools) {
				Button newButton = new Button();
				newButton.Size = new Size(24,24);
				newButton.Location = new Point(0,buttonY);
				newButton.Name = tool.name;
				newButton.Click += new EventHandler(ToolButtonClick);
				buttonY+=24;
				
				panTools.Controls.Add(newButton);
			}
			
			currentTool = tools[0];
			ShowTool();
			
			pastActions = new Stack<IAction>();
			futureActions = new Stack<IAction>();
		}
		
		private void AddTools() {
			// Defines tools
			tools = new List<ITool>();
			
			tools.Add(new SIMP.Tools.LineTool("Brush","Simple Brush",this));
			tools.Add(new SinglePixelLineTool("Pencil","Precise Brush",this));
			tools.Add(new EraserTool("Eraser","Rub Stuff Out",this));
			tools.Add(new SIMP.Tools.ShapeTools.LineTool("Line Tool","Draw a staight line",this));
			tools.Add(new RectangleTool("Rectangle","Draws a rectangle",this));
			tools.Add(new CircleTool("Circle","Draws a circle (or rectangle)",this));
			tools.Add(new DiamondTool("Diamond","Draws diamonds",this));
			tools.Add(new FillTool("Fill","Fills a shape",this));
		}
		#endregion
		
		#region display
		
		/// <summary>
		/// Resizes, Relocates and (if redraw) updates image in the displayBox
		/// </summary>
		/// <param name="redraw"></param>
		public void UpdateDisplayBox(bool redraw, bool full) {
			// Sets up the dimensions of displayBox
			ResizeDisplayBox();
			
			// Relocates the picture box
			RelocateDisplayBox();
			
			if (redraw) {
				// Displays to the picture box
				displayBox.Image = image.GetDisplayImage(displayBox.Width,displayBox.Height,full);
				
				//GC.Collect();
				//displayBox.Image = image.GetDisplayImage(10,10);
			}
			
			// Updates the progress bars
			UpdateBar(EAxis.X,barHorizontal);
			UpdateBar(EAxis.Y,barVertical);
			
			_updateCount++;
			
			if (_updateCount >= SimpConstants.WORKSPACE_REFRESH_PERIOD) {
				_updateCount = 0;
				GC.Collect();
			}
		}
		
		/// <summary>
		/// Updates the width and height of the displayBox
		/// </summary>
		private void ResizeDisplayBox() {
			switch (CheckImageSize(EAxis.X)) {
				// if the image is larger than form size
				case EAxisMode.ImageTooLarge:
					displayBox.Width = DisplayRectangle.Width - (leftPadding + rightPadding);
					break;
				// if the image is smaller than form size
				case EAxisMode.ImageTooSmall:
					displayBox.Width = image.displayWidth;
					break;
			}
			
			switch (CheckImageSize(EAxis.Y)) {
				// if the image is larger than form size
				case EAxisMode.ImageTooLarge:
					displayBox.Height = DisplayRectangle.Height - (topPadding + bottomPadding);
					break;
				// if the image is smaller than form size
				case EAxisMode.ImageTooSmall:
					displayBox.Height = image.displayHeight;
					break;
			}
		}
		
		/// <summary>
		/// Updates the position of the displayBox
		/// </summary>
		private void RelocateDisplayBox() {
			int X = 0;
			int Y = 0;
			switch (CheckImageSize(EAxis.X)) {
				// if the image is larger than form size
				case EAxisMode.ImageTooLarge:
					X = leftPadding;
					break;
				// if the image is smaller than form size
				case EAxisMode.ImageTooSmall:
					X = ((width - image.displayWidth) / 2) + leftPadding;
					break;
			}
			
			switch (CheckImageSize(EAxis.Y)) {
				// if the image is larger than form size
				case EAxisMode.ImageTooLarge:
					Y = topPadding;
					break;
				// if the image is smaller than form size
				case EAxisMode.ImageTooSmall:
					Y = ((height - image.displayHeight) / 2) + topPadding;
					break;
			}
			displayBox.Location = new Point(X,Y);
		}
		
		/// <summary>
		/// Called when the heartbeat timer ticks
		/// </summary>
		private void HeartbeatTick(object sender, EventArgs e)
		{
			if (HasSizeChanged()) {
				CalculateDimensions();
				UpdateDisplayBox(true,true);
			}
		}
		
		/// <summary>
		/// Calculates what the width and height of the Workspace should be
		/// </summary>
		private void CalculateDimensions() {
			width = DisplayRectangle.Width - (leftPadding + rightPadding);
			height = DisplayRectangle.Height - (topPadding + bottomPadding);
		}
		
		private void WorkspaceResizeEnd(object sender, EventArgs e)
		{
			//UpdateDisplayBox(true);
		}
		
		/// <summary>
		/// If the form size is different to the last recorded ones
		/// </summary>
		/// <returns></returns>
		private bool HasSizeChanged() {
			// if width has changed
			if (_savedFormWidth != DisplayRectangle.Width) {
				_savedFormWidth = DisplayRectangle.Width;
				return true;
			}
			
			// if height has changed
			if (_savedFormHeight != DisplayRectangle.Height) {
				_savedFormHeight = DisplayRectangle.Height;
				return true;
			}
			
			return false;
		}
		
		/// <summary>
		/// Checks whether the image is smaller or larger than the form in this Axis
		/// </summary>
		/// <param name="axis">Axis to check in</param>
		/// <returns></returns>
		private EAxisMode CheckImageSize(EAxis axis) {
			int axisSize;
			int padding;
			switch (axis) {
				case EAxis.X:
					// determines the max size of the relevent axis and the amount of padding to deduct
					axisSize = DisplayRectangle.Width;
					padding = leftPadding + rightPadding;
					break;
				case EAxis.Y:
					axisSize = DisplayRectangle.Height;
					padding = topPadding + bottomPadding;
					break;
				default:
					throw new Exception("Invalid value for EAxis");
			}
			
			// gets the display size of the relevent axis (taking zoom into account)
			int imageAxisSize = image.ToDisplayRectangle().GetDisplaySize(axis);
			
			// if the size of form is bigger than the image's size plus padding
			if (axisSize >= (imageAxisSize + padding)) {
				// then the image is smaller than form
				return EAxisMode.ImageTooSmall;
			} else {
				return EAxisMode.ImageTooLarge;
			}
		}
		
		private void SetMinimumSize() {
			this.MinimumSize = new Size(_leftPadding + _rightPadding + SimpConstants.WINDOWS_RIGHT_BAR_WIDTH + SimpConstants.WINDOWS_LEFT_BAR_WIDTH + 100,
			                            _topPadding + _bottomPadding + SimpConstants.WINDOWS_TOP_BAR_HEIGHT + SimpConstants.WINDOWS_BOTTOM_BAR_HEIGHT + 100);
		}
		
		#endregion
		
		#region bars
		
		/// <summary>
		/// When the Value of the Zoom bar changes
		/// </summary>
		void BarZoomScroll(object sender, EventArgs e)
		{
			image.zoomSettings.zoom = barZoom.Value;
			
			// a lot will have changed so just redisplay everything
			UpdateDisplayBox(true,true);
		}
		
		private void UpdateBar(EAxis axis, ScrollBar bar) {
			SetBarVisiblity(axis,bar);
			
			image.SetBarValues(barHorizontal,barVertical);
			
		}
		
		private void SetBarVisiblity(EAxis axis, ScrollBar bar) {
			switch (CheckImageSize(axis)) {
				case EAxisMode.ImageTooLarge:
					bar.Enabled = true;
					break;
				case EAxisMode.ImageTooSmall:
					bar.Enabled = false;
					break;
			}
		}
		
		void BarHorizontalValueChanged(object sender, EventArgs e)
		{
			image.CentreFromBar(barHorizontal.Value,EAxis.X);
			UpdateDisplayBox(true,true);
		}
		
		void BarVerticalValueChanged(object sender, EventArgs e)
		{
			image.CentreFromBar(barVertical.Value,EAxis.Y);
			UpdateDisplayBox(true,true);
		}
		
		#endregion
		
		#region mouse
		
		void DisplayBoxMouseDown(object sender, MouseEventArgs e)
		{
			DisplayPoint clickLocation = new DisplayPoint(e.Location.X,e.Location.Y);
			currentTool.HandleMouseDown(image.DisplayPointToFilePoint(clickLocation),e.Button);
		}
		
		void DisplayBoxMouseUp(object sender, MouseEventArgs e)
		{
			DisplayPoint clickLocation = new DisplayPoint(e.Location.X,e.Location.Y);
			currentTool.HandleMouseUp(image.DisplayPointToFilePoint(clickLocation),e.Button);
		}
		
		DisplayPoint oldLocation = new DisplayPoint(0,0);
		void DisplayBoxMouseMove(object sender, MouseEventArgs e)
		{
			DisplayPoint newLocation = new DisplayPoint(e.Location.X,e.Location.Y);
			currentTool.HandleMouseMove(image.DisplayPointToFilePoint(oldLocation),image.DisplayPointToFilePoint(newLocation));
			
			oldLocation = newLocation;
		}
		
		void DisplayBoxClick(object sender, EventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			DisplayPoint clickLocation = new DisplayPoint(me.Location.X,me.Location.Y);
			currentTool.HandleMouseClick(image.DisplayPointToFilePoint(clickLocation),me.Button);
		}

		void WorkspaceMouseWheel(object sender, MouseEventArgs e)
		{
			// zoom scrolling
			if (controlPressed) {
				// if scrolled up
				if (e.Delta > 0) {
					if (barZoom.Value < barZoom.Maximum) {
						barZoom.Value++;
					}
				} else {
					if (barZoom.Value > barZoom.Minimum) {
						barZoom.Value--;
					}
				}
				BarZoomScroll(barZoom, new EventArgs());
			}
			
			// horizontal bar scrolling
			else if (shiftPressed) {
				// if scrolled DOWN
				if (e.Delta < 0) {
					if (barHorizontal.Value < barHorizontal.Maximum) {
						barHorizontal.Value++;
					}
				} else {
					if (barHorizontal.Value > barHorizontal.Minimum) {
						barHorizontal.Value--;
					}
				}
			}
			
			// vertical bar scrolling
			else {
				// if scrolled DOWN
				if (e.Delta < 0) {
					if (barVertical.Value < barVertical.Maximum) {
						barVertical.Value++;
					}
				} else {
					if (barVertical.Value > barVertical.Minimum) {
						barVertical.Value--;
					}
				}
			}
		}
		
		void WorkspaceKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Shift) {
				shiftPressed = true;
			}
			if (e.Control) {
				controlPressed = true;
			}
		}
		
		void WorkspaceKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.ShiftKey) {
				shiftPressed = false;
			}
			if (e.KeyCode == Keys.ControlKey) {
				controlPressed = false;
			}
		}
		
		#endregion
		
		#region tools
		
		void ToolButtonClick(object sender, EventArgs e) {
			Button buttonSender = (Button)sender;
			
			// disables every button except for pressed one
			foreach (Button button in panTools.Controls) {
				button.Enabled = true;
			}
			buttonSender.Enabled = false;
			
			// selects the tool
			foreach (ITool tool in tools) {
				if (tool.name.Equals(buttonSender.Name)) {
					currentTool = tool;
				}
			}
			
			if (currentTool != ITool.BlankTool) {
				ShowTool();
			} else {
				HideTool();
			}
			
		}
		
		bool toolsOpen = false;
		public void ShowTool() {
			leftPadding = SimpConstants.WORKSPACE_LEFT_PADDING + 200;
			panToolProperties.Visible = true;
			panToolProperties.Controls.Clear();
			
			Label lblToolName = new Label();
			lblToolName.Location = new Point(0, 0);
			lblToolName.Size = new Size(191, 23);
			lblToolName.Text = currentTool.name;
			lblToolName.Font = new Font(lblToolName.Font,FontStyle.Bold);
			panToolProperties.Controls.Add(lblToolName);
			
			int currentY = lblToolName.Height;
			int width = panToolProperties.Width;
			foreach (IProperty property in currentTool.properties) {
				// doesn't show invisbles
				if (property.propertyType == PropertyType.Hidden) {
					continue;
				}
				
				Label newLabel = new Label();
				newLabel.Size = new Size(width,SimpConstants.PROPERTY_LABEL_HEIGHT);
				newLabel.Location = new Point(0,currentY);
				newLabel.Text = property.name;
				panToolProperties.Controls.Add(newLabel);
				currentY += SimpConstants.PROPERTY_LABEL_HEIGHT;
				
				currentY += SimpConstants.PROPERTY_GAP_HEIGHT;
				
				if (property is ColorProperty) {
					ColorProperty colorProperty = (ColorProperty)property;
					PictureBox newPicture = new PictureBox();
					newPicture.Size = new Size(width,SimpConstants.PROPERTY_FIELD_HEIGHT);
					newPicture.Location = new Point(0,currentY);
					newPicture.BackColor = (Color)property.value;
					newPicture.Click += colorProperty.onInteract;
					newPicture.Cursor = Cursors.Hand;
					panToolProperties.Controls.Add(newPicture);
				} else if (property is NumericalProperty) {
					NumericUpDown newNum = new NumericUpDown();
					NumericalProperty numericalProperty = (NumericalProperty)property;
					newNum.Size = new Size(width,SimpConstants.PROPERTY_FIELD_HEIGHT);
					newNum.Location = new Point(0,currentY);
					newNum.Value = numericalProperty.min;
					newNum.Minimum = numericalProperty.min;
					newNum.Maximum = numericalProperty.max;
					newNum.Value = (int)numericalProperty.value;
					newNum.ValueChanged += numericalProperty.onInteract;
					panToolProperties.Controls.Add(newNum);
				} else if (property is DecimalProperty) {
					NumericUpDown newNum = new NumericUpDown();
					DecimalProperty DecimalProperty = (DecimalProperty)property;
					newNum.Size = new Size(width,SimpConstants.PROPERTY_FIELD_HEIGHT);
					newNum.Location = new Point(0,currentY);
					newNum.Value = DecimalProperty.min;
					newNum.Minimum = DecimalProperty.min;
					newNum.Maximum = DecimalProperty.max;
					newNum.Value = (decimal)DecimalProperty.value;
					newNum.ValueChanged += DecimalProperty.onInteract;
					panToolProperties.Controls.Add(newNum);
				}
				currentY += SimpConstants.PROPERTY_FIELD_HEIGHT;
				
				currentY += SimpConstants.PROPERTY_SPACER_HEIGHT;
			}
			
			CalculateDimensions();
			
			if (!toolsOpen) {
				toolsOpen = true;
				UpdateDisplayBox(true,true);
			}
		}
		
		private void HideTool() {
			leftPadding = SimpConstants.WORKSPACE_LEFT_PADDING;
			panToolProperties.Visible = false;
			CalculateDimensions();
			UpdateDisplayBox(true,true);
			toolsOpen = false;
		}
		
		#endregion
		
		#region action
		public void PerformAction(IAction action) {
			PerformActionSilent(action);
			RecordAction(action);
		}
		
		public void PerformActionSilent(IAction action) {
			action.Do(this);
		}
		
		public void RecordAction(IAction action) {
			pastActions.Push(action);
			futureActions.Clear();
			btnRedo.Enabled = false;
			btnUndo.Enabled = true;
		}
		
		void BtnUndoClick(object sender, EventArgs e)
		{
			IAction lastAction = pastActions.Pop();
			
			lastAction.Undo(this);
			
			futureActions.Push(lastAction);
			btnRedo.Enabled = true;
			
			if (pastActions.Count == 0) {
				btnUndo.Enabled = false;
			}
			
			GenLayersSelector();
		}
		
		void BtnRedoClick(object sender, EventArgs e)
		{
			IAction futureAction = futureActions.Pop();
			
			futureAction.Do(this);
			
			pastActions.Push(futureAction);
			btnUndo.Enabled = true;
			
			if (futureActions.Count == 0) {
				btnRedo.Enabled = false;
			}
			
			GenLayersSelector();
		}
		#endregion
		
		#region off bounds image
		void PanToolPropertiesClick(object sender, EventArgs e)
		{
			MessageBox.Show(this.MinimumSize.ToString());
		}
		
		void WorkspaceMouseDown(object sender, MouseEventArgs e)
		{
			currentTool.HandleMouseDown(null,e.Button);
		}
		
		void WorkspaceMouseUp(object sender, MouseEventArgs e)
		{
			currentTool.HandleMouseUp(null,e.Button);
		}
		
		void WorkspaceMouseMove(object sender, MouseEventArgs e)
		{
			Rectangle displayRectangle = new Rectangle(displayBox.Location,displayBox.Size);
			
			if (displayRectangle.Contains(e.Location)) {
				Point clickLocation = e.Location;
				clickLocation.Offset(displayBox.Location.X * -1,
				                     displayBox.Location.Y * -1);
				oldLocation = new DisplayPoint(clickLocation.X,clickLocation.Y);
				DisplayBoxMouseMove(displayBox,new MouseEventArgs(e.Button,
				                                                  e.Clicks,
				                                                  clickLocation.X,
				                                                  clickLocation.Y,
				                                                  e.Delta));
			}
		}
		#endregion
		
		#region layer display
		private void GenLayersSelector() {
			int y=5;
			panLayerSelector.Controls.Clear();
			panLayerSelector.Controls.Add(panLayerButtons);
			previewImages = new Dictionary<Layer, PictureBox>();
			
			foreach (Layer layer in image.layers) {
				Panel layerPanel = new Panel();
				layerPanel.Location = new Point(5,y);
				layerPanel.Size = new Size(panLayers.Width-10,50);
				// makes currently selected layer dark
				if (layer == image.currentLayer) {
					layerPanel.BackColor = SystemColors.ControlDark;
				} else {
					layerPanel.BackColor = SystemColors.Control;
				}
				layerPanel.Tag = layer;
				layerPanel.Click += new EventHandler(PanLayerClick);
				
				// add controls to the new layer
				// picture box displaying preview
				PictureBox layerPreview = new PictureBox();
				layerPreview.Location = new Point(5,5);
				layerPreview.Size = new Size(40,40);
				layerPreview.BackColor = Color.White;
				layerPanel.Controls.Add(layerPreview);
				previewImages[layer] = layerPreview;
				
				// check box showing visible
				CheckBox visibleBox = new CheckBox();
				visibleBox.Location = new Point(50,5);
				visibleBox.Size = new Size(100,20);
				visibleBox.Text = "Visible?";
				visibleBox.Checked = layer.visible;
				visibleBox.Tag = layer;
				visibleBox.CheckedChanged += new EventHandler(ChkLayerChecked);
				layerPanel.Controls.Add(visibleBox);
				
				panLayerSelector.Controls.Add(layerPanel);
				y+=55;
			}
			
			UpdateLayersSelector(true);
			UpdateLayerButtons();
		}
		
		Dictionary<Layer,PictureBox> previewImages;
		public void UpdateLayersSelector(bool full) {
			if (full) {
				foreach (Layer layer in image.layers) {
					UpdateLayer(layer);
				}
			} else {
				UpdateLayer(image.currentLayer);
			}
		}
		
		private void UpdateLayerButtons() {
			btnRemoveLayer.Enabled = image.layers.Count > 1;
			
			btnLayerUp.Enabled = image.layers.IndexOf(image.currentLayer) != 0;
			
			btnLayerDown.Enabled = image.layers.IndexOf(image.currentLayer) != (image.layers.Count - 1);
		}
		
		private void UpdateLayer(Layer layer) {
			System.Drawing.Image newImage = new System.Drawing.Bitmap(40,40);
			Graphics GFX = Graphics.FromImage(newImage);
			for (int x = 0; x < 40; x++) {
				for (int y = 0; y < 40; y++) {
					int imageX = (x * image.fileWidth) / 40;
					int imageY = (y * image.fileHeight) / 40;
					GFX.FillRectangle(layer.pixels[imageX,imageY],x,y,1,1);
				}
			}
			previewImages[layer].Image = newImage;	
		}
		
		void PanLayerClick(object sender, EventArgs e)
		{
			image.currentLayer = (Layer)(((Panel)sender).Tag);
			GenLayersSelector();
		}
		
		void ChkLayerChecked(object sender, EventArgs e) {
			((Layer)(((CheckBox)sender).Tag)).visible = ((CheckBox)sender).Checked;
			UpdateDisplayBox(true,true);
		}
		
		void BtnNewLayerClick(object sender, EventArgs e)
		{
			Layer newLayer = new Layer(image.fileWidth,image.fileHeight);
			image.layers.Insert(image.layers.IndexOf(image.currentLayer),newLayer);
			image.currentLayer = newLayer;
			
			GenLayersSelector();
		}
		#endregion
		
		void BtnRemoveLayerClick(object sender, EventArgs e)
		{
			image.layers.Remove(image.currentLayer);
			image.currentLayer = image.layers[0];
			
			GenLayersSelector();
			UpdateDisplayBox(true,true);
		}
		
		void BtnLayerUpClick(object sender, EventArgs e)
		{
			int layerPos = image.layers.IndexOf(image.currentLayer);
			image.layers.Remove(image.currentLayer);
			image.layers.Insert(layerPos-1,image.currentLayer);
			
			GenLayersSelector();
			UpdateDisplayBox(true,true);
		}
		
		void BtnLayerDownClick(object sender, EventArgs e)
		{
			int layerPos = image.layers.IndexOf(image.currentLayer);
			image.layers.Remove(image.currentLayer);
			image.layers.Insert(layerPos+1,image.currentLayer);
			
			GenLayersSelector();
			UpdateDisplayBox(true,true);
		}
	}
}
