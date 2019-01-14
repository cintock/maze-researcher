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
    /// Статический класс с методом, возвращающим список из возможных 
    /// объектов генерации лабиринтов, с их именами (для вывода в Combobox)
    /// </summary>
    internal static class MazeGeneratorNamedList
	{
		static List<NamedObject<IMazeGenerator>> mazeGeneratorList;
		
		internal static List<NamedObject<IMazeGenerator>> Get()
		{
			if (mazeGeneratorList == null)
			{
				mazeGeneratorList = new List<NamedObject<IMazeGenerator>>()
				{
					new NamedObject<IMazeGenerator>(new RandomMazeGenerator(), 
					                       "Полностью случайный лабиринт"),
					
					new NamedObject<IMazeGenerator>(new EmptyMazeGenerator(), 
					                       "Пустой лабиринт"),
					
					new NamedObject<IMazeGenerator>(new EmptyDummyMazeGenerator(),
					                       "Пустой лабиринт (оптимизированный вариант)"),
					
					new NamedObject<IMazeGenerator>(new EllerModMazeGenerator(),
                       "Вариация алгоритма Эллера"),

				};
				
			}
			return mazeGeneratorList;
		}
	}
}
