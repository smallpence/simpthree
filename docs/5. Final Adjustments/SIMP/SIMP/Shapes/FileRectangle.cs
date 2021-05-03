/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 25/09/2019
 * Time: 12:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SIMP
{
	/// <summary>
	/// A rectangle made of display points
	/// </summary>
	public class FileRectangle : IPictureRectangle
	{
		private FilePoint _fileTopLeftCorner;
		private FilePoint _fileBottomRightCorner;
		
		public FileRectangle(
			int fileTopLeftX, int fileTopLeftY,
			int fileBottomRightX, int fileBottomRightY
		)
		{
			_fileTopLeftCorner = new FilePoint(fileTopLeftX,fileTopLeftY);
			_fileBottomRightCorner = new FilePoint(fileBottomRightX,fileBottomRightY);
		}
		
		public FileRectangle ToFileRectangle() {
			return new FileRectangle(
				_fileTopLeftCorner.GetFileValue(EAxis.X),
				_fileTopLeftCorner.GetFileValue(EAxis.Y),
				_fileBottomRightCorner.GetFileValue(EAxis.X),
				_fileBottomRightCorner.GetFileValue(EAxis.Y)
			);
		}
		
		public DisplayRectangle ToDisplayRectangle() {
			// not needed
			return null;
		}
		
		public FilePoint GetTopLeftCorner() {
			return _fileTopLeftCorner;
		}
		
		public FilePoint GetBottomRightCorner() {
			return _fileBottomRightCorner;
		}
		
		public int GetFileSize(EAxis axis) {
			return _fileBottomRightCorner.GetFileValue(axis) - _fileTopLeftCorner.GetFileValue(axis);
		}
	}
}
