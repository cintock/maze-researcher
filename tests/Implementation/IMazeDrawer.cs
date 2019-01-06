/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Drawing;

namespace Maze.Implementation
{
	/// <summary>
	/// Description of IMazeDrawer.
	/// </summary>
	public interface IMazeDrawer
	{
		Bitmap Draw(IMazeData maze, MazeSolution solution = null);
	}
}
