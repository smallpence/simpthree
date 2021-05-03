/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 19/09/2019
 * Time: 12:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Data.SqlClient;

namespace SIMP
{
	/// <summary>
	/// Description of ZoomSetting.
	/// </summary>
	public struct ZoomSettings
	{
		public int zoom;
		public FilePoint fileCentreLocation;
		public DisplayPoint displayCentreLocation;
		
		public ZoomSettings(FilePoint centreLocation) {
			this.zoom = 1;
			this.fileCentreLocation = centreLocation;
			this.displayCentreLocation = null;
		}
		
		public void CalcDisplayCentreLocation(int width, int height) {
			int newX = width/2;
			int newY = height/2;
			SqlConnection cnn = new SqlConnection(
			displayCentreLocation = new DisplayPoint(newX,newY);
		}
	}
}