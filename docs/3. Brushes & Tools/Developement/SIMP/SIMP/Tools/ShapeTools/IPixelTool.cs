/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 28/11/2019
 * Time: 15:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using SIMP.Properties;

namespace SIMP.Tools.ShapeTools
{
	/// <summary>
	/// A generic pixel based tool
	/// </summary>
	public abstract class IPixelTool : ITool
	{
		public IPixelTool(string name, string description, Workspace myWorkspace) {
			this.name = name;
			this.description = description;
			this.myWorkspace = myWorkspace;
			this.properties = new System.Collections.Generic.List<IProperty>();
			this.shapePoints = new List<FilePoint>();
		}
		
		internal List<FilePoint> shapePoints;
		
		internal abstract void GenShape();
		
		internal abstract void DrawShape();
		
		internal abstract void AddShapePoint(int x, int y);
	}
}
