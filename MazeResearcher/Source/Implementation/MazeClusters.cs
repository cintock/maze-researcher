/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Collections.Generic;

namespace Maze.Implementation
{
	/// <summary>
	/// Класс для хранения представления связанных областей лабиринта.
	/// Из любой точки связанной области можно попасть в любую другую
	/// точку связанной области. Каждой связанной области соответствует
	/// отличное от 0 числовое значение
	/// </summary>
	public class MazeClusters
	{
		private Int32[,] attainableCells;
		private readonly Int32 rowCount;
		private readonly Int32 colCount;
		
		public MazeClusters(Int32 row, Int32 col)
		{
			attainableCells = new Int32[row, col];
			rowCount = row;
			colCount = col;
		}
		
		public MazeClusters(IMazeData maze)
			: this(maze.RowCount, maze.ColCount)
		{			
		}
		
		public Boolean IsNonclustered(Int32 row, Int32 col)
		{
			return (attainableCells[row, col] == 0);				
		}
		
		public void SetClusterIndex(Int32 row, Int32 col, Int32 clusterIndex)
		{
			attainableCells[row, col] = clusterIndex;
		}
		
		public Int32 GetClusterIndex(Int32 row, Int32 col)
		{
			return attainableCells[row, col];
		}

		public Int32 Count()
		{
			HashSet<Int32> clusters = new HashSet<Int32>();
			for (Int32 row = 0; row < rowCount; row++)
			{
				for (Int32 col = 0; col < colCount; col++)
				{
					if (attainableCells[row, col] != 0)
					{
						clusters.Add(attainableCells[row, col]);
					}
				}
			}
			
			return clusters.Count;
		}
	}
}
