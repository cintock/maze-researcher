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
	/// который хранит объект и выводимое имя.
	/// </summary>    
	internal class NamedObject<T>
    {
		public NamedObject(T objectValue, String name)
		{
			ObjectValue = objectValue;
			Name = name;
		}
		
		public T ObjectValue
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
