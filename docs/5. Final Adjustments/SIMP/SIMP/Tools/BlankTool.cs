/*
 * Created by SharpDevelop.
 * User: Sammy
 * Date: 16/11/2019
 * Time: 17:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace SIMP.Tools
{
	/// <summary>
	/// A null tool
	/// Used for situations where a dummy is needed
	/// </summary>
	internal class BlankTool : ITool
	{
		internal BlankTool()
		{
		}
		
		// no implementation
		// nothing happens ever
		public override void HandleMouseDown(FilePoint clickLocation, MouseButtons button){}
		public override void HandleMouseUp(FilePoint clickLocation, MouseButtons button){}
		public override void HandleMouseClick(FilePoint clickLocation, MouseButtons button){}
		public override void HandleMouseMove(FilePoint oldLocation, FilePoint newLocation){}
	}
}
