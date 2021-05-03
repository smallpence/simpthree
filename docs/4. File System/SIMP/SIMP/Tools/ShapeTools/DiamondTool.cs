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
	/// Description of DiamondTool.
	/// </summary>
	public class DiamondTool : IShapeTool
	{
		public DiamondTool(string name, string description, Workspace myWorkspace) : base (name,description,myWorkspace)
		{ }
		
		internal override void GenShape()
		{
			double centreLocX = ((point1.fileX + point2.fileX) / 2);
			double centreLocY = ((point1.fileY + point2.fileY) / 2);
			double width = (point2.fileX - point1.fileX)/2;
			double height = (point2.fileY - point1.fileY)/2;
			
			for (int x = point1.fileX; x <= point2.fileX; x++) {
				for (int y = point1.fileY; y <= point2.fileY; y++) {
					//MessageBox.Show((Math.Pow(x-centreLocX,2) / widthSquared).ToString() + " " + (Math.Pow(y-centreLocY,2) / heightSquared).ToString());
					if ((Math.Abs(((double)x + 0.5)-centreLocX) / width) +
					    (Math.Abs(((double)y + 0.5)-centreLocY) / height) <= 1) {
						AddShapePoint(x,y);
					}
				}
			}
		}
	}
}
