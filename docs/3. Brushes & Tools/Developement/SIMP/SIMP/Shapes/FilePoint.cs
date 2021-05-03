/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 25/09/2019
 * Time: 11:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace SIMP
{
	/// <summary>
	/// Description of FilePoint.
	/// </summary>
	public class FilePoint
	{
		public int fileX;
		public int fileY;
		
		public FilePoint(int fileX, int fileY)
		{
			this.fileX = fileX;
			this.fileY = fileY;
		}
		
		public FilePoint(Point p) : this(p.X,p.Y) {
			// no extra implementation
		}
		
		public FilePoint(FilePoint fp) : this(fp.fileX,fp.fileY) {
			// no extra implementation
		}
		
		public int GetFileValue(EAxis axis) {
			switch (axis) {
				case EAxis.X:
					return fileX;
					
				case EAxis.Y:
					return fileY;
					
				default:
					throw new Exception("Invalid value for Axis");
			}
		}
		
		public override string ToString()
		{
			return string.Format("[FilePoint FileX={0}, FileY={1}]", fileX, fileY);
		}
		
		public override int GetHashCode()
    	{
			return base.GetHashCode();
    	}

 		public override bool Equals(object obj)
    	{
 			FilePoint other = (FilePoint)obj;
 			return other.fileX == fileX && other.fileY == fileY;
    	}
	}
}
