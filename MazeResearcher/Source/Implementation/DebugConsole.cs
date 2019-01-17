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
	public delegate void DebugMessageCallbackDelegate(string message);
	
	/// <summary>
	/// Синглтон для выполнения отладочного логирования
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
		
		public void Log(string message)
		{
            debugOutput?.Invoke(message + Environment.NewLine);
        }
		
		public void LogNumLine(string name, int[] val)
		{
			Log(string.Format("{0,15}: {1,30}", name, string.Join(" ", val)));
		}
	}
}
