/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 28/11/2019
 * Time: 15:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Collections.Generic;
using SIMP.Actions;
using SIMP.Properties;

namespace SIMP.Tools.ShapeTools
{
	/// <summary>
	/// Tool for filling a large area of identical color
	/// </summary>
	public class FillTool : IPixelTool
	{
		private FilePoint point1;
		private List<FilePoint> fillPoints;
		private Dictionary<string,bool> hashedPoints;
		private Queue<FilePoint> pointQueue;
		private Color targetColor;
		
		public FillTool(string name, string description, Workspace myWorkspace, System.Drawing.Image icon) : base (name,description,myWorkspace,icon)
		{ 
			this.fillPoints = new List<FilePoint>();
			this.pointQueue = new Queue<FilePoint>();
			this.hashedPoints = new Dictionary<string,bool>();
			this.properties.Add(new ColorProperty("Color",Color.Black,PropertyType.Normal,myWorkspace));
		}
		
		internal override void AddShapePoint(int x, int y)
		{
			// doesnt need to do anything
		}
		
		internal override void GenShape()
		{
			// Adds the starting point to the list of points
			pointQueue.Enqueue(point1);
			FilePoint currentPoint;
			
			// While there are still points left to be checked
			while (pointQueue.Count > 0) {
				currentPoint = pointQueue.Dequeue();
				// Attempt to add the 4 tiles around it
				AddTile(new FilePoint(currentPoint.fileX+1,currentPoint.fileY));
				AddTile(new FilePoint(currentPoint.fileX,currentPoint.fileY+1));
				AddTile(new FilePoint(currentPoint.fileX-1,currentPoint.fileY));
				AddTile(new FilePoint(currentPoint.fileX,currentPoint.fileY-1));
			}
		}
		
		/// <summary>
		/// May or may not add the point
		/// </summary
		private void AddTile(FilePoint point) {
			if (CheckAddTile(point)) {
				// check any points around this one
				pointQueue.Enqueue(point);
				shapePoints.Add(point);
				// to make searching faster - a list of strings is used to check whether a point has been added
				hashedPoints.Add(point.ToString(),true);
			}
		}
		
		private bool CheckAddTile(FilePoint point) {
			// if the list hash doesnt already contain the point
			if (hashedPoints.ContainsKey(point.ToString())) {
				return false;
			}
			
			// if out of bounds			
			if (point.fileX < 0 ||
			    point.fileY < 0 ||
			    point.fileX >= myWorkspace.image.fileWidth ||
			   	point.fileY >= myWorkspace.image.fileHeight) {
				return false;
			}
			
			// if not of the same color as the start color
			if (myWorkspace.image.GetPixel(point) != targetColor) {
				return false;
			}
			
			return true;
		}
		
		/// <summary>
		/// Prints the generated shape onto canvas
		/// </summary>
		internal override void DrawShape()
		{
			Color myColor = (Color)GetProperty("Color").value;
			PixelAction newAction = new PixelAction();
			
			foreach (FilePoint shapePoint in shapePoints) {
				newAction.AddPixel(shapePoint,myWorkspace.image.GetPixel(shapePoint),myColor);
			}
			
			myWorkspace.PerformAction(newAction);
			shapePoints.Clear();
			myWorkspace.UpdateLayersSelector(false);
		}
		
		public override void HandleMouseMove(FilePoint oldLocation, FilePoint newLocation)
		{
			//none
		}
		
		public override void HandleMouseClick(FilePoint clickLocation, System.Windows.Forms.MouseButtons button)
		{
			targetColor = myWorkspace.image.GetPixel(clickLocation);
			// reset everything
			fillPoints = new List<FilePoint>();
			pointQueue = new Queue<FilePoint>();
			hashedPoints = new Dictionary<string,bool>();
			point1 = new FilePoint(clickLocation.fileX,clickLocation.fileY);
			GenShape();
			DrawShape();
		}
		
		public override void HandleMouseUp(FilePoint clickLocation, System.Windows.Forms.MouseButtons button)
		{
			//none
		}
		
		public override void HandleMouseDown(FilePoint clickLocation, System.Windows.Forms.MouseButtons button)
		{
			//none
		}
	}
}
