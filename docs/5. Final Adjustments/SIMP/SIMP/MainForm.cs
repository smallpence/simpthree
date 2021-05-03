/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 18/09/2019
 * Time: 15:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using SIMP.Actions;

namespace SIMP
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public Color testColor;
		public Color testColor2;
		
		public MainForm(string openFileName)
		{
			InitializeComponent();
			
			// populates numeric boxes with the needed constants
			numWidth.Maximum = SimpConstants.IMAGE_MAX_WIDTH;
			numWidth.Value = (decimal)SimpConstants.IMAGE_DEFAULT_WIDTH;
			
			numHeight.Maximum = SimpConstants.IMAGE_MAX_HEIGHT;
			numHeight.Value = (decimal)SimpConstants.IMAGE_DEFAULT_HEIGHT;
			
			if (!string.IsNullOrEmpty(openFileName)) {
				diaOpen.FileName = openFileName;
				openFile();
			}
		}
		
		void BtnCreateClick(object sender, EventArgs e)
		{
			Form newForm = new Workspace((int)numWidth.Value,(int)numHeight.Value);
			newForm.Show();
		}
		
		void BtnOpenClick(object sender, EventArgs e)
		{
			// prompts the user for location of file to open
			DialogResult result = diaOpen.ShowDialog();
			if (result == DialogResult.OK) { // if they pressed ok and not cancel or close
				openFile();
			}
		}
		
		void openFile() {
			using (FileStream stream = new FileStream(diaOpen.FileName,FileMode.Open)) {
				Workspace newWorkspace = Workspace.OpenFile(stream);
				if (newWorkspace != null) {
					newWorkspace.MarkSavedTo(diaOpen.SafeFileName,diaOpen.FileName);
				}
			}
		}
		
		void BtnImportClick(object sender, EventArgs e)
		{
			DialogResult result = diaImport.ShowDialog();
			if (result == DialogResult.OK) {
				// creates a bitmap from that file location
				Bitmap fileImage = new Bitmap(diaImport.FileName);
				// if the area of the image is larger than the area of allowed maximums
				if (fileImage.Width * fileImage.Height > SimpConstants.IMAGE_MAX_WIDTH * SimpConstants.IMAGE_MAX_HEIGHT
				    // or if one of the dimensions is too large
				   || fileImage.Width > SimpConstants.IMAGE_MAX_WIDTH
				   || fileImage.Height > SimpConstants.IMAGE_MAX_HEIGHT
				  ) {
					MessageBox.Show("Image was too large to be imported!","Image Size Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
				
				Workspace newForm = new Workspace(fileImage.Width,fileImage.Height);
				
				// creates an action that prints the opened image onto the internal image
				PixelAction action = new PixelAction();
				for (int x = 0; x < fileImage.Width; x++) {
					for (int y = 0; y < fileImage.Height; y++) {
						action.AddPixel(new FilePoint(x,y),Color.White,fileImage.GetPixel(x,y));
					}
				}
				
				// performs it silently so you cant undo
				newForm.PerformActionSilent(action);
				
				newForm.Show();
			}
		}
	}
}
