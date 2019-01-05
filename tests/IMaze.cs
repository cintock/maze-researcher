/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace tests
{
	[Flags]
	// todo: переименовать в "стенка ячейки лабиринта" или около того
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
	public interface IMaze
	{
		Int32 rowCount { get; }
		Int32 colCount { get; }
		
		MazeSide GetCell(Int32 row, Int32 col);
	}
}
