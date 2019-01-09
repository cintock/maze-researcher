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
	public class MazeClusterer : IMazeClusterer
	{
		private MazeClusters clusters;
		private IMazeData workMaze;
		private Int32 rowCount;
		private Int32 colCount;
		private List<PathPoint> path; 
		
		public MazeClusterer()
		{
		}
		
		public MazeClusters Cluster(IMazeData maze)
		{
			workMaze = maze;
			rowCount = maze.RowCount;
			colCount = maze.ColCount;
			clusters = new MazeClusters(workMaze);
			path = new List<PathPoint>();
			Int32 nextRow = 0;
			Int32 nextCol = 0;
			Int32 clusterIndex = 1;
			Boolean allClustered = false;
			while (!allClustered)
			{
				GoCell(nextRow, nextCol, clusterIndex++);
				allClustered = true;
				for (Int32 row = 0; row < rowCount; row++)
				{
					for (Int32 col = 0; col < colCount; col++)
					{
						if (clusters.IsNonclustered(row, col))
						{
							allClustered = false;
							nextRow = row;
							nextCol = col;
							break;
						}
					}
					if (!allClustered)
					{
						break;
					}
				}
			}
			return clusters;
		}
		
		protected IList<PathPoint> GetPath()
		{
			return path;
		}
		
		Boolean IsCellExists(Int32 row, Int32 col)
		{
			return ((row >= 0) && (row < rowCount) && (col >= 0) && (col < colCount));
		}
		
		void GoCell(Int32 row, Int32 col, Int32 cluster)
		{
			if (IsCellExists(row, col))
			{
				path.Add(new PathPoint(row, col));
				if (clusters.IsNonclustered(row, col))
				{
					MazeSide currentCell = workMaze.GetCell(row, col);
					clusters.SetClusterIndex(row, col, cluster);
					
					if (IsCellExists(row - 1, col))
					{
						if (!currentCell.HasFlag(MazeSide.Top))
						{
							GoCell(row - 1, col, cluster);
						}
					}
					
					if (IsCellExists(row + 1, col))
					{
						if (!currentCell.HasFlag(MazeSide.Bottom))
						{
							GoCell(row + 1, col, cluster);
						}
					}					
					
					if (IsCellExists(row, col - 1))
					{
						if (!currentCell.HasFlag(MazeSide.Left))
						{
							GoCell(row, col - 1, cluster);
						}
					}		

					if (IsCellExists(row, col + 1))
					{
						if (!currentCell.HasFlag(MazeSide.Right))
						{
							GoCell(row, col + 1, cluster);
						}
					}						
				}
			}
		}
	}
}
