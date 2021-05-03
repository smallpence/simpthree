/*
 * Created by SharpDevelop.
 * User: 13SYoung
 * Date: 05/11/2019
 * Time: 17:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SIMP.Properties;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using SIMP.Actions;

namespace SIMP.Tools
{
	/// <summary>
	/// The default brush
	/// Not to be confused with the LineTool for drawing a straight line between two points
	/// </summary>
	public class LineTool : ITool
	{
		private bool _mouseDown;
		private List<FilePoint> currentBrush;
		private Dictionary<FilePoint, Color> setPixels;
		private List<string> setHashes;
		private Dictionary<FilePoint, Color> strokePixels;
		private List<string> strokeHashes;
		
		public LineTool(string name, string description, Workspace myWorkspace, System.Drawing.Image icon)
		{
			this.name = name;
			this.description = description;
			this.myWorkspace = myWorkspace;
			this.currentBrush = new List<FilePoint>();
			
			this.properties = new System.Collections.Generic.List<IProperty>();
			this.properties.Add(new ColorProperty("Color",Color.Black,PropertyType.Normal,myWorkspace));
			this.properties.Add(new NumericalProperty("Brush Size",1,1,20,PropertyType.Normal,myWorkspace));
			
			this.setPixels = new Dictionary<FilePoint, Color>();
			this.setHashes = new List<string>();
			this.strokePixels = new Dictionary<FilePoint, Color>();
			this.strokeHashes = new List<string>();
			this.icon = icon;
		}
		
		public override void HandleMouseDown(FilePoint clickLocation, MouseButtons button) {
			// clickLocation may be null - off image
			if (clickLocation != null) {
				GenerateBrush();
				StampBrush(clickLocation.fileX,clickLocation.fileY);
				myWorkspace.UpdateDisplayBox(true,false);
			}
			_mouseDown = true;
		}
		
		public override void HandleMouseUp(FilePoint clickLocation, MouseButtons button) {
			_mouseDown = false;
			
			Color myColor = (Color)GetProperty("Color").value;
			PixelAction newAction = new PixelAction();
			
			foreach (KeyValuePair<FilePoint,Color> pixel in strokePixels) {
				newAction.AddPixel(pixel.Key,pixel.Value,myColor);
			}
			strokePixels.Clear();
			strokeHashes.Clear();
			
			newAction.layerPerformedOn = myWorkspace.image.currentLayer;
			// records a seperate action that is the whole stroke
			// this is so when undoing the entire stroke is undone
			myWorkspace.RecordAction(newAction);
			myWorkspace.UpdateLayersSelector(false);
		}
		
		public override void HandleMouseClick(FilePoint clickLocation, MouseButtons button) {
			// no implementation
		}
		
		public override void HandleMouseMove(FilePoint oldLocation, FilePoint newLocation) {
			if (_mouseDown) {
				Color myColor = (Color)GetProperty("Color").value;
				if (IsAdjacent(oldLocation,newLocation)) {
					StampBrush(newLocation.fileX,newLocation.fileY);
				} else {
					StampBrush(newLocation.fileX,newLocation.fileY);
					DrawLine(oldLocation,newLocation);
				}
				myWorkspace.UpdateDisplayBox(true,false);
			}
		}
		
		private bool IsAdjacent(FilePoint point1, FilePoint point2) {
			if (Math.Abs(point1.fileX - point2.fileX) > 1) {
				return false;
			}
			if (Math.Abs(point1.fileY - point2.fileY) > 1) {
				return false;
			}
			return true;
		}
		
		private void DrawLine(FilePoint point1, FilePoint point2) {
			// bresenhem's
			int x1,x2,y1,y2;
			if (point1.fileX <= point2.fileX) {
				x1 = point1.fileX;
				y1 = point1.fileY;
				
				x2 = point2.fileX;
				y2 = point2.fileY;
			} else {
				x1 = point2.fileX;
				y1 = point2.fileY;
				
				x2 = point1.fileX;
				y2 = point1.fileY;
			}
			
			if (Math.Abs((x2 - x1)) > Math.Abs(y2 - y1)) {
				int A = 2 * Math.Abs(y2 - y1);
				int B = A - (2 * Math.Abs(x2 - x1));
				int P = A - (x2 - x1);
				
				int currentY = y1;
				for (int currentX = x1+1; currentX < x2; currentX++) {
					if (P < 0) {
						P += A;
					} else {
						if (y2 > y1) {
							currentY++;
						} else {
							currentY--;
						}
						P += B;
					}
					StampBrush(currentX,currentY);
				}
			} else {
				if (y1 > y2) {
					int temp = y1;
					y1 = y2;
					y2 = temp;
					temp = x1;
					x1 = x2;
					x2 = temp;
				}
				int A = 2 * Math.Abs(x2 - x1);
				int B = A - (2 * Math.Abs(y2 - y1));
				int P = A - (y2 - y1);
				
				int currentX = x1;
				for (int currentY = y1+1; currentY < y2; currentY++) {
					if (P < 0) {
						P += A;
					} else {
						if (x2 > x1) {
							currentX++;
						} else {
							currentX--;
						}
						P += B;
					}
					StampBrush(currentX,currentY);
				}
			}
		}
		
		private void GenerateBrush() {
			this.currentBrush = new List<FilePoint>();
			
			float radius = Convert.ToSingle(GetProperty("Brush Size").value);
			
			for (float x = radius * -1; x < radius; x++) {
				for (float y = radius * -1; y < radius; y++) {
					if (IsPointInCircle(x + 0.5f, y + 0.5f, radius)) {
						currentBrush.Add(new FilePoint((int)x,(int)y));
					}
				}
			}
		}
		
		private bool IsPointInCircle(float x, float y, float radius) {
			// returns whether this condition is true or false
			return ((x*x)+(y*y)) <= (radius * radius);
		}
		
		private void StampBrush(int x, int y) {
			Color myColor = (Color)GetProperty("Color").value;
			Color currentColor;
			FilePoint stampPoint;
			
			foreach (FilePoint brushPoint in currentBrush) {
				stampPoint = new FilePoint(x + brushPoint.fileX, y + brushPoint.fileY);
				if (stampPoint.fileX < 0 ||
				    stampPoint.fileX >= myWorkspace.image.fileWidth ||
				    stampPoint.fileY < 0  ||
				    stampPoint.fileY >= myWorkspace.image.fileHeight) {
					continue;
				}
				currentColor = myWorkspace.image.GetPixel(stampPoint);
				if (!setHashes.Contains(stampPoint.ToString())) { // if this pixel is not yet in the history
					setPixels.Add(stampPoint,currentColor);
					setHashes.Add(stampPoint.ToString());
					if (!strokeHashes.Contains(stampPoint.ToString())) {
						strokePixels.Add(stampPoint,myWorkspace.image.GetPixel(stampPoint));
						strokeHashes.Add(stampPoint.ToString());
					}
				}
			}
			
			PixelAction newAction = new PixelAction();
			
			foreach (KeyValuePair<FilePoint,Color> pixel in setPixels) {
				newAction.AddPixel(pixel.Key,pixel.Value,myColor);
			}
			setPixels.Clear();
			setHashes.Clear();
			
			myWorkspace.PerformActionSilent(newAction);
		}
	}
}
