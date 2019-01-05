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
		MazeSide[,] mazeMatrix;
		
		public Int32 rowCount { get; private set; }
		public Int32 colCount { get; private set; }
		
		public Maze(Int32 row, Int32 col)
		{
			CheckDimensions(row, col);
			rowCount = row;
			colCount = col;
			mazeMatrix = new MazeSide[rowCount, colCount];
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
				
		public MazeSide GetCell(Int32 row, Int32 col)
		{
			CheckCellExists(row, col);
			MazeSide resultCell = mazeMatrix[row, col];
			if (row > 0)
			{
				if ((mazeMatrix[row - 1, col] & MazeSide.Bottom) != MazeSide.None)
				{
					resultCell |= MazeSide.Top;
				}
			}
			else
			{
				resultCell |= MazeSide.Top;
			}
			
			if (row == rowCount - 1)
			{
				resultCell |= MazeSide.Bottom;
			}
			
			if (col > 0)
			{
				if ((mazeMatrix[row, col - 1] & MazeSide.Right) != MazeSide.None)
				{
					resultCell |= MazeSide.Left;
				}
			}
			else
			{
				resultCell |= MazeSide.Left;
			}
			
			if (col == colCount - 1)
			{
				resultCell |= MazeSide.Right;
			}
			
			return resultCell;
		}
		
		public void SetCell(Int32 row, Int32 col, MazeSide cell)
		{
			CheckCellExists(row, col);
			mazeMatrix[row, col] = cell;
		}
		
	}
}
