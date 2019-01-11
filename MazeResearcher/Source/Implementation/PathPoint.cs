/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace Maze.Implementation
{
    public struct PathPoint
	{
		public PathPoint(Int32 r, Int32 c)
		{
			Row = r;
			Col = c;
		}
		
		public readonly Int32 Row;
		public readonly Int32 Col;
	}
}
