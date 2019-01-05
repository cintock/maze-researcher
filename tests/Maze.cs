/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace tests
{

	
	/// <summary>
	/// Description of Maze.
	/// </summary>
	public class Maze : IMaze
	{
		MazeCell[,] mazeMatrix;
		
		public Int32 rowCount { get; private set; }
		public Int32 colCount { get; private set; }
		
		public Maze(Int32 row, Int32 col)
		{
			CheckDimensions(row, col);
			rowCount = row;
			colCount = col;
			mazeMatrix = new MazeCell[rowCount, colCount];
		}

		
		public Boolean IsCellExists(Int32 row, Int32 col)
		{
			return ((row >= 0) && (row < rowCount) && (col >= 0) && (col < colCount));
		}
		
		private static void CheckDimensions(Int32 row, Int32 col)
		{
			if (!((row > 0) && (col > 0)))
			{
				throw new IndexOutOfRangeException("Некорректная размерность лабиринта");
			}			
		}	
		
		private void CheckCellExists(Int32 row, Int32 col)
		{
			if (!IsCellExists(row, col))
			{
				throw new IndexOutOfRangeException("Ячейка лабиринта не существует");
			}
		}
				
		public MazeCell GetCell(Int32 row, Int32 col)
		{
			CheckCellExists(row, col);
			MazeCell resultCell = mazeMatrix[row, col];
			if (row > 0)
			{
				if ((mazeMatrix[row - 1, col] & MazeCell.Bottom) != MazeCell.None)
				{
					resultCell |= MazeCell.Top;
				}
			}
			else
			{
				resultCell |= MazeCell.Top;
			}
			
			if (row == rowCount - 1)
			{
				resultCell |= MazeCell.Bottom;
			}
			
			if (col > 0)
			{
				if ((mazeMatrix[row, col - 1] & MazeCell.Right) != MazeCell.None)
				{
					resultCell |= MazeCell.Left;
				}
			}
			else
			{
				resultCell |= MazeCell.Left;
			}
			
			if (col == colCount - 1)
			{
				resultCell |= MazeCell.Right;
			}
			
			return resultCell;
		}
		
		public void SetCell(Int32 row, Int32 col, MazeCell cell)
		{
			CheckCellExists(row, col);
			mazeMatrix[row, col] = cell;
		}
		
	}
}
