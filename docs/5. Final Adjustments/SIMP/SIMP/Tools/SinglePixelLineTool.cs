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
using System.Windows.Forms;
using SIMP.Properties;

namespace SIMP.Tools
{
	/// <summary>
	/// Tool for setting one pixel at a time
	/// </summary>
	public class SinglePixelLineTool : LineTool
	{
		public SinglePixelLineTool(string name, string description, Workspace myWorkspace, System.Drawing.Image icon)
			: base(name,description,myWorkspace, icon)
		{
			this.properties.Clear(); // removes all previous properties
			this.properties.Add(new ColorProperty("Color",Color.Black,PropertyType.Normal,myWorkspace));
			// simply creates a brush of size 0.5 than cannot be edited (PropertyType is hidden)
			this.properties.Add(new DecimalProperty("Brush Size",0.5M,0.5M,0.5M,PropertyType.Hidden,myWorkspace));
			this.icon = icon;
		}
	}
	
	/// <summary>
	/// Tool for getting the colour at a location
	/// </summary>
	public class EyedropperTool : ITool {
		public ColorProperty editingProperty; // the colour property that will be written to when clicking a colour
		public ITool returnToTool; // the tool to switch back to when done selecting
		
		public EyedropperTool(string name, string description, Workspace myWorkspace, ColorProperty editingProperty, ITool returnToTool)
		{
			this.name = name;
			this.description = description;
			this.myWorkspace = myWorkspace;
			this.editingProperty = editingProperty;
			this.returnToTool = returnToTool;
		}
		
		public override void HandleMouseClick(FilePoint clickLocation, MouseButtons button) {
			Color color = myWorkspace.image.GetPixel(clickLocation);
			// should not be able to get a transparent colour - use the eraser
			if (color == Color.Transparent) color = Color.White;
			editingProperty.value = color;
			myWorkspace.currentTool = returnToTool;
			myWorkspace.ShowTool(); // show the tool again so it updates
		}
		
		public override void HandleMouseDown(FilePoint clickLocation, MouseButtons button) { 
			// no implementation
		}
		
		public override void HandleMouseUp(FilePoint clickLocation, MouseButtons button) {
			// no implementation
		}
		
		public override void HandleMouseMove(FilePoint oldLocation, FilePoint newLocation) {
			// no implementation
		}
	}
}
