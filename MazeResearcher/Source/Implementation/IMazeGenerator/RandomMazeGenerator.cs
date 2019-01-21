/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace Maze.Implementation
{
	/// <summary>
	/// Класс для создания полностью случайного лабиринта
	/// </summary>
	public class RandomMazeGenerator : IMazeGenerator
	{
        Random randomValues = new Random();

        public RandomMazeGenerator()
		{
		}
        
        private bool RandomBool()
        {
            return (randomValues.Next() % 2 == 0);
        }

		public IMazeView Generate(int row, int col)
		{
            MazeData maze = new MazeData(row, col);
			
			for (int r = 0; r < row; r++)
			{
				for (int c = 0; c < col; c++)
				{
					if (RandomBool())
					{
                        maze.AddSides(r, c, MazeSide.Right);
					}
					if (RandomBool())
					{
                        maze.AddSides(r, c, MazeSide.Bottom);
					}
				}
			}
			return maze;
		}
	}
}
