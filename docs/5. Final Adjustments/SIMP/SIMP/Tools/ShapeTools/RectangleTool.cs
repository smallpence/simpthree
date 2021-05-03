/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 28/11/2019
 * Time: 15:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SIMP.Tools.ShapeTools
{
	/// <summary>
	/// Tool for drawing a rectangle
	/// </summary>
	public class RectangleTool : IShapeTool
	{
		public RectangleTool(string name, string description, Workspace myWorkspace, System.Drawing.Image icon) : base (name,description,myWorkspace,icon)
		{ }
		
		internal override void GenShape() {
			// simplest generation - add everything between the two points
			for (int x = point1.fileX; x <= point2.fileX; x++) {
				for (int y = point1.fileY; y <= point2.fileY; y++) {
					AddShapePoint(x,y);
				}
			}
		}
	}
}
