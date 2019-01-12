﻿/*
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
		public EmptyMazeData(Int32 r, Int32 c)
		{
			row = r;
			col = c;
		}
		
		private Int32 row;
		private Int32 col;
		
		public Int32 RowCount 
		{
			get 
			{
				return row;
			}
		}
		
		public Int32 ColCount
		{
			get
			{
				return col;
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
			
			if (r == row - 1)
			{
				cell |= MazeSide.Bottom;
			}
			
			if (c == col - 1)
			{
				cell |= MazeSide.Right;
			}
			return cell;
		}
	}
}
