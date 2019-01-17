﻿/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace Maze.Implementation
{	
	/// <summary>
	/// Интерфейс для просмотра лабиринта
	/// </summary>
	public interface IMazeView
	{
		int RowCount { get; }
		int ColCount { get; }

        bool IsCellExists(int row, int col);
		
		MazeSide GetCell(int row, int col);
	}
}
