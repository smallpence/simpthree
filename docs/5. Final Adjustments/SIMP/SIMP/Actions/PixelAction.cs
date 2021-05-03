/*
 * Created by SharpDevelop.
 * User: 13SYoung
 * Date: 05/11/2019
 * Time: 17:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SIMP.Actions
{
	/// <summary>
	/// An action that changes the pixels of the image
	/// </summary>
	public class PixelAction : IAction
	{
		private Dictionary<FilePoint,Color> oldPixels;
		private Dictionary<FilePoint,Color> newPixels;
		public Layer layerPerformedOn = null;
		
		public PixelAction()
		{
			oldPixels = new Dictionary<FilePoint, Color>();
			newPixels = new Dictionary<FilePoint, Color>();
		}
		
		/// <summary>
		/// Record a new pixel change
		/// </summary>
		/// <param name="pixelLocation">The location of this change</param>
		/// <param name="oldColour">What it was before</param>
		/// <param name="newColour">What it changes to</param>
		public void AddPixel(FilePoint pixelLocation, Color oldColour, Color newColour) {
			// saves the old and new colours in the dictionary
			oldPixels[pixelLocation] = oldColour;
			newPixels[pixelLocation] = newColour;
		}
		
		/// <summary>
		/// Set the pixels
		/// </summary>
		/// <param name="workspace"></param>
		public void Do(Workspace workspace) {
			// Records the layer this action is performed on if necessary
			if (layerPerformedOn == null) {
				layerPerformedOn = workspace.image.currentLayer;
			} else { // if there is already a layer recorded
				// switch the current selected layer to the one this action is bound to
				workspace.image.currentLayer = layerPerformedOn;
			}
			
			// goes through all the pixels and sets them
			foreach (KeyValuePair<FilePoint,Color> pixel in newPixels) {
				workspace.image.SetPixel(pixel.Key,pixel.Value);
			}
			
			workspace.UpdateDisplayBox(true,false);
		}
		
		public void Undo(Workspace workspace) {
			// there must be a recorded layer now so no need to check
			workspace.image.currentLayer = layerPerformedOn;
			foreach (KeyValuePair<FilePoint,Color> pixel in oldPixels) {
				workspace.image.SetPixel(pixel.Key,pixel.Value);
			}
			
			workspace.UpdateDisplayBox(true,false);
		}
	}
}
