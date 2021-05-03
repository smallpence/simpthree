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

namespace SIMP
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
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
	}
}
