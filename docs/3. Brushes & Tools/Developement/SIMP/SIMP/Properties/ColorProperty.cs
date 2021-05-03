/*
 * Created by SharpDevelop.
 * User: 13SYoung
 * Date: 05/11/2019
 * Time: 17:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SIMP.Properties
{
	/// <summary>
	/// Description of ColorProperty.
	/// </summary>
	public class ColorProperty :IProperty
	{
		public ColorProperty(string name, Color value, PropertyType propertyType, Workspace myWorkspace)
		{
			this.name = name;
			this.value = value;
			this.myWorkspace = myWorkspace;
			this.propertyType = propertyType;
			
			this.onInteract = delegate(Object sender, EventArgs e) {
				RGBPicker newPicker = new RGBPicker((Color)this.value,ColorCallback);
				newPicker.Show();
			};
		}
		
		private void ColorCallback(Color newColour) {
			this.value = newColour;
			myWorkspace.ShowTool();
		}
	}
}
