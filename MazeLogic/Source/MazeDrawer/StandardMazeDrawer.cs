using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Maze.Logic;

namespace Maze.Logic
{
    public class StandardMazeDrawer : IMazeDrawer
    {
        protected MazeDrawingSettings drawingSettings;
        protected int rowCount;
        protected int colCount;

        public byte[] Draw(IMazeView maze, MazeClusters clusters = null)
        {
            if (drawingSettings is null)
            {
                throw new MazeException(
                    "Попытка нарисовать лабиринт без задания настроек рисования");
            }

            rowCount = maze.RowCount;
            colCount = maze.ColCount;

            using (SimpleDrawer drawer = 
                new SimpleDrawer(
                    colCount * drawingSettings.CellWidth + 1,
                    rowCount * drawingSettings.CellHeight + 1, 
                    drawingSettings.BackgroundColor))
            {

                if (clusters != null)
                {
                    DrawClusters(drawer, clusters);
                }

                DrawMaze(drawer, maze);

                DrawBorder(drawer);

                return drawer.ReadBmpImage();
            }
        }

        protected virtual void DrawBorder(SimpleDrawer drawer)
        {
            drawer.DrawRect(0, 0, 
                drawingSettings.CellWidth * colCount,
                drawingSettings.CellHeight * rowCount, 
                drawingSettings.BorderColor);
        }

        protected virtual void DrawMaze(SimpleDrawer drawer, IMazeView maze)
        {
            int cellWidth = drawingSettings.CellWidth;
            int cellHeight = drawingSettings.CellHeight;
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    if (maze.GetCell(row, col).HasFlag(MazeSide.Right))
                    {
                        if (col < colCount - 1)
                        {
                            drawer.DrawLine(
                                (col + 1) * cellWidth, (row) * cellHeight,
                                (col + 1) * cellWidth, (row + 1) * cellHeight,
                                drawingSettings.SideColor);
                        }
                    }

                    if (maze.GetCell(row, col).HasFlag(MazeSide.Bottom))
                    {
                        if (row < rowCount - 1)
                        {
                            drawer.DrawLine(
                                (col) * cellWidth, (row + 1) * cellHeight,
                                (col + 1) * cellWidth, (row + 1) * cellHeight,
                                drawingSettings.SideColor);
                        }
                    }
                }
            }
        }

        protected virtual void DrawClusters(SimpleDrawer drawer, MazeClusters clusters)
        {
            int clustersNumber = clusters.Count();
            uint[] clustersColors = new uint[clustersNumber];
            for (int i = 0; i < clustersColors.Length; i++)
            {
                clustersColors[i] = Palette.GetColor(i + 1);
            }

            int cellWidth = drawingSettings.CellWidth;
            int cellHeight = drawingSettings.CellHeight;

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    int index = clusters.GetClusterIndex(row, col);
                    if (index > 0)
                    {
                        drawer.DrawFilledRect(col * cellWidth, row * cellHeight,
                            cellWidth, cellHeight,
                            clustersColors[index - 1]);
                    }
                }
            }
        }

        public void SetDrawingSettings(MazeDrawingSettings settings)
        {
            drawingSettings = settings;
        }
    }
}
