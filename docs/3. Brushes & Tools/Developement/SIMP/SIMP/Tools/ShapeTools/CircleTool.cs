/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 28/11/2019
 * Time: 15:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace SIMP.Tools.ShapeTools
{
	/// <summary>
	/// Description of CircleTool.
	/// </summary>
	public class CircleTool : IShapeTool
	{
		public CircleTool(string name, string description, Workspace myWorkspace) : base (name,description,myWorkspace)
		{ }
		
		internal override void GenShape()
		{
			double centreLocX = ((point1.fileX + point2.fileX) / 2);
			double centreLocY = ((point1.fileY + point2.fileY) / 2);
			double widthSquared = Math.Pow((point2.fileX - (point1.fileX-1))/2,2);
			double heightSquared = Math.Pow((point2.fileY - (point1.fileY-1))/2,2);
			
			for (int x = point1.fileX; x <= point2.fileX; x++) {
				for (int y = point1.fileY; y <= point2.fileY; y++) {
					//MessageBox.Show((Math.Pow(x-centreLocX,2) / widthSquared).ToString() + " " + (Math.Pow(y-centreLocY,2) / heightSquared).ToString());
					if ((Math.Pow(x-centreLocX,2) / widthSquared) +
					    (Math.Pow(y-centreLocY,2) / heightSquared) <= 1) {
						AddShapePoint(x,y);
					}
				}
			}
		}
	}
}
