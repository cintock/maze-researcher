/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Drawing;

namespace tests
{
	/// <summary>
	/// Description of IMazeDrawer.
	/// </summary>
	public interface IMazeDrawer
	{
		IMaze MazeObj { get; set; }
		MazeSolution Solution { get; set; }
		
		Bitmap Draw();
	}
}
