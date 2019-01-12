/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace Maze.Implementation
{
	/// <summary>
	/// Интерфейс для классов, создающих лабиринты
	/// </summary>
	public interface IMazeGenerator
	{
		IMazeData Generate(Int32 row, Int32 col);
	}
}
