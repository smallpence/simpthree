/*
 * Created by SharpDevelop.
 * User: 13SYoung
 * Date: 05/11/2019
 * Time: 17:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIMP.Properties;

namespace SIMP.Tools
{
	/// <summary>
	/// Description of ITool.
	/// </summary>
	public abstract class ITool
	{
		public string name;
		public string description;
		public List<IProperty> properties;
		public Workspace myWorkspace;
		
		public abstract void HandleMouseDown(FilePoint clickLocation, MouseButtons button);
		public abstract void HandleMouseUp(FilePoint clickLocation, MouseButtons button);
		public abstract void HandleMouseClick(FilePoint clickLocation, MouseButtons button);
		public abstract void HandleMouseMove(FilePoint oldLocation, FilePoint newLocation);
		
		public SIMP.Properties.IProperty GetProperty(string propertyName) {
			//TODO: ITool GetProperty()
			foreach (IProperty property in properties) {
				if (property.name.Equals(propertyName)) {
					return property;
				}
			}
			throw new KeyNotFoundException("Couldn't find property " + propertyName);
		}
		
		//blanktool
		public static ITool BlankTool;
		
		static ITool() {
			BlankTool = new BlankTool();
		}
	}
}
