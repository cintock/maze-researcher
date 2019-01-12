using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Maze.Implementation
{
    class StandardMazeDrawer : IMazeDrawer
    {
        MazeDrawingSettings drawingSettings;

        Int32 rowCount;
        Int32 colCount;

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

        private void DrawBorder(Graphics graphics)
        {
            Pen borderPen = new Pen(drawingSettings.BorderColor, 1);
            graphics.DrawRectangle(borderPen,
                new Rectangle(0, 0, 
                drawingSettings.CellWidth * colCount, 
                drawingSettings.CellHeight * rowCount));
        }

        private void DrawMaze(Graphics graphics, IMazeData maze)
        {
            Pen sizePen = new Pen(drawingSettings.SideColor, 1);
            Int32 cellWidth = drawingSettings.CellWidth;
            Int32 cellHeight = drawingSettings.CellHeight;
            for (Int32 row = 0; row < rowCount; row++)
            {
                for (Int32 col = 0; col < colCount; col++)
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

        private void DrawClusters(Graphics graphics, MazeClusters clusters)
        {
            Int32 clustersNumber = clusters.Count();
            Brush[] brushes = new Brush[clustersNumber];
            for (Int32 i = 0; i < brushes.Length; i++)
            {
                brushes[i] = new SolidBrush(Palette.GetColor(i + 1));
            }

            Int32 cellWidth = drawingSettings.CellWidth;
            Int32 cellHeight = drawingSettings.CellHeight;

            for (Int32 row = 0; row < rowCount; row++)
            {
                for (Int32 col = 0; col < colCount; col++)
                {
                    Int32 index = clusters.GetClusterIndex(row, col);
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
