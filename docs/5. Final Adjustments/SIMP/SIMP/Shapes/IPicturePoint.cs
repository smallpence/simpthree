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
	/// A generic point on the image
	/// </summary>
	public interface IPicturePoint
	{
		FilePoint ToFilePoint();
		DisplayPoint ToDisplayPoint();
	}
}
