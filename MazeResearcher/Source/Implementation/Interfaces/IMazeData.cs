/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace Maze.Implementation
{	
	/// <summary>
	/// Интерфейс для представления лабиринта
	/// </summary>
	public interface IMazeData
	{
		int RowCount { get; }
		int ColCount { get; }
		
		MazeSide GetCell(int row, int col);
	}
}
