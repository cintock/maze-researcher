/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;
using Maze.Implementation;

namespace Maze.UI
{
	/// <summary>
	/// Вспомогательный класс для интерфейсного элемента ComboxBox,
	/// который хранит объект генератора и выводимое имя.
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
