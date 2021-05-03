/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 20/12/2019
 * Time: 10:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SIMP.Properties;
using SIMP.Actions;

namespace SIMP.Tools
{
	/// <summary>
	/// Tool for apply effects to image
	/// </summary>
	public class FXTool : ITool
	{
		public FXTool(string name, string description, Workspace myWorkspace, System.Drawing.Image icon)
		{
			this.name = name;
			this.description = description;
			this.myWorkspace = myWorkspace;
			
			this.properties = new List<SIMP.Properties.IProperty>();
			this.properties.Add(new ComboProperty("Type",0,new string[] {"Grayscale","Black & White","Invert"}, PropertyType.Normal,myWorkspace));
			this.icon = icon;
		}
		
		public override void HandleMouseClick(FilePoint clickLocation, MouseButtons button) {
			PixelTransformation currentTransformation = null;
			
			// checks what the combo box was set to
			switch (this.GetProperty("Type").value.ToString()) {
				case "Grayscale":
					currentTransformation = PixelTransformation.GrayScale;
					break;
				case "Black & White":
					currentTransformation = PixelTransformation.BlackAndWhite;
					break;
				case "Invert":
					currentTransformation = PixelTransformation.Invert;
					break;
			}
			
			PixelAction action = new PixelAction();
			
			for (int x = 0; x < myWorkspace.image.fileWidth; x++) {
				for (int y = 0; y < myWorkspace.image.fileHeight; y++) {
					Color oldColor = myWorkspace.image.GetPixel(x,y);
					// dont try to edit transparent pixels - leave them as is
					// otherwise background can look weird
					if (oldColor == Color.Transparent) {
						continue;
					}
					// applies the transformation delegate
					Color newColor = currentTransformation.transform(oldColor);
					action.AddPixel(new FilePoint(x,y),oldColor,newColor);
				}
			}
			
			myWorkspace.PerformAction(action);
			myWorkspace.UpdateDisplayBox(true,true);
			myWorkspace.UpdateLayersSelector(true);
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
