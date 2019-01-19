/*
 * Author: cintock
 * Date: 10.01.2019
 * Created by SharpDevelop.
 */

using System;

namespace Maze.Implementation
{
	[Flags]
	public enum MazeSide : byte
	{
		None = 0,
		Bottom = 1,
		Right = 2,		
		Top = 4,
		Left = 8,
	}
}