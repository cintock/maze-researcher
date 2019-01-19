using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.Implementation
{
    public class MazeClusterer : IMazeClusterer
    {
        private MazeClusters clusters;
        private IMazeView maze;

        public MazeClusterer()
        {
        }

        public MazeClusters Cluster(IMazeView maze)
        {
            this.maze = maze;
            clusters = new MazeClusters(maze);
            int row = 0;
            int col = 0;
            int index = 0;
            if (maze.IsCellExists(row, col))
            {
                List<MazePoint> foundPoints = Walk(new MazePoint(row, col), ++index); 
                while (foundPoints.Count > 0)
                {
                    List<MazePoint> nextPoints = new List<MazePoint>(foundPoints);
                    foundPoints.Clear();
                    foreach (MazePoint point in nextPoints)
                    {
                        foundPoints.AddRange(Walk(point, index));
                    }                                        
                };
            }
            return clusters;
        }

        private List<MazePoint> Walk(MazePoint coord, int index)
        {
            int row = coord.Row;
            int col = coord.Col;

            List<MazePoint> openedPoints = new List<MazePoint>(4);

            ProcessCell(row, col, index);

            MazeSide currentCell = maze.GetCell(row, col);

            if (!currentCell.HasFlag(MazeSide.Bottom))
            {
                int nextRow = row + 1;
                if (ProcessCell(nextRow, col, index))
                {
                    openedPoints.Add(new MazePoint(nextRow, col));
                }
            }

            if (!currentCell.HasFlag(MazeSide.Right))
            {
                int nextCol = col + 1;
                if (ProcessCell(row, nextCol, index))
                {
                    openedPoints.Add(new MazePoint(row, nextCol));
                }
            }

            if (!currentCell.HasFlag(MazeSide.Top))
            {
                int nextRow = row - 1;
                if (ProcessCell(nextRow, col, index))
                {
                    openedPoints.Add(new MazePoint(nextRow, col));
                }
            }

            if (!currentCell.HasFlag(MazeSide.Left))
            {
                int nextCol = col - 1;
                if (ProcessCell(row, nextCol, index))
                {
                    openedPoints.Add(new MazePoint(row, nextCol));
                }
            }

            return openedPoints;
        }

        private bool ProcessCell(int row, int col, int index)
        {
            bool processed = false;
            if (maze.IsCellExists(row, col))
            {
                if (clusters.IsNonclustered(row, col))
                {
                    clusters.SetClusterIndex(row, col, index);
                    processed = true;
                }
            }

            return processed;
        }
    }
}
