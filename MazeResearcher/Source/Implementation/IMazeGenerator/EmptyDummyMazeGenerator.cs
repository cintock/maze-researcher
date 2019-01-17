/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace Maze.Implementation
{
	/// <summary>
	/// Description of EmptyDummyMazeGenerator.
	/// </summary>
	public class EmptyDummyMazeGenerator : IMazeGenerator
	{
		public EmptyDummyMazeGenerator()
		{
		}
		
		public IMazeData Generate(int row, int col)
		{
			IMazeData maze = new EmptyMazeData(row, col);
			return maze;
		}
	}
}
