/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 20/11/2019
 * Time: 11:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace SIMP.Properties
{
	/// <summary>
	/// Property that stores a Decimal
	/// </summary>
	public class DecimalProperty : IProperty
	{
		public decimal min;
		public decimal max;
		
		public DecimalProperty(string name, decimal value, decimal min, decimal max, PropertyType propertyType, Workspace myWorkspace)
		{
			this.name = name;
			this.value = value;
			this.min = min;
			this.max = max;
			this.myWorkspace = myWorkspace;
			this.propertyType = propertyType;
			
			this.onInteract = delegate(Object sender, EventArgs e) {
				this.value = (decimal)((NumericUpDown)sender).Value;
				myWorkspace.ShowTool();
			};
		}
	}
}
