/*
 * Created by SharpDevelop.
 * User: 13SYoung
 * Date: 09/11/2019
 * Time: 15:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SIMP
{
	/// <summary>
	/// Description of RGBPicker.
	/// </summary>
	public partial class RGBPicker : Form
	{
		private bool _updating;
		private HSVColor _startColor;
		private HSVColor _currentColor;
		private ColorCallback _updateCallback;
		private static RGBPicker currentPicker = null;
		
		public RGBPicker(Color startColor, ColorCallback updateCallback)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			if (currentPicker != null) {
				currentPicker.Close();
			}
			currentPicker = this;
			
			_startColor = SIMPRGB.RGBtoHSV(startColor);
			_currentColor = SIMPRGB.RGBtoHSV(startColor);
			_updating = false;
			_updateCallback = updateCallback;
			SIMPRGB.cachedColor = startColor;
			
			Update(true);
		}
		
		#region Update
		private void Update(bool updateNums) {
			_updating = true;
			
			UpdateColourSquare();
			UpdateColourIndicator();
			UpdateColourStrip();
			UpdateColourDisplays();
			UpdateColourInputs(updateNums);
			
			_updating = false;
		}
		
		double oldHue = -1;
		System.Drawing.Image oldImage;
		private void UpdateColourSquare() {
			if (_currentColor.H.Equals(oldHue)) {
				return;
			}
			double hue = _currentColor.H;
			Bitmap newImage = new Bitmap(100,100);
			
			// generate eaxh pixel
			for (double x = 0; x < 100; x++) {
				for (double y = 0; y < 100; y++) {
					// uses 1-() in order to flip in y axis
					Color currentColour = SIMPRGB.HSVtoRGB(hue,x/100,1-(y/100));
					newImage.SetPixel((int)x,(int)y,currentColour);
				}
			}
			
			oldHue = hue;
			oldImage = newImage;
			picColourSquare.Image = newImage;
		}
		
		private void UpdateColourIndicator() {
			System.Drawing.Image editImage = new Bitmap(oldImage);
			Graphics GFX = Graphics.FromImage(editImage);
			
			Color color = (_currentColor.V > 0.5) ? Color.Black : Color.White;
			GFX.FillRectangle(new SolidBrush(color),(int)(_currentColor.S*100),0,1,100);
			GFX.FillRectangle(new SolidBrush(color),0,(int)((1-_currentColor.V)*100),100,1);
			
			picColourSquare.Image = editImage;
		}
		
		private void UpdateColourStrip() {
			Bitmap newImage = new Bitmap(20,100);
			Graphics GFX = Graphics.FromImage(newImage);
			
			for (float h = 0; h < 100; h++) {
				GFX.FillRectangle(new SolidBrush(SIMPRGB.HSVtoRGB(h*3.6,1,1)),0,h,20,1);
			}
			
			picColourStrip.Image = newImage;
		}
		
		private void UpdateColourDisplays() {
			// startColor
			Bitmap startImage = new Bitmap(135,24);
			Graphics startGFX = Graphics.FromImage(startImage);
			startGFX.FillRectangle(new SolidBrush(_startColor.ToColor()),0,0,135,24);
			picStartColour.Image = startImage;
			
			// currentColor
			Bitmap currentImage = new Bitmap(135,24);
			Graphics currentGFX = Graphics.FromImage(currentImage);
			currentGFX.FillRectangle(new SolidBrush(_currentColor.ToColor()),0,0,135,24);
			picCurrentColour.Image = currentImage;
		}
		
		private void UpdateColourInputs(bool updateNums) {
			Color displayColor = _currentColor.ToColor();
			
			if (updateNums) {
				numR.Value = displayColor.R;
				numG.Value = displayColor.G;
				numB.Value = displayColor.B;
			}
			
			string R = ((int)numR.Value).ToString("X").PadLeft(2,'0');
			string G = ((int)numG.Value).ToString("X").PadLeft(2,'0');
			string B = ((int)numB.Value).ToString("X").PadLeft(2,'0');
			
			txtRGB.Text = string.Format("#{0}{1}{2}",R,G,B);
		}
		#endregion
		
		#region Value changes
		void NumRValueChanged(object sender, EventArgs e)
		{
			if (_updating) {
				return;
			}
			
			_currentColor = SIMPRGB.RGBtoHSV((double)numR.Value,(double)numG.Value,(double)numB.Value);
			
			Update(false);
		}
		
		void NumGValueChanged(object sender, EventArgs e)
		{
			if (_updating) {
				return;
			}
			
			_currentColor = SIMPRGB.RGBtoHSV((double)numR.Value,(double)numG.Value,(double)numB.Value);
			
			Update(false);
		}
		
		void NumBValueChanged(object sender, EventArgs e)
		{
			if (_updating) {
				return;
			}
			
			_currentColor = SIMPRGB.RGBtoHSV((double)numR.Value,(double)numG.Value,(double)numB.Value);
			
			Update(false);
		}
		
		void PicColourStripClick(object sender, EventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			
			float hue = ((float)me.Location.Y)*3.6f;
			_currentColor.H = hue;
			
			Update(true);
		}
		
		void PicColourSquareClick(object sender, EventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			
			_currentColor.S = ((float)me.Location.X)/100;
			_currentColor.V = 1-((float)me.Location.Y)/100;
			
			Update(true);
		}
		
		void PicColourSquareMouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.None) {
				Point newPoint = e.Location;
				if (e.Location.X < 0) {
					newPoint = new Point(0,e.Location.Y);
				}
				if (e.Location.X >= picColourSquare.Width) {
					newPoint = new Point(picColourSquare.Width,e.Location.Y);
				}
				if (e.Location.Y < 0) {
					newPoint = new Point(newPoint.X,0);
				}
				if (e.Location.Y >= picColourSquare.Height) {
					newPoint = new Point(newPoint.X,picColourSquare.Height);
				}
				PicColourSquareClick(sender,new MouseEventArgs(e.Button,e.Clicks,newPoint.X,newPoint.Y,e.Delta));
			}
		}
		
		void PicColourStripMouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.None) {
				Point newPoint = e.Location;
				if (e.Location.X < 0) {
					newPoint = new Point(0,e.Location.Y);
				}
				if (e.Location.X >= picColourStrip.Width) {
					newPoint = new Point(picColourStrip.Width,e.Location.Y);
				}
				if (e.Location.Y < 0) {
					newPoint = new Point(newPoint.X,0);
				}
				if (e.Location.Y >= picColourStrip.Height) {
					newPoint = new Point(newPoint.X,picColourStrip.Height);
				}
				PicColourStripClick(sender,new MouseEventArgs(e.Button,e.Clicks,newPoint.X,newPoint.Y,e.Delta));
			}
		}
		#endregion
		
		void BtnSaveClick(object sender, EventArgs e)
		{
			// calls the callback to be handled by caller
			_updateCallback(_currentColor.ToColor());
			
			Close();
		}
		
		void BtnCloseClick(object sender, EventArgs e)
		{
			Close();
		}
	}
	
	public delegate void ColorCallback(Color newColour);
	
	static class SIMPRGB {
		public static Color cachedColor;
		
		public static Color HSVtoRGB(double h, double s, double v) {
			double c = s * v;
			double x = c * (1-Math.Abs(((h/60)%2)-1));
			double m = v - c;
//			double c = (1 - Math.Abs((2*l)-1)) * s;
//			double x = c * (1-Math.Abs(((h/60)%2)-1));
//			double m = l-(c/2);
			double r,g,b;
			if (h < 60) {
				r = c; g = x; b = 0;
			}
			else if (h >= 60 && h < 120) {
				r = x; g = c; b = 0;
			}
			else if (h >= 120 && h < 180) {
				r = 0; g = c; b = x;
			}
			else if (h >= 180 && h < 240) {
				r = 0; g = x; b = c;
			}
			else if (h >= 240 && h < 300) {
				r = x; g = 0; b = c;
			}
			else {
				r = c; g = 0; b = x;
			}
			int R = (int)((r+m) * 255);
			int G = (int)((g+m) * 255);
			int B = (int)((b+m) * 255);
			
			//try {
				return Color.FromArgb(R,G,B);
//			}
//			catch (Exception) {
//				MessageBox.Show("SIMP Error!\n\nInvalid Colour\n\nColour details: " + cachedColor.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
//				return Color.Black;
//			}
		}
		
		public static HSVColor RGBtoHSV(Color c) {
			return RGBtoHSV((double)c.R,(double)c.G,(double)c.B);
		}
		
		public static HSVColor RGBtoHSV(double r, double g, double b) {
			double R = r/255;
			double G = g/255;
			double B = b/255;
			
			double Cmax = Max(R,G,B);
			double Cmin = Min(R,G,B);
			
			double Δ = Cmax - Cmin;
			
			double h,s,v;
			h = 0;
			if (Δ == 0) {
				h = 0;
			} else if (Cmax == R) {
				h = 60 * (((G-B)/Δ)%6);
			} else if (Cmax == G) {
				h = 60 * (((B-R)/Δ)+2);
			} else if (Cmax == B) {
				h = 60 * (((R-G)/Δ)+4);
			}
			if (h<0) {
				h += 360;
			}
			
			if (Cmax == 0) {
				s = 0;
			} else {
				s = Δ/Cmax;
			}
			
			v = Cmax;
			
			return new HSVColor(h,s,v);
		}
		
		private static double Max(params double[] nums) {
			double max = nums[0];
			
			for (int i = 1; i < nums.Length; i++) {
				if (nums[i] > max) {
					max = nums[i];
				}
			}
			
			return max;
		}
		
		private static double Min(params double[] nums) {
			double min = nums[0];
			
			for (int i = 1; i < nums.Length; i++) {
				if (nums[i] < min) {
					min = nums[i];
				}
			}
			
			return min;
		}
		
		public static Color SetHue(this Color color, float hue) {
			return HSVtoRGB(hue,color.GetSaturation(),color.GetBrightness());
		}
		
		public static Color SetSaturation(this Color color, float saturation) {
			return HSVtoRGB(color.GetHue(),saturation,color.GetBrightness());
		}
		
		public static Color SetLightness(this Color color, float lightness) {
			return HSVtoRGB(color.GetHue(),color.GetSaturation(),lightness);
		}
	}
	
	struct HSVColor {
		public double H;
		public double S;
		public double V;
		
		public HSVColor(double H, double S, double V) {
			this.H = H; this.S = S; this.V = V;
		}
		
		public Color ToColor() {
			return SIMPRGB.HSVtoRGB(H,S,V);
		}
		
		public override string ToString()
		{
			return string.Format("[HSVColor H={0}, S={1}, V={2}]", H, S, V);
		}

	}
}


//			double c = s * l;
//			double x = c * (1-Math.Abs(((h/60)%2)-1));
//			double m = l - c;
