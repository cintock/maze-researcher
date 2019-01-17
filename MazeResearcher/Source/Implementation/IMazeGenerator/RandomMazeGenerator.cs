/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace Maze.Implementation
{
	/// <summary>
	/// Description of RandomMazeGenerator.
	/// </summary>
	public class RandomMazeGenerator : IMazeGenerator
	{
		public RandomMazeGenerator()
		{
		}
		
		public IMazeData Generate(int row, int col)
		{
			MazeData maze = new MazeData(row, col);
			Random rnd = new Random();
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < col; j++)
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
