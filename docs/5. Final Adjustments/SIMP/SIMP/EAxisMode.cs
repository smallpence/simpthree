/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 27/09/2019
 * Time: 15:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SIMP
{
	/// <summary>
	/// The state of the image in relation to an axis
	/// e.g. ImageTooLarge means the image size in that axis is larger than the amount of space to display it in,
	/// thus must be trimmed
	/// </summary>
	public enum EAxisMode
	{
		ImageTooLarge,
		ImageTooSmall
	}
}
