/*
 * Author: cintock
 * Date: 06.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Collections.Generic;
using Maze.Implementation;

namespace Maze.UI
{
	/// <summary>
	/// Description of MazeGeneratorNamedList.
	/// </summary>
	internal static class MazeGeneratorNamedList
	{
		static List<MazeGeneratorNamed> mazeGeneratorList;
		
		internal static IList<MazeGeneratorNamed> Get()
		{
			if (mazeGeneratorList == null)
			{
				mazeGeneratorList = new List<MazeGeneratorNamed>()
				{
					new MazeGeneratorNamed(new RandomMazeGenerator(), 
					                       "Полностью случайный лабиринт"),
					
					new MazeGeneratorNamed(new EmptyMazeGenerator(), 
					                       "Пустой лабиринт"),
					
					new MazeGeneratorNamed(new EmptyDummyMazeGenerator(),
					                       "Пустой лабиринт (оптимизированный вариант)"),
					
					new MazeGeneratorNamed(new EllerModMazeGenerator(),
                       "Вариация алгоритма Эллера"),

				};
				
			}
			return mazeGeneratorList;
		}
	}
}
