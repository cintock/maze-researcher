/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Threading;

namespace Maze.Implementation
{
    /// <summary>
    /// Простой рекурсивный алгоритм 
    /// поиска связанных областей в лабиринте.
    /// Использует много памяти стека для рекурсивных вызовов.
    /// Если лабиринт слишком большой может привести к 
    /// переполнению стека.
    /// </summary>
    public class MazeClustererRecursion : IMazeClusterer
	{
        private const int recursionStackSize = 10 * 1024 * 1024;

        private MazeClusters clusters;
		private IMazeView processedMaze;
		private int rowCount;
		private int colCount;

        private string threadExceptionMessage = null;
		
		public MazeClustererRecursion()
		{
        }
		
		public MazeClusters Cluster(IMazeView maze)
		{
			processedMaze = maze;
			rowCount = maze.RowCount;
			colCount = maze.ColCount;
			clusters = new MazeClusters(processedMaze);

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
                // todo: можно подумать про добавление своих типов исключений,
                // здесь можно будет использовать
            }

            return clusters;
		}

        private void FindClusters()
        {
            int nextRow = 0;
            int nextCol = 0;
            int clusterIndex = 1;
            bool containsNonClusteredCells = true;
            try
            {
                while (containsNonClusteredCells)
                {
                    WalkCluster(nextRow, nextCol, clusterIndex++);
                    containsNonClusteredCells = clusters.GetNextNonClusteredCell(out nextRow, out nextCol);
                }
            }
            // метод выполняем в отдельном потоке, 
            // поэтому отлавливаем все возможные исключения
            catch (Exception ex)
            {
                // мы ловим тут исключения, поскольку метод выполняется в потоке,
                // но StackOverflowException здесь все равно не отловится
                threadExceptionMessage = ex.Message;
            }
        }

		void WalkCluster(int row, int col, int cluster)
		{
			if (processedMaze.IsCellExists(row, col))
			{
				if (clusters.IsNonclustered(row, col))
				{
					MazeSide currentCell = processedMaze.GetCell(row, col);
					clusters.SetClusterIndex(row, col, cluster);
					
					if (processedMaze.IsCellExists(row - 1, col))
					{
						if (!currentCell.HasFlag(MazeSide.Top))
						{
							WalkCluster(row - 1, col, cluster);
						}
					}
					
					if (processedMaze.IsCellExists(row + 1, col))
					{
						if (!currentCell.HasFlag(MazeSide.Bottom))
						{
							WalkCluster(row + 1, col, cluster);
						}
					}					
					
					if (processedMaze.IsCellExists(row, col - 1))
					{
						if (!currentCell.HasFlag(MazeSide.Left))
						{
							WalkCluster(row, col - 1, cluster);
						}
					}		

					if (processedMaze.IsCellExists(row, col + 1))
					{
						if (!currentCell.HasFlag(MazeSide.Right))
						{
							WalkCluster(row, col + 1, cluster);
						}
					}						
				}
			}
		}
	}
}
