/*
 * Created by SharpDevelop.
 * User: 13syoung
 * Date: 20/09/2019
 * Time: 12:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
 using System;
 using System.Reflection;

/// <summary>
/// The master exception for all errors SIMP Related
/// </summary>
public class SimpException : System.Exception {
	
	[Obsolete]
	public SimpException(string message) : base(message) {
		
	}
}