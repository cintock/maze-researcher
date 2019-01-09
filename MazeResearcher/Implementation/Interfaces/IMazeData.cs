/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace Maze.Implementation
{
	[Flags]
	public enum MazeSide
	{
		None = 0,
		Bottom = 1,
		Right = 2,
		
		Left = 4,
		Top = 8,
	}
	
	/// <summary>
	/// Description of IMaze.
	/// </summary>
	public interface IMazeData
	{
		Int32 RowCount { get; }
		Int32 ColCount { get; }
		
		MazeSide GetCell(Int32 row, Int32 col);
	}
}
