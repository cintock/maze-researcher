/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace Maze.Implementation
{
    public struct MazePoint
	{
		public MazePoint(Int32 row, Int32 col)
		{
			Row = row;
			Col = col;
		}
		
		public Int32 Row { get; }
		public Int32 Col { get; }
	}
}
