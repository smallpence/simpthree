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
	/// Description of PixelAction.
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
		
		public void AddPixel(FilePoint pixelLocation, Color oldColour, Color newColour) {
			// saves the old and new colours in the dictionary
			oldPixels[pixelLocation] = oldColour;
			newPixels[pixelLocation] = newColour;
		}
		
		public void Do(Workspace workspace) {
			if (layerPerformedOn == null) {
				layerPerformedOn = workspace.image.currentLayer;
			} else {
				workspace.image.currentLayer = layerPerformedOn;
			}
			
			foreach (KeyValuePair<FilePoint,Color> pixel in newPixels) {
				workspace.image.SetPixel(pixel.Key,pixel.Value);
			}
			
			workspace.UpdateDisplayBox(true,false);
		}
		
		public void Undo(Workspace workspace) {
			workspace.image.currentLayer = layerPerformedOn;
			foreach (KeyValuePair<FilePoint,Color> pixel in oldPixels) {
				workspace.image.SetPixel(pixel.Key,pixel.Value);
			}
			
			workspace.UpdateDisplayBox(true,false);
		}
	}
}
