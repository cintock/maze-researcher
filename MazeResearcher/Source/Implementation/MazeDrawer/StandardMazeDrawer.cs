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

                DrawBorder(painter);

                DrawMaze(painter, maze);

                //if (clusters != null)
                //{
                //    DrawClusters(painter, maze, clusters);
                //}
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
                    if (maze.GetCell(row, col) == MazeSide.Right)
                    {
                        graphics.DrawLine(sizePen, 
                            new Point((col + 1) * cellWidth , (row) * cellHeight),
                            new Point((col + 1) * cellWidth, (row + 1) * cellHeight));
                    }

                    if (maze.GetCell(row, col) == MazeSide.Bottom)
                    {
                        graphics.DrawLine(sizePen,
                            new Point((col) * cellWidth, (row) * cellHeight),
                            new Point((col + 1) * cellWidth, (row) * cellHeight));
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
