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
		Int32 RowCount { get; }
		Int32 ColCount { get; }
		
		MazeSide GetCell(Int32 row, Int32 col);
	}
}
