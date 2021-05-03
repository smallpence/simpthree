/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 20/09/2019
 * Time: 12:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SIMP {
	public static class SimpConstants {
		public static int IMAGE_MAX_WIDTH = 99999;
		public static int IMAGE_MAX_HEIGHT = 99999;
		
		public static int IMAGE_DEFAULT_WIDTH = 50;
		public static int IMAGE_DEFAULT_HEIGHT = 50;
		
		public static int WINDOWS_TOP_BAR_HEIGHT;
		public static int WINDOWS_BOTTOM_BAR_HEIGHT;
		public static int WINDOWS_LEFT_BAR_WIDTH;
		public static int WINDOWS_RIGHT_BAR_WIDTH;
		
		public static int WORKSPACE_LEFT_PADDING = 24;
		public static int WORKSPACE_TOP_PADDING = 0;
		public static int WORKSPACE_RIGHT_PADDING = 220;
		public static int WORKSPACE_BOTTOM_PADDING = 40;
		
		public static int WORKSPACE_REFRESH_PERIOD = 10;
		
		public static int PROPERTY_LABEL_HEIGHT = 15;
		public static int PROPERTY_GAP_HEIGHT = 0;
		public static int PROPERTY_FIELD_HEIGHT = 23;
		public static int PROPERTY_SPACER_HEIGHT = 10;
		public static int PROPERTY_HEIGHT;
		
		/// <summary>
		/// Called when SimpConstants is first used, sets up the bar height constants
		/// </summary>
		static SimpConstants() {
			// defines a test form
			Form testForm = new Form();
			
			// determines where the display rectangle appears on the screen
			Rectangle screenRectangle = testForm.RectangleToScreen(testForm.ClientRectangle);
			
			// determines the bar sizes by comparing that rectangle to the actual location of the form
			WINDOWS_TOP_BAR_HEIGHT = screenRectangle.Top - testForm.Top;
			WINDOWS_BOTTOM_BAR_HEIGHT = screenRectangle.Bottom - testForm.Bottom;
			WINDOWS_LEFT_BAR_WIDTH = screenRectangle.Left - testForm.Left;
			WINDOWS_RIGHT_BAR_WIDTH = screenRectangle.Right - testForm.Right;
			
			PROPERTY_HEIGHT = PROPERTY_LABEL_HEIGHT + PROPERTY_GAP_HEIGHT + PROPERTY_FIELD_HEIGHT + PROPERTY_SPACER_HEIGHT;
		}
	}
}