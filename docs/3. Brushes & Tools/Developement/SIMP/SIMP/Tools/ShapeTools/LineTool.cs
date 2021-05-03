/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 28/11/2019
 * Time: 15:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using SIMP.Properties;

namespace SIMP.Tools.ShapeTools
{
	/// <summary>
	/// Description of LineTool.
	/// </summary>
	public class LineTool : IShapeTool
	{
		public LineTool(string name, string description, Workspace myWorkspace) : base (name,description,myWorkspace)
		{
		}
		
		internal override void ResolvePoints() {
			// do nothing
		}
		
		internal override void GenShape()
		{
			// makes the the start and end points are part of the line
			AddShapePoint(point1.fileX,point1.fileY);
			AddShapePoint(point2.fileX,point2.fileY);
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
					AddShapePoint(currentX,currentY);
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
					AddShapePoint(currentX,currentY);
				}
			}
		}
	}
}
