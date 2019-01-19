using System;
using System.Collections.Generic;
using System.Linq;
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
            int index = 1;
            if (maze.IsCellExists(row, col))
            {
                NextStep(new MazePoint(row, col), index);
            }
            return clusters;
        }

        private void NextStep(MazePoint coord, int index)
        {
            int row = coord.Row;
            int col = coord.Col;
            MazeSide cell = maze.GetCell(row, col);

            while (!maze.GetCell(row, col).HasFlag(MazeSide.Bottom))
            {
                row++;
                if (!ProcessCell(row, col, index))
                {
                    break;
                }
            }

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
