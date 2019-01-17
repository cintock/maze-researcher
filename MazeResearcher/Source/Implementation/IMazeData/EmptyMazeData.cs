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
		public EmptyMazeData(Int32 row, Int32 col)
		{
			rowCount = row;
			colCount = col;
		}
		
		private readonly Int32 rowCount;
		private readonly Int32 colCount;
		
		public Int32 RowCount 
		{
			get 
			{
				return rowCount;
			}
		}
		
		public Int32 ColCount
		{
			get
			{
				return colCount;
			}
		}
		
		public MazeSide GetCell(Int32 r, Int32 c)
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
