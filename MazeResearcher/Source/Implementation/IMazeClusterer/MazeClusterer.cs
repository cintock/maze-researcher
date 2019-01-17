/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Collections.Generic;
using System.Threading;

namespace Maze.Implementation
{
    /// <summary>
    /// Простой рекурсивный алгоритм поиска связанных областей в лабиринте
    /// </summary>
    public class MazeClustererRecursion : IMazeClusterer
	{
        private const Int32 recursionStackSize = 10 * 1024 * 1024;

        private MazeClusters clusters;
		private IMazeData workMaze;
		private Int32 rowCount;
		private Int32 colCount;

        private String threadExceptionMessage = null;
		
		public MazeClustererRecursion()
		{
        }
		
		public MazeClusters Cluster(IMazeData maze)
		{
			workMaze = maze;
			rowCount = maze.RowCount;
			colCount = maze.ColCount;
			clusters = new MazeClusters(workMaze);

            threadExceptionMessage = null;

            // Создаем поток с единственной целью - увеличение стека.
            // Это нужно чтобы простой рекурсивный алгоритм мог выполниться для
            // достаточно больших лабиринтов.
            // Текущий поток ждет завершения выполнения созданного потока,
            // не выполняется одновременно с созданным потоком.
            // Одновременного доступа к переменным из разных потоков тут не происходит.
            Thread clusterThread = new Thread(FindClusters, recursionStackSize);
            clusterThread.Start();
            Thread.Yield();
            clusterThread.Join();

            if (threadExceptionMessage != null)
            {
                DebugConsole.Instance().Log(threadExceptionMessage);                
            }

            return clusters;
		}

        private void FindClusters()
        {
            Int32 nextRow = 0;
            Int32 nextCol = 0;
            Int32 clusterIndex = 1;
            Boolean allClustered = false;
            try
            {
                while (!allClustered)
                {
                    GoCell(nextRow, nextCol, clusterIndex++);
                    allClustered = true;
                    for (Int32 row = 0; row < rowCount; row++)
                    {
                        for (Int32 col = 0; col < colCount; col++)
                        {
                            if (clusters.IsNonclustered(row, col))
                            {
                                allClustered = false;
                                nextRow = row;
                                nextCol = col;
                                break;
                            }
                        }
                        if (!allClustered)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // мы ловим тут исключения, поскольку мето выполняется в потоке,
                // но StackOverflowException здесь все равно не отловится
                threadExceptionMessage = ex.Message;
            }
        }
		
		Boolean IsCellExists(Int32 row, Int32 col)
		{
			return ((row >= 0) && (row < rowCount) && (col >= 0) && (col < colCount));
		}
		
		void GoCell(Int32 row, Int32 col, Int32 cluster)
		{
			if (IsCellExists(row, col))
			{
				if (clusters.IsNonclustered(row, col))
				{
					MazeSide currentCell = workMaze.GetCell(row, col);
					clusters.SetClusterIndex(row, col, cluster);
					
					if (IsCellExists(row - 1, col))
					{
						if (!currentCell.HasFlag(MazeSide.Top))
						{
							GoCell(row - 1, col, cluster);
						}
					}
					
					if (IsCellExists(row + 1, col))
					{
						if (!currentCell.HasFlag(MazeSide.Bottom))
						{
							GoCell(row + 1, col, cluster);
						}
					}					
					
					if (IsCellExists(row, col - 1))
					{
						if (!currentCell.HasFlag(MazeSide.Left))
						{
							GoCell(row, col - 1, cluster);
						}
					}		

					if (IsCellExists(row, col + 1))
					{
						if (!currentCell.HasFlag(MazeSide.Right))
						{
							GoCell(row, col + 1, cluster);
						}
					}						
				}
			}
		}
	}
}
