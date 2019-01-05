/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace tests
{
	/// <summary>
	/// Description of RandomMazeGenerator.
	/// </summary>
	public class RandomMazeGenerator : IMazeGenerator
	{
		public RandomMazeGenerator()
		{
		}
		
		public IMaze Generate(Int32 row, Int32 col)
		{
			Maze maze = new Maze(row, col);
			Random rnd = new Random();
			for (Int32 i = 0; i < row; i++)
			{
				for (Int32 j = 0; j < col; j++)
				{
					if (rnd.Next() % 2 == 0)
					{
						maze.SetCell(i, j, MazeSide.Right);
					}
					if (rnd.Next() % 2 == 0)
					{
						maze.SetCell(i, j, maze.GetCell(i, j) | MazeSide.Bottom);
					}
				}
			}
			return maze;
		}
	}
}
