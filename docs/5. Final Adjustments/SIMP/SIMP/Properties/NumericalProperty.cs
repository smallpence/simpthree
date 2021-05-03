/*
 * Created by SharpDevelop.
 * User: 13SYoung
 * Date: 05/11/2019
 * Time: 17:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace SIMP.Properties
{
	/// <summary>
	/// Property that stores a Number
	/// </summary>
	public class NumericalProperty : IProperty
	{
		public int min;
		public int max;
		
		public NumericalProperty(string name, int value, int min, int max, PropertyType propertyType, Workspace myWorkspace)
		{
			this.name = name;
			this.value = value;
			this.min = min;
			this.max = max;
			this.myWorkspace = myWorkspace;
			this.propertyType = propertyType;
			
			// When the number box is changed
			this.onInteract = delegate(Object sender, EventArgs e) {
				// Update the internal value
				this.value = (int)((NumericUpDown)sender).Value;
				myWorkspace.ShowTool();
			};
		}
	}
	
	/// <summary>
	/// Property that stores potential strings
	/// </summary>
	public class ComboProperty : IProperty
	{
		public string[] options;
		
		public ComboProperty(string name, int startIndex, string[] options, PropertyType propertyType, Workspace myWorkspace)
		{
			this.name = name;
			this.value = value;
			this.options = options;
			this.value = options[startIndex];
			this.myWorkspace = myWorkspace;
			this.propertyType = propertyType;
			
			// When the list box is changed
			this.onInteract = delegate(Object sender, EventArgs e) {
				// Update the internal value
				this.value = (string)((ComboBox)sender).SelectedItem;
				myWorkspace.ShowTool();
			};
		}
	}
}
