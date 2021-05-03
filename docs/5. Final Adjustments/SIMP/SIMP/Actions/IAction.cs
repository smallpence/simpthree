/*
 * Created by SharpDevelop.
 * User: 13SYoung
 * Date: 05/11/2019
 * Time: 17:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SIMP.Actions
{
	/// <summary>
	/// An action to be done (and undone) by the program
	/// </summary>
	public interface IAction
	{
		void Do(Workspace workspace); // Perform the action on this workspace
		void Undo(Workspace workspace);
	}
}
