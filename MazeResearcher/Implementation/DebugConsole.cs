/*
 * Author: cintock
 * Date: 08.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace Maze.Implementation
{
	public delegate void DebugMessageCallbackDelegate(String message);
	
	/// <summary>
	/// Description of DebugConsole.
	/// </summary>
	public class DebugConsole
	{
		private static DebugConsole console = null;
		
		private DebugMessageCallbackDelegate debugOutput;
		
		private DebugConsole()
		{
		}
		
		public static DebugConsole Instance()
		{
			if (console == null)
			{
				console = new DebugConsole();
			}
			
			return console;			
		}
		
		public void SetDebugCallback(DebugMessageCallbackDelegate output)
		{
			debugOutput = output;
		}
		
		public void Log(String message)
		{
			if (debugOutput != null)
			{
				debugOutput(message + Environment.NewLine);
			}
		}
		
		public void LogNumLine(String name, Int32[] val)
		{
			Log(String.Format("{0,15}: {1,50}", name, String.Join(" ", val)));
		}
	}
}
