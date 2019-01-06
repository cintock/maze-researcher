/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Collections.Generic;

namespace Maze.Implementation
{
	public struct PathPoint
	{
		public PathPoint(Int32 r, Int32 c)
		{
			Row = r;
			Col = c;
		}
		
		public readonly Int32 Row;
		public readonly Int32 Col;
	}
	
	/// <summary>
	/// Description of MazeSolver.
	/// </summary>
	public class MazeSolver : IMazeSolver
	{
		private MazeSolution solution;
		private IMazeData workMaze;
		private Int32 rowCount;
		private Int32 colCount;
		private List<PathPoint> path; 
		
		public MazeSolver()
		{
		}
		
		public MazeSolution Solve(IMazeData maze)
		{
			workMaze = maze;
			rowCount = maze.rowCount;
			colCount = maze.colCount;
			solution = new MazeSolution(workMaze);
			path = new List<PathPoint>();
			GoCell(0, 0);
			return solution;
		}
		
		protected IList<PathPoint> GetPath()
		{
			return path;
		}
		
		Boolean IsCellExists(Int32 row, Int32 col)
		{
			return ((row >= 0) && (row < rowCount) && (col >= 0) && (col < colCount));
		}
		
		void GoCell(Int32 row, Int32 col)
		{
			if (IsCellExists(row, col))
			{
				path.Add(new PathPoint(row, col));
				if (!solution.IsChecked(row, col))
				{
					MazeSide currentCell = workMaze.GetCell(row, col);
					solution.SetChecked(row, col);
					
					if (IsCellExists(row - 1, col))
					{
						if (!currentCell.HasFlag(MazeSide.Top))
						{
							GoCell(row - 1, col);
						}
					}
					
					if (IsCellExists(row + 1, col))
					{
						if (!currentCell.HasFlag(MazeSide.Bottom))
						{
							GoCell(row + 1, col);
						}
					}					
					
					if (IsCellExists(row, col - 1))
					{
						if (!currentCell.HasFlag(MazeSide.Left))
						{
							GoCell(row, col - 1);
						}
					}		

					if (IsCellExists(row, col + 1))
					{
						if (!currentCell.HasFlag(MazeSide.Right))
						{
							GoCell(row, col + 1);
						}
					}						
				}
			}
		}
	}
}
