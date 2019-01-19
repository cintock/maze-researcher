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
		private readonly int[,] attainableCells;
		private readonly int rowCount;
		private readonly int colCount;
		
		public MazeClusters(int row, int col)
		{
			attainableCells = new int[row, col];
			rowCount = row;
			colCount = col;
		}
		
		public MazeClusters(IMazeView maze)
			: this(maze.RowCount, maze.ColCount)
		{			
		}
		
		public bool IsNonclustered(int row, int col)
		{
			return (attainableCells[row, col] == 0);				
		}
		
		public void SetClusterIndex(int row, int col, int clusterIndex)
		{
			attainableCells[row, col] = clusterIndex;
		}
		
		public int GetClusterIndex(int row, int col)
		{
			return attainableCells[row, col];
		}

        public bool GetNextNonClusteredCell(out int nextRow, out int nextCol)
        {
            bool exists = false;
            nextRow = -1;
            nextCol = -1;
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    if (IsNonclustered(row, col))
                    {
                        exists = true;
                        nextRow = row;
                        nextCol = col;
                        break;
                    }
                }
                if (exists)
                {
                    break;
                }
            }

            return exists;
        }

        public int Count()
		{
			HashSet<int> clusters = new HashSet<int>();
			for (int row = 0; row < rowCount; row++)
			{
				for (int col = 0; col < colCount; col++)
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
