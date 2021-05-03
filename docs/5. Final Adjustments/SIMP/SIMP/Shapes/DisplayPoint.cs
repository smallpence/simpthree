/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 25/09/2019
 * Time: 11:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SIMP
{
	/// <summary>
	/// A point relative to the display window, e.g 0,0 is top right of window
	/// </summary>
	public class DisplayPoint
	{
		public int displayX;
		public int displayY;
		
		public DisplayPoint(int displayX, int displayY)
		{
			this.displayX = displayX;
			this.displayY = displayY;
		}
		
		public int GetDisplayValue(EAxis axis) {
			switch (axis) {
				case EAxis.X:
					return displayX;
					
				case EAxis.Y:
					return displayY;
					
				default:
					throw new Exception("Invalid value for Axis");
			}
		}
		
		public override string ToString()
		{
			return string.Format("[DisplayPoint DisplayX={0}, DisplayY={1}]", displayX, displayY);
		}
	}
}
