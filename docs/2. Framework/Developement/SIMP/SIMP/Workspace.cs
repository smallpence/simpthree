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

namespace SIMP
{
	/// <summary>
	/// Description of WorkSpace.
	/// </summary>
	public partial class Workspace : Form
	{
		public SIMP.Image image;
		public int width, height;
		public Form attachedForm;
		public PictureBox displayBox;
		public int leftPadding, rightPadding, topPadding, bottomPadding;
		public bool shiftPressed = false, controlPressed = false;
		private int savedFormWidth, savedFormHeight;
		private int updateCount = 0;
		
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
			
			// Sets the dimensions of the workspace to the dimensions of the form
			CalculateDimensions();
			
			// Updates the form
			UpdateDisplayBox(true);
			
			// Adds scroll event
			this.MouseWheel += new MouseEventHandler(WorkspaceMouseWheel);
		}
		
		/// <summary>
		/// Resizes, Relocates and (if redraw) updates image in the displayBox
		/// </summary>
		/// <param name="redraw"></param>
		public void UpdateDisplayBox(bool redraw) {
			// Sets up the dimensions of displayBox
			ResizeDisplayBox();
			
			// Relocates the picture box
			RelocateDisplayBox();
			
			if (redraw) {
				// Displays to the picture box
				displayBox.Image = image.GetDisplayImage(displayBox.Width,displayBox.Height);
				
				//GC.Collect();
				//displayBox.Image = image.GetDisplayImage(10,10);
			}
			
			// Updates the progress bars
			UpdateBar(EAxis.X,barHorizontal);
			UpdateBar(EAxis.Y,barVertical);
			
			updateCount++;
			
			if (updateCount >= SimpConstants.WORKSPACE_REFRESH_PERIOD) {
				updateCount = 0;
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
				UpdateDisplayBox(true);
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
			UpdateDisplayBox(true);
		}
		
		/// <summary>
		/// If the form size is different to the last recorded ones
		/// </summary>
		/// <returns></returns>
		private bool HasSizeChanged() {
			// if width has changed
			if (savedFormWidth != DisplayRectangle.Width) {
				savedFormWidth = DisplayRectangle.Width;
				return true;
			}
			
			// if height has changed
			if (savedFormHeight != DisplayRectangle.Height) {
				savedFormHeight = DisplayRectangle.Height;
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
		
		/// <summary>
		/// When the Value of the Zoom bar changes
		/// </summary>
		void BarZoomScroll(object sender, EventArgs e)
		{
			image.zoomSettings.zoom = barZoom.Value;
			
			// a lot will have changed so just redisplay everything
			UpdateDisplayBox(true);
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
			UpdateDisplayBox(true);
		}
		
		void BarVerticalValueChanged(object sender, EventArgs e)
		{
			image.CentreFromBar(barVertical.Value,EAxis.Y);
			UpdateDisplayBox(true);
		}
		
		void DisplayBoxMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left) {
				DisplayPoint clickLocation = new DisplayPoint(e.Location.X,e.Location.Y);
				image.SetPixel(clickLocation,Color.Black);
				UpdateDisplayBox(true);
			} else if (e.Button == MouseButtons.Right) {
				DisplayPoint clickLocation = new DisplayPoint(e.Location.X,e.Location.Y);
				image.SetPixel(clickLocation,Color.White);
				UpdateDisplayBox(true);
			}
		}
		
		void DisplayBoxMouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left) {
				DisplayPoint clickLocation = new DisplayPoint(e.Location.X,e.Location.Y);
				image.SetPixel(clickLocation,Color.Black);
				UpdateDisplayBox(true);
			} else if (e.Button == MouseButtons.Right) {
				DisplayPoint clickLocation = new DisplayPoint(e.Location.X,e.Location.Y);
				image.SetPixel(clickLocation,Color.White);
				UpdateDisplayBox(true);
			}
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
	}
}
