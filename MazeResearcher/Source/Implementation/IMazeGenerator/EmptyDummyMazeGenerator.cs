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
		
		public IMazeData Generate(Int32 row, Int32 col)
		{
			IMazeData maze = new EmptyMazeData(row, col);
			return maze;
		}
	}
}
