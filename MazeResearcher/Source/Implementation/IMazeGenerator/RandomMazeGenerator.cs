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
			for (int r = 0; r < row; r++)
			{
				for (int c = 0; c < col; c++)
				{
					if (rnd.Next() % 2 == 0)
					{
                        maze.AddSides(r, c, MazeSide.Right);
					}
					if (rnd.Next() % 2 == 0)
					{
                        maze.AddSides(r, c, MazeSide.Bottom);
					}
				}
			}
			return maze;
		}
	}
}
