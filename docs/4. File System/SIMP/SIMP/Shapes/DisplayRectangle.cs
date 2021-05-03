/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 25/09/2019
 * Time: 12:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SIMP
{
	/// <summary>
	/// Description of DisplayRectangle.
	/// </summary>
	public class DisplayRectangle : IPictureRectangle
	{
		private DisplayPoint _displayTopLeftCorner;
		private DisplayPoint _displayBottomRightCorner;
		
		public DisplayRectangle(
			int displayTopLeftX, int displayTopLeftY,
			int displayBottomRightX, int displayBottomRightY
		)
		{
			_displayTopLeftCorner = new DisplayPoint(displayTopLeftX,displayTopLeftY);
			_displayBottomRightCorner = new DisplayPoint(displayBottomRightX,displayBottomRightY);
		}
		
		public FileRectangle ToFileRectangle() {
			throw new NotImplementedException();
		}
		
		public DisplayRectangle ToDisplayRectangle() {
			return new DisplayRectangle(
				_displayTopLeftCorner.GetDisplayValue(EAxis.X),
				_displayTopLeftCorner.GetDisplayValue(EAxis.Y),
				_displayBottomRightCorner.GetDisplayValue(EAxis.X),
				_displayBottomRightCorner.GetDisplayValue(EAxis.Y)
			);
		}
		
		public DisplayPoint GetTopLeftCorner() {
			return _displayTopLeftCorner;
		}
		
		public DisplayPoint GetBottomRightCorner() {
			return _displayBottomRightCorner;
		}
		
		public int GetDisplaySize(EAxis axis) {
			return _displayBottomRightCorner.GetDisplayValue(axis) - _displayTopLeftCorner.GetDisplayValue(axis);
		}
	}
}
