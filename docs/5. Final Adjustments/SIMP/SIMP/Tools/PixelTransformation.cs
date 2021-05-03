/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 20/12/2019
 * Time: 10:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace SIMP.Tools
{
	/// <summary>
	/// A transformation applied to an input colour that returns an output colour
	/// </summary>
	public class PixelTransformation
	{
		public delegate Color Transformation(Color input);
		public Transformation transform;
		
		// averages the R, G, and B values
		public static PixelTransformation GrayScale {
			get {
				PixelTransformation transformation = new PixelTransformation();
				transformation.transform = delegate(Color input) {
					int total = input.R + input.G + input.B;
					int average = total / 3;
					return Color.FromArgb(average,average,average);
				};
				return transformation;
			}
		}
		
		// averages the R, G and B values and checks if they are above a certain threshold
		public static PixelTransformation BlackAndWhite {
			get {
				PixelTransformation transformation = new PixelTransformation();
				transformation.transform = delegate(Color input) {
					int total = input.R + input.G + input.B;
					// 381 is roughly (255 + 255 + 255) / 2, or mid-colour
					if (total < 381) {
						return Color.Black;
					} else {
						return Color.White;
					}
				};
				return transformation;
			}
		}
		
		// subtracts each R, G and B value from 255
		public static PixelTransformation Invert {
			get {
				PixelTransformation transformation = new PixelTransformation();
				transformation.transform = delegate(Color input) {
					int newR = 255 - input.R;
					int newG = 255 - input.G;
					int newB = 255 - input.B;
					return Color.FromArgb(newR,newG,newB);
				};
				return transformation;
			}
		}
	}
}
