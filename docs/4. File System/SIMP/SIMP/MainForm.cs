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
		
		public MainForm()
		{
			InitializeComponent();
			
			numWidth.Maximum = SimpConstants.IMAGE_MAX_WIDTH;
			numWidth.Value = (decimal)SimpConstants.IMAGE_DEFAULT_WIDTH;
			
			numHeight.Maximum = SimpConstants.IMAGE_MAX_HEIGHT;
			numHeight.Value = (decimal)SimpConstants.IMAGE_DEFAULT_HEIGHT;
		}
		
		void BtnCreateClick(object sender, EventArgs e)
		{
			Form newForm = new Workspace((int)numWidth.Value,(int)numHeight.Value);
			newForm.Show();
		}
		
		void BtnOpenClick(object sender, EventArgs e)
		{
			DialogResult result = diaOpen.ShowDialog();
			if (result == DialogResult.OK) {
				using (FileStream stream = new FileStream(diaOpen.FileName,FileMode.Open)) {
					Workspace newWorkspace = Workspace.OpenFile(stream);
					
					newWorkspace.MarkSavedTo(diaOpen.SafeFileName,diaOpen.FileName);
				}
			}
		}
		
		void BtnImportClick(object sender, EventArgs e)
		{
			DialogResult result = diaImport.ShowDialog();
			if (result == DialogResult.OK) {
				Bitmap fileImage = new Bitmap(diaImport.FileName);
				Workspace newForm = new Workspace(fileImage.Width,fileImage.Height);
				
				PixelAction action = new PixelAction();
				for (int x = 0; x < fileImage.Width; x++) {
					for (int y = 0; y < fileImage.Height; y++) {
						action.AddPixel(new FilePoint(x,y),Color.White,fileImage.GetPixel(x,y));
					}
				}
				
				newForm.PerformActionSilent(action);
				
				newForm.Show();
			}
		}
	}
}
