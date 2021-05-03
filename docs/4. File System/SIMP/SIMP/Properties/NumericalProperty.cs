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
	/// Description of NumericalProperty.
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
			
			this.onInteract = delegate(Object sender, EventArgs e) {
				this.value = (int)((NumericUpDown)sender).Value;
				myWorkspace.ShowTool();
			};
		}
	}
}
