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
	/// Description of FillTool.
	/// </summary>
	public class FillTool : IPixelTool
	{
		private FilePoint point1;
		private List<FilePoint> fillPoints;
		private List<string> hashedPoints;
		private Queue<FilePoint> pointQueue;
		private Color targetColor;
		
		public FillTool(string name, string description, Workspace myWorkspace) : base (name,description,myWorkspace)
		{ 
			this.fillPoints = new List<FilePoint>();
			this.pointQueue = new Queue<FilePoint>();
			this.hashedPoints = new List<string>();
			this.properties.Add(new ColorProperty("Color",Color.Black,PropertyType.Normal,myWorkspace));
		}
		
		internal override void AddShapePoint(int x, int y)
		{
			
		}
		
		internal override void GenShape()
		{
			pointQueue.Enqueue(point1);
			FilePoint currentPoint;
			
			while (pointQueue.Count > 0) {
				currentPoint = pointQueue.Dequeue();
				AddTile(new FilePoint(currentPoint.fileX+1,currentPoint.fileY));
				AddTile(new FilePoint(currentPoint.fileX,currentPoint.fileY+1));
				AddTile(new FilePoint(currentPoint.fileX-1,currentPoint.fileY));
				AddTile(new FilePoint(currentPoint.fileX,currentPoint.fileY-1));
			}
		}
		
		private void AddTile(FilePoint point) {
			if (CheckAddTile(point)) {
				pointQueue.Enqueue(point);
				shapePoints.Add(point);
				hashedPoints.Add(point.ToString());
			}
		}
		
		private bool CheckAddTile(FilePoint point) {
			Color myColor = (Color)GetProperty("Color").value;  
			if (point.fileX < 0 ||
			    point.fileY < 0 ||
			    point.fileX >= myWorkspace.image.fileWidth ||
			   	point.fileY >= myWorkspace.image.fileHeight) {
				return false;
			}
			
			if (myWorkspace.image.GetPixel(point) != targetColor) {
				return false;
			}
			
			if (hashedPoints.Contains(point.ToString())) {
				return false;
			}
			
			return true;
		}
		
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
			fillPoints = new List<FilePoint>();
			pointQueue = new Queue<FilePoint>();
			hashedPoints = new List<string>();
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
