/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace Maze.Implementation
{
	/// <summary>
	/// Класс для хранения пустого лабиринта.
    /// Содержит только размеры лабиринта.
    /// Внутренней матрицы значений ячеек нет.
	/// </summary>
	public class EmptyMazeData : IMazeData
	{
		public EmptyMazeData(int row, int col)
		{
			rowCount = row;
			colCount = col;
		}
		
		private readonly int rowCount;
		private readonly int colCount;
		
		public int RowCount 
		{
			get 
			{
				return rowCount;
			}
		}
		
		public int ColCount
		{
			get
			{
				return colCount;
			}
		}
		
		public MazeSide GetCell(int r, int c)
		{
			MazeSide cell = MazeSide.None;
			if (r == 0)
			{
				cell |= MazeSide.Top;				
			}
			
			if (c == 0)
			{
				cell |= MazeSide.Left;
			}
			
			if (r == rowCount - 1)
			{
				cell |= MazeSide.Bottom;
			}
			
			if (c == colCount - 1)
			{
				cell |= MazeSide.Right;
			}
			return cell;
		}
	}
}
