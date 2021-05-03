/*
 * Created by SharpDevelop.
 * User: 13SYoung
 * Date: 18/09/2019
 * Time: 20:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SIMP
{
	/// <summary>
	/// A loaded image
	/// </summary>
	public class Image : IPictureRectangle
	{
		//private SolidBrush[,] pixels;
		public int fileWidth, fileHeight;
		public ZoomSettings zoomSettings;
		public Workspace attachedWorkspace;
		public List<FilePoint> changedPixels;
		public Bitmap lastImage;
		public List<Layer> layers;
		public Layer currentLayer;
		
		public int displayWidth { get {
			return fileWidth * zoomSettings.zoom;
		}}
		public int displayHeight { get {
			return fileHeight * zoomSettings.zoom;
		}}
		
		public Image(int width, int height, Workspace sender)
		{
			if (width <= 0) {
				throw new ArgumentException("Width is 0 or less","Width");
			}
			if (width > SimpConstants.IMAGE_MAX_WIDTH) {
				throw new ArgumentException(String.Format("Width is greater than Image Max ({0})", SimpConstants.IMAGE_MAX_WIDTH),"Width");
			}
			
			if (height <= 0) {
				throw new ArgumentException("Height is 0 or less","Height");
			}
			if (height > SimpConstants.IMAGE_MAX_WIDTH) {
				throw new ArgumentException(String.Format("Height is greater than Image Max ({0})", SimpConstants.IMAGE_MAX_WIDTH),"Height");
			}
			
			this.fileWidth = width;
			this.fileHeight = height;
			this.attachedWorkspace = sender;
			this.zoomSettings = new ZoomSettings(new FilePoint(width/2,height/2));
			this.changedPixels = new List<FilePoint>();
			
			//layer setup
			this.layers = new List<Layer>();
			this.layers.Add(new Layer(fileWidth,fileHeight));
			this.currentLayer = layers[0];
			
//			//sets each pixel to initially white
//			for (int x = 0; x < width; x++) {
//				for (int y = 0; y < height; y++) {
//					if ((x+y)%2==0) {
//						pixels[x,y] = Color.FromArgb(255,x*6+y*6,x*6+y*6);
//					} else {
//						pixels[x,y] = Color.Black;
//					}
//					
//					pixels[x,y] = new SolidBrush(Color.White);
//				}
//			}
		}
		
		/// <summary>
		/// Gets the colour of a pixel
		/// </summary>
		/// <param name="x">X coord of pixel to get</param>
		/// <param name="y">Y coord of pixel to get</param>
		/// <returns>The colour of the selected pixel</returns>
		public Color GetPixel(FilePoint filePoint) {
			return currentLayer.pixels[filePoint.fileX,filePoint.fileY].Color;
		}
		
		/// <summary>
		/// Sets the colour of a pixel
		/// </summary>
		/// <param name="filePoint">File Point of pixel to set</param>
		/// <param name="colour">The colour to set that pixel to</param>
		public void SetPixel(FilePoint filePoint, Color colour) {
			try {
				currentLayer.pixels[filePoint.fileX,filePoint.fileY] = new SolidBrush(colour);
				changedPixels.Add(new FilePoint(filePoint));
			} catch (IndexOutOfRangeException) {
				// ignore request if it tried to set out of bounds
				// TODO: some sort of logging system to warn about this
			}
		}
		
		/// <summary>
		/// Sets the colour of a pixel
		/// </summary>
		/// <param name="x">X coord of pixel to set</param>
		/// <param name="y">Y coord of pixel to set</param>
		/// <param name="colour">The colour to set that pixel to</param>
		public void SetPixel(int x, int y, Color colour) {
			SetPixel(new FilePoint(x,y),colour);
		}
		
		public void SetPixel(DisplayPoint displayPoint, Color colour) {
			FilePoint filePoint = DisplayPointToFilePoint(displayPoint);
			SetPixel(filePoint,colour);
		}
		
		/// <summary>
		/// Gets a representation of this image
		/// </summary>
		/// <returns>A System.Drawing.Image representation</returns>
		public System.Drawing.Image GetDisplayImage(int width, int height, bool full) {
			zoomSettings.CalcDisplayCentreLocation(width,height);
			
			// finds locations of where it needs to draw to and from
			FilePoint topLeftPoint = new FilePoint(
				zoomSettings.fileCentreLocation.fileX - (int)Math.Ceiling(Math.Ceiling((decimal)width/(decimal)zoomSettings.zoom)/2),
				zoomSettings.fileCentreLocation.fileY - (int)Math.Ceiling(Math.Ceiling((decimal)height/(decimal)zoomSettings.zoom)/2)
			);
			FilePoint bottomRightPoint = new FilePoint(
				zoomSettings.fileCentreLocation.fileX + (int)Math.Ceiling(Math.Ceiling((decimal)width/(decimal)zoomSettings.zoom)/2),
				zoomSettings.fileCentreLocation.fileY + (int)Math.Ceiling(Math.Ceiling((decimal)height/(decimal)zoomSettings.zoom)/2)
			);
			
			// clamp both potential points inside the image
			ClampFilePoint(ref topLeftPoint);
			ClampFilePoint(ref bottomRightPoint);
			
			// also clamp the centre location in the image
			ClampCentreLocation(width,height);
			
			// makes sure everything is displayed
			if (width == displayWidth && fileWidth%2 == 1) {
				zoomSettings.displayCentreLocation.displayX -= zoomSettings.zoom/2;
			}
			
			if (height == displayHeight && fileHeight%2 == 1) {
				zoomSettings.displayCentreLocation.displayY -= zoomSettings.zoom/2;
			}
			
			if (full) {
				Bitmap newImage = new Bitmap(width,height);
				Graphics GFX = Graphics.FromImage(newImage);
				GFX.Clear(Color.White);
				DrawFullImage(topLeftPoint,bottomRightPoint,GFX);
				lastImage = newImage;
				return newImage;
			} else {
				Graphics GFX = Graphics.FromImage(lastImage);
				DrawChangedImage(GFX);
				return lastImage;
			}
			
		}
		
		private void DrawFullImage(FilePoint topLeftPoint, FilePoint bottomRightPoint, Graphics GFX) {
			// the file location of the top right
			DisplayPoint topLeftDisplayPoint = FilePointToDisplayPoint(topLeftPoint);
			
			// a point that is used within the loop
			DisplayPoint currentPoint = new DisplayPoint(0,0);
			
			// resets the X
			currentPoint.displayX = topLeftDisplayPoint.displayX;
			
			// loops through all the necessary pixels
			for (int x = topLeftPoint.fileX; x < bottomRightPoint.fileX; x++) {
				
				// resets the Y (before it is iterated on)
				currentPoint.displayY = topLeftDisplayPoint.displayY;
				for (int y = topLeftPoint.fileY; y < bottomRightPoint.fileY; y++) {
					
					foreach (Layer layer in layers) {
						//don't draw invisible layer
						if (!layer.visible) {
							continue;
						}
						// repeats through layers until a solid pixel is found
						if (layer.pixels[x,y].Color != Color.Transparent) {
							// Draws a rectangle using colour of current pixel, X and Y of current display location, the width and height is the zoom of the image
							GFX.FillRectangle(layer.pixels[x,y],currentPoint.displayX,currentPoint.displayY,zoomSettings.zoom,zoomSettings.zoom);
							break; // a pixel has been drawn - draw no more here
						}
					}
					
					// Moves the current Y along by the size of one pixel
					currentPoint.displayY += zoomSettings.zoom;
				}
				
				// Moves the current X along for same reason
				currentPoint.displayX += zoomSettings.zoom;
			}
		}
		
		private void DrawChangedImage(Graphics GFX) {
			DisplayPoint displayChangedLoc;
			bool setPixel;
			foreach (FilePoint changedPixel in changedPixels) {
				// finds this pixels location
				displayChangedLoc = FilePointToDisplayPoint(changedPixel);
				setPixel = false;
				foreach (Layer layer in layers) {
					//don't draw invisible layer
					if (!layer.visible) {
						continue;
					}
					
					// repeats through layers until a solid pixel is found
					if (layer.pixels[changedPixel.fileX,changedPixel.fileY].Color != Color.Transparent) {
						GFX.FillRectangle(layer.pixels[changedPixel.fileX,changedPixel.fileY],
						                  displayChangedLoc.displayX,displayChangedLoc.displayY,
						                  zoomSettings.zoom,zoomSettings.zoom);
						setPixel = true;
						break;
					}
				}
				if (!setPixel) {
					GFX.FillRectangle(new SolidBrush(Color.White),
						              displayChangedLoc.displayX,displayChangedLoc.displayY,
						              zoomSettings.zoom,zoomSettings.zoom);
				}
			}
			changedPixels.Clear();
		}
		
		public void SetBarValues(ScrollBar barHorizontal, ScrollBar barVertical) {
			// determines how many missing centre locations there are
			int missingCrossexXAxis = GetMissingCrossesInAxis(attachedWorkspace.displayBox.Width);
			int missingCrossexYAxis = GetMissingCrossesInAxis(attachedWorkspace.displayBox.Height);
			
			// updates horizontal bar
			barHorizontal.LargeChange = missingCrossexXAxis;
			barHorizontal.Maximum = fileWidth-1;
			barHorizontal.Value = CentreToBar(EAxis.X);
			
			// updates vertical bar
			barVertical.LargeChange = missingCrossexYAxis;
			barVertical.Maximum = fileHeight-1;
			barVertical.Value = CentreToBar(EAxis.Y);
		}
		
		public void CentreFromBar(int newValue, EAxis axis) {
			int firstCrossPosition;
			switch (axis) {
				case EAxis.X:
					firstCrossPosition = (int)Math.Floor(Math.Floor((decimal)attachedWorkspace.displayBox.Width/(decimal)zoomSettings.zoom)/2);
					zoomSettings.fileCentreLocation = new FilePoint(firstCrossPosition + newValue, zoomSettings.fileCentreLocation.fileY);
					break;
				case EAxis.Y:
					firstCrossPosition = (int)Math.Floor(Math.Floor((decimal)attachedWorkspace.displayBox.Height/(decimal)zoomSettings.zoom)/2);
					zoomSettings.fileCentreLocation = new FilePoint(zoomSettings.fileCentreLocation.fileX, firstCrossPosition + newValue);
					break;
			}
		}
		
		public int CentreToBar(EAxis axis) {
			int firstCrossPosition;
			switch (axis) {
				case EAxis.X:
					firstCrossPosition = GetFirstCrossPosition(attachedWorkspace.displayBox.Width);
					return zoomSettings.fileCentreLocation.fileX - firstCrossPosition;
				case EAxis.Y:
					firstCrossPosition = GetFirstCrossPosition(attachedWorkspace.displayBox.Height);
					return zoomSettings.fileCentreLocation.fileY - firstCrossPosition;
			}
			return 0;
		}
		
		private int GetFirstCrossPosition(int axisSize) {
			return (int)Math.Floor(Math.Floor((decimal)axisSize/(decimal)zoomSettings.zoom)/2);
		}
		
		private int GetMissingCrossesInAxis(int axisSize) {
			return (int)Math.Floor(Math.Floor((decimal)axisSize/(decimal)zoomSettings.zoom)/2)*2;
		}
		
		/// <summary>
		/// Returns a DisplayRectangle representation of the image
		/// </summary>
		public DisplayRectangle ToDisplayRectangle() {
			return new DisplayRectangle(0,0,displayWidth,displayHeight);
		}
		
		/// <summary>
		/// Returns a FileRectangle representation of the image
		/// </summary>
		public FileRectangle ToFileRectangle() {
			return new FileRectangle(0,0,fileWidth,fileHeight);
		}
		
		/// <summary>
		/// Converts a FilePoint to a DisplayPoint
		/// </summary>
		/// <param name="filePoint">FilePoint to convert</param>
		/// <returns>The FilePoint converted into a DisplayPoint</returns>
		public DisplayPoint FilePointToDisplayPoint(FilePoint filePoint) {
			// checks whether the point is in bounds
			if (
				filePoint.fileX < 0 || filePoint.fileX >= fileWidth
				|| filePoint.fileY < 0 || filePoint.fileY >= fileHeight
			) {
				throw new IndexOutOfRangeException();
			}
			
			// finds displacement
			int displacementX = filePoint.fileX - zoomSettings.fileCentreLocation.fileX;
			int displacementY = filePoint.fileY - zoomSettings.fileCentreLocation.fileY;
			
			// factors zoom
			displacementX *= zoomSettings.zoom;
			displacementY *= zoomSettings.zoom;
			
			if (zoomSettings.displayCentreLocation.displayX == 5) {
				zoomSettings.displayCentreLocation.displayX = 4;
			}
			
			// returns the new point
			return new DisplayPoint(
				// this SHOULD be 4, not 5
				// perhaps the code to cacluate where the centre location is on odd number size images isn't quite correct.. hmmm
				zoomSettings.displayCentreLocation.displayX + displacementX,
				zoomSettings.displayCentreLocation.displayY + displacementY
			);
		}
		
		/// <summary>
		/// Converts a DisplayPoint to a FilePoint
		/// </summary>
		/// <param name="displayPoint">DisplayPoint to convert</param>
		/// <returns>The DisplayPoint converted into a FilePoint</returns>
		public FilePoint DisplayPointToFilePoint(DisplayPoint displayPoint) {
			float displacementX = displayPoint.displayX - zoomSettings.displayCentreLocation.displayX;
			float displacementY = displayPoint.displayY - zoomSettings.displayCentreLocation.displayY;
			
			displacementX /= zoomSettings.zoom;
			displacementY /= zoomSettings.zoom;
			
			return new FilePoint(
				(int)(displacementX + (float)zoomSettings.fileCentreLocation.fileX),
				(int)(displacementY + (float)zoomSettings.fileCentreLocation.fileY)
			);
		}
		
		private void ClampFilePoint(ref FilePoint filePoint) {
			if (filePoint.fileX < 0) {
				filePoint.fileX = 0;
			}
			if (filePoint.fileX > fileWidth) {
				filePoint.fileX = fileWidth;
			}
			
			if (filePoint.fileY < 0) {
				filePoint.fileY = 0;
			}
			if (filePoint.fileY > fileHeight) {
				filePoint.fileY = fileHeight;
			}
		}
		
		private void ClampCentreLocation(int width, int height) {
			int firstCrossInXAxis = GetFirstCrossPosition(width);
			int firstCrossInYAxis = GetFirstCrossPosition(height);
			
			// whether x is too small
			if (zoomSettings.fileCentreLocation.fileX < firstCrossInXAxis) {
				zoomSettings.fileCentreLocation.fileX = firstCrossInXAxis;
			}
			
			// whether y is too small
			if (zoomSettings.fileCentreLocation.fileY < firstCrossInYAxis) {
				zoomSettings.fileCentreLocation.fileY = firstCrossInYAxis;
			}
			
			// whether x is too big
			if (zoomSettings.fileCentreLocation.fileX > (fileWidth - firstCrossInXAxis)) {
				zoomSettings.fileCentreLocation.fileX = (fileWidth - firstCrossInXAxis);
			}
			
			// whether y is too big
			if (zoomSettings.fileCentreLocation.fileY > (fileHeight - firstCrossInYAxis)) {
				zoomSettings.fileCentreLocation.fileY = (fileHeight - firstCrossInYAxis);
			}
			
			// makes sure on odd sized images the centre is correct when zoomed out completely
			if (displayWidth == width) {
				zoomSettings.displayCentreLocation.displayX = width/2;
			}
			
			if (displayHeight == height) {
				zoomSettings.displayCentreLocation.displayX = width/2;
			}
		}
	}
}
