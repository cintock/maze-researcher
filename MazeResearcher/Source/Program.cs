/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Windows.Forms;


namespace Maze.UI
{
    /// <summary>
    /// Class with program entry point.
    /// </summary>
    internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new AppForm());
		}
		
	}
}
