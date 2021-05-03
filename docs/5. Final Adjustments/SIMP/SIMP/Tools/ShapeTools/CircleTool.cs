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
	/// Tool for drawing a circle shape
	/// </summary>
	public class CircleTool : IShapeTool
	{
		public CircleTool(string name, string description, Workspace myWorkspace, System.Drawing.Image icon) : base (name,description,myWorkspace,icon)
		{ }
		
		/// <summary>
		/// Generates the shape from its current parameters and stores it in a list of points
		/// </summary>
		internal override void GenShape()
		{
			// Centre Location is halfway between the points clicked on the image
			double centreLocX = ((point1.fileX + point2.fileX) / 2);
			double centreLocY = ((point1.fileY + point2.fileY) / 2);
			// Doesn't square root as result of the distance calculation also outputs a squared number
			double widthSquared = Math.Pow((point2.fileX - (point1.fileX-1))/2,2);
			double heightSquared = Math.Pow((point2.fileY - (point1.fileY-1))/2,2);
			
			// Looks through every possible candidate point
			for (int x = point1.fileX; x <= point2.fileX; x++) {
				for (int y = point1.fileY; y <= point2.fileY; y++) {
					// if its distance to the centre is less than the radius of the circle
					if ((Math.Pow(x-centreLocX,2) / widthSquared) +
					    (Math.Pow(y-centreLocY,2) / heightSquared) <= 1) {
						// its a point in the circle, add it
						AddShapePoint(x,y);
					}
				}
			}
		}
	}
}
