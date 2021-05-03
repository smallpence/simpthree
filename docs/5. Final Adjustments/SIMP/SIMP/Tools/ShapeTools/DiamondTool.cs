/*
 * Created by SharpDevelop.
 * User: 13SYoung
 * Date: 30/11/2019
 * Time: 17:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace SIMP.Tools.ShapeTools
{
	/// <summary>
	/// Tool for drawing a diamond shape
	/// </summary>
	public class DiamondTool : IShapeTool
	{
		public DiamondTool(string name, string description, Workspace myWorkspace, System.Drawing.Image icon) : base (name,description,myWorkspace,icon)
		{ }
		
		/// <summary>
		/// Generates the shape from its current parameters and stores it in a list of points
		/// </summary>
		internal override void GenShape()
		{
			// This code is almost identical to the circle code, except not squared
			// this results in a diamond shape
			double centreLocX = ((point1.fileX + point2.fileX) / 2);
			double centreLocY = ((point1.fileY + point2.fileY) / 2);
			double width = (point2.fileX - point1.fileX)/2;
			double height = (point2.fileY - point1.fileY)/2;
			
			for (int x = point1.fileX; x <= point2.fileX; x++) {
				for (int y = point1.fileY; y <= point2.fileY; y++) {
					if ((Math.Abs(((double)x + 0.5)-centreLocX) / width) +
					    (Math.Abs(((double)y + 0.5)-centreLocY) / height) <= 1) {
						AddShapePoint(x,y);
					}
				}
			}
		}
	}
}
