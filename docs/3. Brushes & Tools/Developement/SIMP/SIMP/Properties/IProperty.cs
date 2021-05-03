/*
 * Created by SharpDevelop.
 * User: 13SYoung
 * Date: 05/11/2019
 * Time: 17:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SIMP.Properties
{
	/// <summary>
	/// Description of IProperty.
	/// </summary>
	public abstract class IProperty
	{
		public string name;
		public object value;
		public EventHandler onInteract;
		public Workspace myWorkspace;
		public PropertyType propertyType;
	}
}
