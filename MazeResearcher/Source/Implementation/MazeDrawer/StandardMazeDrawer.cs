using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Maze.Implementation
{
    public class StandardMazeDrawer : IMazeDrawer
    {
        protected MazeDrawingSettings drawingSettings;
        protected int rowCount;
        protected int colCount;

        public Bitmap Draw(IMazeData maze, MazeClusters clusters = null)
        {
            rowCount = maze.RowCount;
            colCount = maze.ColCount;

            Bitmap imageBitmap = new Bitmap(colCount * drawingSettings.CellWidth + 1, 
                rowCount * drawingSettings.CellHeight + 1);

            using (Graphics painter = Graphics.FromImage(imageBitmap))
            {
                painter.Clear(drawingSettings.BackgroundColor);

                if (clusters != null)
                {
                    DrawClusters(painter, clusters);
                }

                DrawMaze(painter, maze);
                DrawBorder(painter);
            }

            return imageBitmap;
        }

        protected virtual void DrawBorder(Graphics graphics)
        {
            Pen borderPen = new Pen(drawingSettings.BorderColor, 1);
            graphics.DrawRectangle(borderPen,
                new Rectangle(0, 0, 
                drawingSettings.CellWidth * colCount, 
                drawingSettings.CellHeight * rowCount));
        }

        protected virtual void DrawMaze(Graphics graphics, IMazeData maze)
        {
            Pen sizePen = new Pen(drawingSettings.SideColor, 1);
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
                            graphics.DrawLine(sizePen,
                                new Point((col + 1) * cellWidth, (row) * cellHeight),
                                new Point((col + 1) * cellWidth, (row + 1) * cellHeight));
                        }
                    }

                    if (maze.GetCell(row, col).HasFlag(MazeSide.Bottom))
                    {
                        if (row < rowCount - 1)
                        {
                            graphics.DrawLine(sizePen,
                                new Point((col) * cellWidth, (row + 1) * cellHeight),
                                new Point((col + 1) * cellWidth, (row + 1) * cellHeight));
                        }
                    }
                }
            }
        }

        protected virtual void DrawClusters(Graphics graphics, MazeClusters clusters)
        {
            int clustersNumber = clusters.Count();
            Brush[] brushes = new Brush[clustersNumber];
            for (int i = 0; i < brushes.Length; i++)
            {
                brushes[i] = new SolidBrush(Palette.GetColor(i + 1));
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
                        Rectangle cellRect = new Rectangle(col * cellWidth, row * cellHeight, 
                            cellWidth, cellHeight);

                        graphics.FillRectangle(brushes[index - 1], cellRect);
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
