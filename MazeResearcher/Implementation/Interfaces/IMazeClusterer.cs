/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace Maze.Implementation
{
	/// <summary>
	/// Description of IMazeSolver.
	/// </summary>
	public interface IMazeClusterer
	{
		MazeClusters Cluster(IMazeData maze);
	}
}
