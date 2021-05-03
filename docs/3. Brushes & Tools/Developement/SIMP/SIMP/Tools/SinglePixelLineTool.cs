/*
 * Created by SharpDevelop.
 * User: 13SYoung
 * Date: 19/11/2019
 * Time: 17:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using SIMP.Properties;

namespace SIMP.Tools
{
	/// <summary>
	/// Description of SinglePixelLineTool.
	/// </summary>
	public class SinglePixelLineTool : LineTool
	{
		public SinglePixelLineTool(string name, string description, Workspace myWorkspace)
			: base(name,description,myWorkspace)
		{
			this.properties.Clear(); // removes all previous properties
			this.properties.Add(new ColorProperty("Color",Color.Black,PropertyType.Normal,myWorkspace));
			this.properties.Add(new DecimalProperty("Brush Size",0.5M,0.5M,0.5M,PropertyType.Hidden,myWorkspace));
		}
	}
}
