/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 28/11/2019
 * Time: 15:06
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
	/// A pixel tool that generates a shape
	/// Implements everything except shape generation
	/// This leaves shape generation up to children
	/// </summary>
	public abstract class IShapeTool : IPixelTool
	{
		Dictionary<string,bool> addedPoints;
		
		public IShapeTool(string name, string description, Workspace myWorkspace, System.Drawing.Image icon)
			: base(name,description,myWorkspace,icon) {
			this.point1 = null;
			this.point2 = null;
			this.properties.Add(new ColorProperty("Color",Color.Black,PropertyType.Normal,myWorkspace));
			this.addedPoints = new Dictionary<string, bool>();
		}
		
		internal FilePoint point1;
		internal FilePoint point2;
		
		public override void HandleMouseMove(FilePoint oldLocation, FilePoint newLocation)
		{
			// do nothing upon mouse move
		}
		
		public override void HandleMouseClick(FilePoint clickLocation, System.Windows.Forms.MouseButtons button)
		{
			if (point1 == null) {
				point1 = clickLocation;
			} else {
				point2 = clickLocation;
				ResolvePoints();
				GenShape();
				DrawShape();
				point1 = null;
			}
		}
		
		public override void HandleMouseUp(FilePoint clickLocation, System.Windows.Forms.MouseButtons button)
		{
			// do nothing upon mouse up
		}
		
		public override void HandleMouseDown(FilePoint clickLocation, System.Windows.Forms.MouseButtons button)
		{
			// do nothing upon mouse down
		}
		
		internal override void AddShapePoint(int x, int y)
		{
			if (!addedPoints.ContainsKey(x.ToString() + " " + y.ToString())) {
				addedPoints.Add(x.ToString() + " " + y.ToString(),true);
			}
			shapePoints.Add(new FilePoint(x,y));
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
			addedPoints = new Dictionary<string, bool>();
		}
		
		// virtual as LineTool needs to override it
		internal virtual void ResolvePoints() {
			int highX,highY,lowX,lowY = 0;
			
			if (point1.fileX > point2.fileX) {
				highX = point1.fileX;
				lowX = point2.fileX;
			} else {
				highX = point2.fileX;
				lowX = point1.fileX;
			}
			
			if (point1.fileY > point2.fileY) {
				highY = point1.fileY;
				lowY = point2.fileY;
			} else {
				highY = point2.fileY;
				lowY = point1.fileY;
			}
			
			point1 = new FilePoint(lowX,lowY);
			point2 = new FilePoint(highX,highY);
		}
	}
}
