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
		private static List<Color> previousColors;
		
		static RGBPicker() {
			previousColors = new List<Color>();
		}
		
		public RGBPicker(Color startColor, ColorCallback updateCallback)
		{
			InitializeComponent();
			
			// makes it so there is only one RGBPicker open at once
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
		/// <summary>
		/// Updates all the displays
		/// For when a value has been changed
		/// </summary>
		/// <param name="updateNums">Whether to update the number boxes or not</param>
		private void Update(bool updateNums) {
			_updating = true;
			
			UpdateColourSquare();
			UpdateColourIndicator();
			UpdateColourStrip();
			UpdateColourDisplays();
			UpdateColourInputs(updateNums);
			UpdatePreviousColours();
			
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
					// divide by 100 as the S and V need to between 0 and 1
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
			
			// if V (1-Y) is greater than 0.5 (at lower part of image) make indicator black
			Color indicatorColor = (_currentColor.V > 0.5) ? Color.Black : Color.White;
			GFX.FillRectangle(new SolidBrush(indicatorColor),(int)(_currentColor.S*100),0,1,100);
			GFX.FillRectangle(new SolidBrush(indicatorColor),0,(int)((1-_currentColor.V)*100),100,1);
			
			picColourSquare.Image = editImage;
		}
		
		private void UpdateColourStrip() {
			Bitmap newImage = new Bitmap(20,100);
			Graphics GFX = Graphics.FromImage(newImage);
			
			for (float h = 0; h < 100; h++) {
				// h*3.6 as H needs to be between 0-360, and h is between 0-100
				GFX.FillRectangle(new SolidBrush(SIMPRGB.HSVtoRGB(h*3.6,1,1)),0,h,20,1);
			}
			
			picColourStrip.Image = newImage;
		}
		
		/// <summary>
		/// Color Displays are the two boxes telling you your current and previous colour
		/// </summary>
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
				// its not always wanted to update the number boxes
				// if the number box was just changed, then they may twitch back
				// due to the fact that the R from the number box is converted to HSV notation, then BACK to RGB
				// so some information is lost - leading to innacuracies
				numR.Value = displayColor.R;
				numG.Value = displayColor.G;
				numB.Value = displayColor.B;
			}
			
			string R = ((int)numR.Value).ToString("X").PadLeft(2,'0');
			string G = ((int)numG.Value).ToString("X").PadLeft(2,'0');
			string B = ((int)numB.Value).ToString("X").PadLeft(2,'0');
			
			txtRGB.Text = string.Format("#{0}{1}{2}",R,G,B);
		}
		
		private void UpdatePreviousColours() {
			Bitmap newImage = new Bitmap(47,290);
			Graphics GFX = Graphics.FromImage(newImage);
			GFX.Clear(SystemColors.ControlDark);
			int currentY = 0;
			// traverse through the list and fill boxes
			foreach (Color color in previousColors) {
				GFX.FillRectangle(new SolidBrush(color),0,currentY,47,20);
				currentY+=30;
			}
			picRecentColours.Image = newImage;
		}
		#endregion
		
		#region Value changes
		void NumRValueChanged(object sender, EventArgs e)
		{
			if (_updating) {
				return;
			}
			
			_currentColor = SIMPRGB.RGBtoHSV((double)numR.Value,(double)numG.Value,(double)numB.Value);
			
			// DONT update the number boxes
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
		
		void PicColourSquareClick(object sender, EventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			
			_currentColor.S = ((float)me.Location.X)/100;
			_currentColor.V = 1-((float)me.Location.Y)/100;
			
			Update(true);
		}
		
		void PicColourStripClick(object sender, EventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			
			// change the hue and update everything
			float hue = ((float)me.Location.Y)*3.6f;
			_currentColor.H = hue;
			
			Update(true);
		}
		
		void PicColourSquareMouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.None) {
				Point newPoint = e.Location;
				// binds the click location into the box
				// this is so if you move the mouse outside the box the selector still 'follows' it
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
				// just calls the click function - saves repeating code
				PicColourSquareClick(sender,new MouseEventArgs(e.Button,e.Clicks,newPoint.X,newPoint.Y,e.Delta));
			}
		}
		
		void PicColourStripMouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.None) {
				// same reasoining as PicColorSquareMouseMove
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
			AddPreviousColor(_currentColor.ToColor());
			
			Close();
		}
		
		void BtnCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		
		#region previouscolors
		void AddPreviousColor(Color color) {
			previousColors.Insert(0,color);
			
			if (previousColors.Count > 10) {
				previousColors.RemoveAt(10); // dequeue color at end and throw it away
			}
		}
		
		void PicRecentColoursClick(object sender, EventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			int colorY = me.Y/30;
			if (me.Y%30 < 20) {
				if (previousColors.Count > colorY) {
					_currentColor = SIMPRGB.RGBtoHSV(previousColors[colorY]);
					Update(true);
				}
			}
		}
		#endregion
	}
	
	public delegate void ColorCallback(Color newColour);
	
	static class SIMPRGB {
		public static Color cachedColor;
		
		/// <summary>
		/// Converts a HSV colour to its RGB equivalent
		/// </summary>
		public static Color HSVtoRGB(double h, double s, double v) {
			// see documentation for the details of algorithm used
			double c = s * v;
			double x = c * (1-Math.Abs(((h/60)%2)-1));
			double m = v - c;
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
			
			return Color.FromArgb(R,G,B);
		}
		
		// allows you to call RGBtoHSV with either a colour or three numbers
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
		
		/// <summary>
		/// finds the largest number out of a list
		/// </summary>
		private static double Max(params double[] nums) {
			double max = nums[0];
			
			for (int i = 1; i < nums.Length; i++) {
				if (nums[i] > max) {
					max = nums[i];
				}
			}
			
			return max;
		}
		
		/// <summary>
		/// finds the smallest number out of a list
		/// </summary>
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
	
	/// <summary>
	/// Structure similar to the Color struct which stores info about an HSV colour
	/// </summary>
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
