/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace Maze.Implementation
{
	/// <summary>
	/// Description of EmptyMazeGenerator.
	/// </summary>
	public class EmptyMazeGenerator : IMazeGenerator
	{
		public EmptyMazeGenerator()
		{
		}
		
		public IMaze Generate(Int32 row, Int32 col)
		{
			IMaze maze = new Maze(row, col);
			return maze;
		}
	}
}
