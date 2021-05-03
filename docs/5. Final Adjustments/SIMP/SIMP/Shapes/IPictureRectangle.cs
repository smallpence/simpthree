/*
 * Created by SharpDevelop.
 * User: 13SYoung
 * Date: 25/09/2019
 * Time: 21:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SIMP
{
	/// <summary>
	/// A generic rectangle made of points
	/// </summary>
	public interface IPictureRectangle
	{
		FileRectangle ToFileRectangle();
		DisplayRectangle ToDisplayRectangle();
	}
}
