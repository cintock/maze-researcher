/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace tests
{
	/// <summary>
	/// Description of IMazeGenerator.
	/// </summary>
	public interface IMazeGenerator
	{
		IMaze Generate(Int32 row, Int32 col);
	}
}
