/*
 * Created by SharpDevelop.
 * User: 13SYoung
 * Date: 05/11/2019
 * Time: 17:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace SIMP
{
	/// <summary>
	/// Description of Layer.
	/// </summary>
	public class Layer
	{
		public SolidBrush[,] pixels;
		public bool visible;
		
		public Layer(int width, int height)
		{
			// dimension array
			pixels = new SolidBrush[width,height];
			visible = true;
			
			// populate array
			for (int x = 0; x < width; x++) {
				for (int y = 0; y < height; y++) {
					pixels[x,y] = new SolidBrush(Color.Transparent);
				}
			}
		}
	}
}
