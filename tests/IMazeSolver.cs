/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace tests
{
	/// <summary>
	/// Description of IMazeSolver.
	/// </summary>
	public interface IMazeSolver
	{
		MazeSolution Solve(IMaze maze);
	}
}
