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
		
		public IMazeData Generate(int row, int col)
		{
			IMazeData maze = new MazeData(row, col);
			return maze;
		}
	}
}
