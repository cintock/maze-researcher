/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace tests
{
	/// <summary>
	/// Description of MazeGeneratorNamed.
	/// </summary>
	internal class MazeGeneratorNamed
	{
		public MazeGeneratorNamed(IMazeGenerator generator, String name)
		{
			Generator = generator;
			Name = name;
		}
		
		public IMazeGenerator Generator 
		{ 
			get;
			private set; 
		}
		
		public String Name 
		{ 
			get; 
			private set; 
		}
	}
}
