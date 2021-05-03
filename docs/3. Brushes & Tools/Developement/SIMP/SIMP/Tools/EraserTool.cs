/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 28/11/2019
 * Time: 14:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using SIMP.Properties;

namespace SIMP.Tools
{
	/// <summary>
	/// Description of EraserTool.
	/// </summary>
	public class EraserTool : LineTool
	{
		public EraserTool(string name, string description, Workspace myWorkspace)
			: base(name,description,myWorkspace)
		{
			this.properties.Clear(); // removes all previous properties
			this.properties.Add(new ColorProperty("Color",Color.Transparent,PropertyType.Hidden,myWorkspace));
			this.properties.Add(new NumericalProperty("Brush Size",5,1,20,PropertyType.Normal,myWorkspace));
		}
	}
}
