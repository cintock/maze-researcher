/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace tests
{
	/// <summary>
	/// Description of MazeSolver.
	/// </summary>
	public class MazeSolver
	{
		public IMaze MazeObj { 
			get 
			{
				return maze;
			}
			set 
			{
				maze = value;
			}
		}
		
		private IMaze maze;
		private MazeSolution solution;
		
		public MazeSolver()
		{
		}
		
		public MazeSolution Solve()
		{
			Int32 row = 0;
			Int32 col = 0;
			solution = new MazeSolution();
			solution.InitSizeFromMaze(maze);
			CheckCell(row, col);
			return solution;
		}
		
		void CheckCell(Int32 row, Int32 col)
		{
			if (maze.IsCellExists(row, col))
			{
				
				if (!solution.IsChecked(row, col))
				{
					MazeCell currentCell = maze.GetCell(row, col);
					solution.SetChecked(row, col);
					
					if (maze.IsCellExists(row - 1, col))
					{
						if ((currentCell & MazeCell.Top) == MazeCell.None)
						{
							CheckCell(row - 1, col);
						}
					}
					
					if (maze.IsCellExists(row + 1, col))
					{
						if ((currentCell & MazeCell.Bottom) == MazeCell.None)
						{
							CheckCell(row + 1, col);
						}
					}					
					
					if (maze.IsCellExists(row, col - 1))
					{
						if ((currentCell & MazeCell.Left) == MazeCell.None)
						{
							CheckCell(row, col - 1);
						}
					}		

					if (maze.IsCellExists(row, col + 1))
					{
						if ((currentCell & MazeCell.Right) == MazeCell.None)
						{
							CheckCell(row, col + 1);
						}
					}						
				}
			}
		}
	}
}
