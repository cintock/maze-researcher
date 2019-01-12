/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace Maze.Implementation
{

	
	/// <summary>
	/// Description of Maze.
	/// </summary>
	public class MazeData : IMazeData
	{
		MazeSide[,] mazeMatrix;
		
		public Int32 RowCount { get; private set; }
		public Int32 ColCount { get; private set; }
		
		public MazeData(Int32 row, Int32 col)
		{
			CheckDimensions(row, col);
			RowCount = row;
			ColCount = col;
			mazeMatrix = new MazeSide[RowCount, ColCount];
		}

		
		public Boolean IsCellExists(Int32 row, Int32 col)
		{
			return ((row >= 0) && (row < RowCount) && (col >= 0) && (col < ColCount));
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
				if (mazeMatrix[row - 1, col].HasFlag(MazeSide.Bottom))
				{
					resultCell |= MazeSide.Top;
				}
			}
			else
			{
				resultCell |= MazeSide.Top;
			}

            if (row < RowCount - 1)
            {
                if (mazeMatrix[row + 1, col].HasFlag(MazeSide.Top))
                {
                    resultCell |= MazeSide.Bottom;
                }
            }
            
            if (row == RowCount - 1)
			{
				resultCell |= MazeSide.Bottom;
			}
			
			if (col > 0)
			{
				if (mazeMatrix[row, col - 1].HasFlag(MazeSide.Right))
				{
					resultCell |= MazeSide.Left;
				}
			}
			else
			{
				resultCell |= MazeSide.Left;
			}

            if (col < ColCount - 1)
            {
                if (mazeMatrix[row, col + 1].HasFlag(MazeSide.Left))
                {
                    resultCell |= MazeSide.Right;
                }
            }
			
			if (col == ColCount - 1)
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
