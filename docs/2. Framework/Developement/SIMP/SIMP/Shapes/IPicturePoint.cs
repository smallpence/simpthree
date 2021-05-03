/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 25/09/2019
 * Time: 11:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SIMP
{
	/// <summary>
	/// An interface for a point on the file or display
	/// </summary>
	public interface IPicturePoint
	{
		FilePoint ToFilePoint();
		DisplayPoint ToDisplayPoint();
	}
}
